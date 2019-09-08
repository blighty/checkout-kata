using System;
using System.Collections.Generic;

namespace Kata.Checkout.BusinessLogic
{
    public class Checkout
    {
        private Dictionary<string, Item> priceList = new Dictionary<string, Item>(){
            {"A99", new Item("A99", 0.50m, new Offer(3, 1.30m))},
            {"B15",  new Item("B15", 0.30m, new Offer(2, 0.45m))},
            {"C40", new Item("C40", 0.60m, null)}
        };

        private Dictionary<string, int> scannedItems = new Dictionary<string, int>();

        public decimal Total()
        {
            decimal result = 0m;
            foreach (KeyValuePair<string, int> item in scannedItems)
            {
                if (priceList.TryGetValue(item.Key, out Item sku)){
                    result += sku.GetPrice(item.Value);    
                }
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
