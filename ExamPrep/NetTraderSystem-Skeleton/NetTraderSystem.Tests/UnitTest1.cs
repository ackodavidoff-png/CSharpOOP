using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class Tests
    {
        private TradingPlatform platform;
        private Product product;
        [SetUp]
        public void Setup()
        {
            platform = new TradingPlatform(2);
            product = new Product("Intex", "Pojas", 3);
        }

        [Test]
        public void Test01_ConstructorShouldBeInizializedProperly()
        {
            //Assert.Pass();
            Assert.IsNotNull(platform.Products);
            //Assert.AreEqual(0, platform.Products.Count);
            Assert.That(platform.Products.Count, Is.EqualTo(0));
        }
        [Test]
        public void Test02_AddProductShouldAddProductWhenIsPossible()
        {
            string result = platform.AddProduct(product);
            Assert.AreEqual($"Product Intex added successfully", result);
            Assert.AreEqual(1, platform.Products.Count);
        }
        [Test]
        public void Test03_AddProductShouldNotAddElementsIfLimitIsExceeded()
        {
            platform.AddProduct(new Product("Peugeot 308", "Car", 6000));
            platform.AddProduct(new Product("Intex", "Pojas", 3));
            string result = platform.AddProduct(new Product("Dell Precision 5560 Intel Core i7-11850H 32GB RAM DDR4 1024GB NVMe", "Laptop", 850));
            Assert.AreEqual("Inventory is full", result);
            Assert.AreEqual(2, platform.Products.Count);
        }
        [Test]
        public void Test04_RemoveShouldReturnTrueAndRemoveTheElementIfItExisis()
        {
            platform.AddProduct(new Product("Peugeot 308SW", "Car", 6000));
            platform.AddProduct(new Product("Intex", "Pojas", 3));
            Product ToRemove = platform.Products.FirstOrDefault(product => product.Name == "Peugeot 308SW");
            bool result = platform.RemoveProduct(ToRemove);
            Assert.IsTrue(result);
            Assert.AreEqual(1, platform.Products.Count);
        }
        [Test]
        public void Test05_RemoveShouldReturnFalseIfTheElementDoesNotExist()
        {
            platform.AddProduct(new Product("Peugeot 308SW", "Car", 6000));
            platform.AddProduct(new Product("Intex", "Pojas", 3));
            Product ToRemove = new Product("Dell Precision 5560 Intel Core i7-11850H 32GB RAM DDR4 1024GB NVMe", "Laptop", 850);
            bool result = platform.RemoveProduct(ToRemove);
            Assert.IsFalse(result);
            Assert.AreEqual(2, platform.Products.Count);
        }
        [Test]
        public void Test06_WhenSellingAProductTheProductShouldBeRemovedFromTheCollectionAndGetSelled()
        {
            //platform.AddProduct(new Product("Peugeot 308SW", "Car", 6000));
            //platform.AddProduct(new Product("Intex", "Pojas", 3));
            //Product ToSell = platform.Products.FirstOrDefault(product => product.Name == "Intex");
            //platform.SellProduct(ToSell);
            //Assert.AreEqual(product, ToSell);
            //Assert.AreEqual(1, platform.Products.Count);
            platform.AddProduct(product);
            Product sold = platform.SellProduct(product);
            Assert.AreEqual(product, sold);
            Assert.AreEqual(0, platform.Products.Count);
        }
        [Test]
        public void Test07_WhenSellingAProductThatDoesNotExistShouldReturnNull()
        {
            Product sold = platform.SellProduct(new Product("Dell Precision 5560 Intel Core i7-11850H 32GB RAM DDR4 1024GB NVMe", "Laptop", 850));
            Assert.IsNull(sold);
        }
        [Test]
        public void Test08_InventoryReportShouldReturnTheCorrectOutputWhenIsEmpty()
        {
            string report = platform.InventoryReport();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine($"Available Products: 0");
            Assert.AreEqual(sb.ToString().TrimEnd(), report);
        }
        [Test]
        public void Test09_InventoryReportShouldReturnTheCorrectOutputWhenIsNotEmpty()
        {
            Product P1 = (new Product("Peugeot 308", "Car", 6000));
            Product P2 = (new Product("Intex", "Pojas", 3));
            platform.AddProduct(P1);
            platform.AddProduct(P2);
            string report = platform.InventoryReport();
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine($"Available Products: 2");
            sb.AppendLine(P1.ToString());
            sb.AppendLine(P2.ToString());
            Assert.AreEqual(sb.ToString().TrimEnd(), report);
        }
    }
}