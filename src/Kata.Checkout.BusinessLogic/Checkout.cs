using System;
using System.Collections.Generic;

namespace Kata.Checkout.BusinessLogic
{
    public class Checkout
    {
        private Dictionary<string, decimal> priceList = new Dictionary<string, decimal>(){
            {"A99", 0.50m},
            {"B15", 0.30m},
            {"C40", 0.60m}
        };
        private Dictionary<string, int> scannedItems = new Dictionary<string, int>();

        public decimal Total()
        {
            decimal result = 0m;
            foreach (KeyValuePair<string, int> item in scannedItems)
            {
                if (priceList.TryGetValue(item.Key, out decimal itemPrice) == false){
                    itemPrice = 0;
                }
                result += (itemPrice * item.Value);
            }
            return result;
        }

        public void Scan(Item item)
        {
            if (scannedItems.ContainsKey(item.Sku))
            {
                scannedItems[item.Sku] ++;
            }
            else
            {
                scannedItems.Add(item.Sku, 1);
            }
        }
    }
}
