using BlackFriday.Core.Contracts;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BlackFriday
{
    public class Controller : IController
    {
        private IApplication application;
        public Controller()
        {
            application = new Application();
        }
        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            if (productType != "Item" && productType != "Service")
            {
                return $"{productType} is not a valid type for the application.";
            }
            if (application.Products.Exists(productName))
            {
                //return string.Format(OutputMessages.ProductNameDuplicated, productName);
                return $"{productName} already exists in the application.";
            }
            IUser user = application.Users.GetByName(userName);
            if (user == null || !user.HasDataAccess)
            {
                return $"{userName} has no data access.";
            }
            IProduct product = null;
            if (productType == "Item")
            {
                product = new Item(productName, basePrice);
            }
            else if (productType == "Service")
            {
                product = new Service(productName, basePrice);
            }
            application.Products.AddNew(product);
            return $"{productType}: {productName} is added in the application. Price: {basePrice:F2}";
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Application administration:");
            IOrderedEnumerable<IUser> admins = application.Users.Models.Where(administrator => administrator.HasDataAccess).OrderBy(administrator => administrator.UserName);
            foreach (IUser admin in admins)
            {
                sb.AppendLine(admin.ToString());
            }
            sb.AppendLine("Clients:");
            var clients = application.Users.Models.Where(u => !u.HasDataAccess).OrderBy(u => u.UserName);

            foreach (var user in clients)
            {
                Client client = user as Client;

                if (client == null)
                {
                    throw new NullReferenceException();
                }
                sb.AppendLine(client.ToString());
                var blackFridayPurchases = client.Purchases.Where(p => p.Value).Select(p => p.Key).ToList();
                if (blackFridayPurchases.Count > 0)
                {
                    sb.AppendLine($"-Black Friday Purchases: {blackFridayPurchases.Count}");

                    foreach (var product in blackFridayPurchases)
                    {
                        sb.AppendLine($"--{product}");
                    }
                }
            }
            //IOrderedEnumerable<IUser> clients = application.Users.Models.Where(u => !u.HasDataAccess).OrderBy(u => u.UserName);
            //foreach (var client in clients)
            //{
            //    Client cl = client as Client;
            //    sb.AppendLine(cl.ToString());
            //    if (client == null)
            //    {
            //        throw new NullReferenceException();
            //    }
            //    var blackFridayPurchases = client.Purchases.Where(p => p.Value).Select(p => p.Key).ToList();
            //    if (blackFridayPurchases.Count > 0)
            //    {
            //        sb.AppendLine($"-Black Friday Purchases: {blackFridayPurchases.Count}");
            //
            //        foreach (var product in blackFridayPurchases)
            //        {
            //            sb.AppendLine($"--{product}");
            //        }
            //    }
            //}
            return sb.ToString().TrimEnd();
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            IUser user = application.Users.GetByName(userName);
            if (user == null || user.HasDataAccess)
            {
                return $"{userName} has no authorization for this functionality.";
            }
            IProduct product = application.Products.GetByName(productName);
            if (product == null)
            {
                return $"{productName} does not exist in the application.";
            }
            if (product.IsSold) //product != null && 
            {
                return $"{productName} is out of stock.";
            }
            Client client = (Client)user;
            client.PurchaseProduct(productName, blackFridayFlag);
            product.ToggleStatus();
            double price;
            if (blackFridayFlag)
            {
                price = product.BlackFridayPrice;
            }
            else
            {
                price = product.BasePrice;
            }
            return $"{userName} purchased {productName}. Price: {price:F2}";
        }

        public string RefreshSalesList(string userName)
        {
            IUser user = application.Users.GetByName(userName);
            if (user == null || !user.HasDataAccess)
            {
                return $"{userName} has no data access.";
            }
            double updatedProductsCount = 0;
            IEnumerable<IProduct> products = application.Products.Models.Where(product => product.IsSold);
            foreach (IProduct product in products)
            {
                product.ToggleStatus();
                updatedProductsCount++;
            }
            return $"{updatedProductsCount} products are listed again.";
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            if (application.Users.Exists(userName))
            {
                return $"{userName} is already registered.";
            }
            if (application.Users.Models.Any(e => e.Email == email))// && !hasDataAccess)
            {
                return $"{email} is already used by another user.";
            }
            if (hasDataAccess)
            {
                int administrators = application.Users.Models.Count(u => u.HasDataAccess);
                if (administrators >= 2)
                {
                    return "The number of application administrators is limited.";
                }
                IUser administrrator = new Admin(userName, email);
                application.Users.AddNew(administrrator);
                return $"Admin {userName} is successfully registered with data access.";
            }
            IUser client = new Client(userName, email);
            application.Users.AddNew(client);
            return $"Client {userName} is successfully registered.";
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            IProduct product = application.Products.GetByName(productName);
            if (product == null)
            {
                return $"{productName} does not exist in the application.";
            }
            IUser user = application.Users.GetByName(userName);
            if (user == null || !user.HasDataAccess)
            {
                return $"{userName} has no data access.";
            }
            double oldPrice = product.BasePrice;
            product.UpdatePrice(newPriceValue);
            return $"{productName} -> Price is updated: {oldPrice:F2} -> {newPriceValue:F2}";
        }
    }
}
