using System;
using System.Collections.Generic;

namespace Backend.Mock
{
    public static class ProductRepository
    {
        public enum Option { WithNoItem, WithLessThenPageSize, WithMoreThanPageSize }

        public static IEnumerable<MockProduct> GetProducts(Option option)
        {
            return GetMockProducts(option);
        }

        private static List<MockProduct> GetMockProducts(Option option)
        {
            var products = new List<MockProduct>();
            switch (option)
            {
                case Option.WithNoItem: { products = new List<MockProduct>(); break; }
                case Option.WithLessThenPageSize: { products = CreateProducts(8); break; }
                case Option.WithMoreThanPageSize: { products = CreateProducts(15); break; }
            }
            return products;
        }

        private static List<MockProduct> CreateProducts(int count)
        {
            List<MockProduct> products = new List<MockProduct>();
            for (int i = 0; i < count; i++)
            {
                products.Add(new MockProduct().CreateMockProduct(i));
            }
            return products;
        }

        private static MockProduct CreateMockProduct(this MockProduct product, int variable)
        {
            product.Id = variable;
            product.Name = Guid.NewGuid().ToString("N").Substring(0, 8);
            product.Price = variable * 10;
            product.Quantity = variable * 0.5;
            return product;
        }

    }
}