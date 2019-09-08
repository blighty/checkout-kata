namespace Kata.Checkout.BusinessLogic 
{
    public class Offer 
    {
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }

        public Offer(int quantity, decimal offerPrice)
        {
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
    }
}