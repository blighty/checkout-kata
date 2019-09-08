using System;
using Xunit;
using Kata.Checkout.BusinessLogic;

namespace Kata.Checkout.BusinessLogic.Tests
{
    public class CheckoutTests
    {
        private Checkout checkout = null;

        public CheckoutTests()
        {
            checkout = new Checkout();
        }

        [Fact]
        public void CheckoutShouldScanAnItem()
        {
            checkout.Scan(new Item("A99", 0.50m, null));
            Assert.True(checkout.Total() > 0);   
        }
        
        [Fact]
        public void CheckoutShouldCalculateATotal()
        {
            checkout.Scan(new Item("A99", 0.50m, null));
            checkout.Scan(new Item("B15", 0.30m, null));
            Assert.Equal(0.80m, checkout.Total());
        }
    }
}
