using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        private DealerShop shop;
        private Vehicle vehicle;
        [SetUp]
        public void Setup()
        {
            this.shop = new DealerShop(5);
            this.vehicle = new Vehicle("Peugeot", "308SW", 2015);
        }

        [Test]
        public void Test01_ConstructorShouldBeinizializedCorrectly()
        {
            //Assert.Pass();
            Assert.IsNotNull(shop);
            Assert.AreEqual(0, shop.Vehicles.Count);
        }
        [Test]
        public void Test02_DealershipCapacityShouldNotBe0OrNegative()
        {
            DealerShop shop;
            Assert.Throws<ArgumentException>(() => shop = new DealerShop(0));
            Assert.Throws<ArgumentException>(() => shop = new DealerShop(-1));
        }
        [Test]
        public void Test03_AddVehicleShouldThrowExceptionWhenItsCapacityGetsExceeded()
        {
            this.shop.AddVehicle(new Vehicle("Peugeot", "308SW", 2015));
            this.shop.AddVehicle(new Vehicle("Honda", "Accord", 2012));
            this.shop.AddVehicle(new Vehicle("Seat", "Leon", 2017));
            this.shop.AddVehicle(new Vehicle("Toyota", "Camry", 2021));
            this.shop.AddVehicle(new Vehicle("Audi", "A6 Quattro", 2008));
            InvalidOperationException argumentException = Assert.Throws<InvalidOperationException>(() => this.shop.AddVehicle(new Vehicle("Ford", "Fiesta", 1995)));
        }
        [Test]
        public void Test04_AddVehicleShouldAddVehicleIfTheCapacityIsNotExceeded()
        {
            this.shop.AddVehicle(new Vehicle("Peugeot", "308SW", 2015));
            this.shop.AddVehicle(new Vehicle("Honda", "Accord", 2012));
            //this.shop.AddVehicle(new Vehicle("Seat", "Leon", 2017));
            string result = this.shop.AddVehicle(new Vehicle("Toyota", "Camry", 2021));
            Assert.AreEqual(3, shop.Vehicles.Count);
            Assert.AreEqual("Added 2021 Toyota Camry", result);
        }
        [Test]
        public void Test05_SellVehicleShouldReturnTrueIfTheVehicleExistsAndThenSellIt()
        {
            this.shop.AddVehicle(new Vehicle("Peugeot", "308SW", 2016));
            this.shop.AddVehicle(new Vehicle("Subaru", "Impreza", 1999));
            this.shop.AddVehicle(new Vehicle("Seat", "Leon", 2007));
            Vehicle toSell = shop.Vehicles.FirstOrDefault(car => car.Make == "Subaru");
            bool result = this.shop.SellVehicle(toSell);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test06_SellVehicleShouldReturnFalseIfTheVehicleDoesNotExist()
        {
            this.shop.AddVehicle(new Vehicle("Peugeot", "308SW", 2016));
            this.shop.AddVehicle(new Vehicle("Subaru", "Impreza", 1999));
            this.shop.AddVehicle(new Vehicle("Seat", "Leon", 2007));
            Vehicle toSell = new Vehicle("Skoda", "Superb", 2018);
            bool result = shop.SellVehicle(toSell);
            Assert.IsFalse(result);
        }
        [Test]
        public void Test07_InventoryReportShouldReturnTheRightOutputWhenIsEmpty()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report");
            sb.AppendLine($"Capacity: 5");
            sb.AppendLine($"Vehicles: 0");
            string report = shop.InventoryReport();
            Assert.That(report, Is.EqualTo(sb.ToString().TrimEnd()));
        }
        [Test]
        public void Test08_InventoryReportShouldReturnTheRightOutputWhenIsNotEmpty()
        {
            Vehicle car1 = new Vehicle("Peugeot", "308SW", 2015);
            Vehicle car2 = new Vehicle("Honda", "Accord  Gen 8 Type S Facelift", 2011);
            Vehicle car3 = new Vehicle("Toyota", "Camry", 2021);
            this.shop.AddVehicle(car1);
            this.shop.AddVehicle(car2);
            this.shop.AddVehicle(car3);
            string report = this.shop.InventoryReport();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Inventory Report");
            expected.AppendLine($"Capacity: 5");
            expected.AppendLine($"Vehicles: 3");
            expected.AppendLine(car1.ToString());
            expected.AppendLine(car2.ToString());
            expected.AppendLine(car3.ToString());
            Assert.AreEqual(expected.ToString().TrimEnd(), report);
        }
        [Test]
        public void Test09_DealerShipCapacityShouldBePositive()
        {
            Vehicle car1 = new Vehicle("Peugeot", "308SW", 2015);
            Vehicle car2 = new Vehicle("Honda", "Accord  Gen 8 Type S Facelift", 2011);
            Vehicle car3 = new Vehicle("Toyota", "Camry", 2021);
            this.shop.AddVehicle(car1);
            this.shop.AddVehicle(car2);
            this.shop.AddVehicle(car3);
            Assert.AreEqual(3, shop.Vehicles.Count);
            Assert.AreEqual(5, shop.Capacity);
        }
    }
}
