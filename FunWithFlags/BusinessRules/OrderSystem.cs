namespace FunWithFlags.BusinessRules
{
    using FunWithFlags.Entities;
    using System.Collections.Generic;

    public class OrderSystem
    {
        public Order GetOrder()
        {
            var order = new Order
            {
                OrderLines = new List<OrderLine>
                {
                    CreateOrderLine("Bear", 7.35D, 3),
                    CreateOrderLine("Duck", 6.12D, 1),
                    CreateOrderLine("Sheep", 11.41D, 12),
                    CreateOrderLine("Crocodile", 8.36D, 2),
                    CreateOrderLine("Kangaroo", 11.41D, 4),
                    CreateOrderLine("Baby Kangaroo", 3.41D, 4)
                }
            };
            
            return order;
        }

        private OrderLine CreateOrderLine(string description, double price, int amount)
        {
            return new OrderLine
            {
                Article = CreateArticle(description, price),
                Amount = amount,
                Price = price * amount
            };
        }

        private Article CreateArticle(string description, double price)
        {
            return new Article
            {
                Code = description.PadRight(5, 'x').Substring(0, 5),
                Description = description,
                Price = price
            };
        }
    }
}
