namespace Kata.Checkout.BusinessLogic
{
    public class Item
    {

        public Item(string sku, decimal price, Offer offer)
        {
            Sku = sku;
            Price = price;
            Offer = offer;
        }

        public string Sku { get; }

        public Offer Offer { get; }

        private decimal Price { get; }

        public decimal GetPrice(int quantity)
        {
            decimal result = 0m;
            if (Offer != null && quantity >= this.Offer.Quantity) 
            {
                int numOfferPriceItems = quantity / this.Offer.Quantity;
                int numFullPriceItems = quantity % this.Offer.Quantity;
                result = numOfferPriceItems * this.Offer.OfferPrice;
                result += numFullPriceItems * this.Price;
            } 
            else
            {
                result = this.Price * quantity;
            }
            return result;
        }
    }
}