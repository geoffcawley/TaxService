using NUnit.Framework;
using System;
using TaxLibrary.Models;
using TaxLibrary.Services;

namespace TaxTests
{
    public class Tests
    {
        private TaxCalculator _taxCalculator;
        private TaxService _taxService;

        public Order BlankOrder { get; set; }
        public Order BadOrder { get; set; }
        public Order GoodOrder { get; set; }
        public Order OrderWithLineItems { get; set; }

        public NexusOrder NexusOrder { get; set; }
        public NexusOrder NexusOrderWithLineItems { get; set; }


        [SetUp]
        public void Setup()
        {
            _taxCalculator = new TaxCalculator();
            _taxService = new TaxService(_taxCalculator);
            BlankOrder = new Order();
            BadOrder = new Order() { from_country = "The Moon" };
            GoodOrder = new Order()
            {
                from_country = "US",
                from_state = "TX",
                from_zip = "77057",
                to_country = "US",
                to_zip = "10801",
                to_state = "NY",
                amount = 1000,
                shipping = 45,
                line_items = new OrderLineItem[0],
            };
            OrderWithLineItems = new Order()
            {
                from_country = "US",
                from_state = "AK",
                from_zip = "99629",
                to_country = "US",
                to_zip = "07112",
                to_state = "NJ",
                shipping = 45,
                line_items =  new OrderLineItem[3] { 
                    new OrderLineItem() { product_tax_code = "19005", quantity = 3, unit_price = 150 },
                    new OrderLineItem() { product_tax_code = "19005", quantity = 5, unit_price = 200 },
                    new OrderLineItem() { product_tax_code = "19006", quantity = 2, unit_price = 3000 },
                }
            };


            NexusOrder = new NexusOrder
            {
                from_country = "US",
                from_state = "TX",
                from_zip = "77057",
                to_country = "US",
                to_zip = "10801",
                to_state = "NY",
                amount = 1000,
                shipping = 45,
                nexus_addresses = new NexusAddress[2]
                {
                    new NexusAddress { country = "US", state = "TX", zip = "77057", },
                    new NexusAddress { country = "US", zip = "10801", state = "NY", }
                }
            };

            NexusOrderWithLineItems = new NexusOrder
            {
                from_country = "US",
                from_state = "TX",
                from_zip = "77057",
                to_country = "US",
                to_zip = "10801",
                to_state = "NY",
                amount = 1000,
                shipping = 45,

                line_items = new NexusOrderLineItem[3] {
                    new NexusOrderLineItem() { quantity = 3, unit_price = 150 },
                    new NexusOrderLineItem() { quantity = 5, unit_price = 200 },
                    new NexusOrderLineItem() { quantity = 2, unit_price = 3000 },
                },
                nexus_addresses = new NexusAddress[2]
                {
                    new NexusAddress { country = "US", state = "TX", zip = "77057", },
                    new NexusAddress { country = "US", zip = "10801", state = "NY", }
                }
            };
        }

        [Test]
        public void TaxServiceShouldReturnValueForValidLocation()
        {
            Assert.DoesNotThrowAsync(async () => {
                Assert.That(await _taxService.GetRateAsync("10801"), Is.GreaterThanOrEqualTo(0));
            });
        }

        [Test]
        public void TaxServiceShouldNotReturnValueForInvalidLocation()
        {
            Assert.CatchAsync(async () => await _taxService.GetRateAsync("99999"));
            Assert.CatchAsync(async () => await _taxService.GetRateAsync(""));
            Assert.CatchAsync(async () => await _taxService.GetRateAsync("not a zipcode"));
        }

        [Test]
        public void TaxServiceShouldRejectBlankOrders()
        {
            Assert.CatchAsync(async () => await _taxService.GetTotalTaxAsync(BlankOrder));
        }

        [Test]
        public void TaxServiceShouldRejectBadOrders()
        {
            Assert.CatchAsync(async () => await _taxService.GetTotalTaxAsync(BadOrder));
        }

        [Test]
        public void TaxServiceShouldReturnValueForGoodOrders()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                Assert.That(await _taxService.GetTotalTaxAsync(GoodOrder), Is.GreaterThanOrEqualTo(0));
                Assert.That(await _taxService.GetTotalTaxAsync(NexusOrder), Is.GreaterThanOrEqualTo(0));
            });
        }

        [Test]
        public void GetTotalMethodShouldBeCorrectForSimpleOrders()
        {
            Assert.AreEqual(GoodOrder.amount, GoodOrder.GetTotalBeforeShipping());
            Assert.AreEqual(NexusOrder.amount, NexusOrder.GetTotalBeforeShipping());
        }

        [Test]
        public void GetTotalMethodShouldBeCorrectForOrdersWithLineItems()
        {
            float t = 0;
            foreach(var i in OrderWithLineItems.line_items)
            {
                t += i.unit_price * i.quantity;
            }
            Assert.AreEqual(t, OrderWithLineItems.GetTotalBeforeShipping());

            t = 0;
            foreach (var i in NexusOrderWithLineItems.line_items)
            {
                t += i.unit_price * i.quantity;
            }
            Assert.AreEqual(t, NexusOrderWithLineItems.GetTotalBeforeShipping());
        }
    }
}