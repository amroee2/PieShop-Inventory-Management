using PieShop.InventoryManagement.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public static class ProductExtension
    {
        static double dollarToEuro = 0.92;
        static double euroToDollar = 1.11;
        static double poundToEuro = 1.14;
        static double euroToPound = 0.88;
        static double dollarToPound = 0.81;
        static double poundToDollar = 1.14;
        public static double ConvertProudctPrice(this Product product, Currency targetCurrency)
        {
            Currency sourceCurreny = product.Price.Currency;
            double originalPrice = product.Price.ItemPrice;
            product.Price.Currency = targetCurrency;
            double convertedPrice = 0;

            if (sourceCurreny == Currency.Dollar && targetCurrency == Currency.Euro)
            {
                convertedPrice = originalPrice * dollarToEuro;
            }
            else if (sourceCurreny == Currency.Euro && targetCurrency == Currency.Dollar)
            {
                convertedPrice = originalPrice * euroToDollar;
            }
            else if (sourceCurreny == Currency.Pound && targetCurrency == Currency.Euro)
            {
                convertedPrice = originalPrice * poundToEuro;
            }
            else if (sourceCurreny == Currency.Euro && targetCurrency == Currency.Pound)
            {
                convertedPrice = originalPrice * euroToPound;
            }
            else if (sourceCurreny == Currency.Dollar && targetCurrency == Currency.Pound)
            {
                convertedPrice = originalPrice * dollarToPound;
            }
            else if (sourceCurreny == Currency.Pound && targetCurrency == Currency.Dollar)
            {
                convertedPrice = originalPrice * poundToDollar;
            }
            else
            {
                convertedPrice = originalPrice;
            }
            return convertedPrice;
        }
    }
}
