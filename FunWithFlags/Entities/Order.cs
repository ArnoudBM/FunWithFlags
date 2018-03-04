namespace FunWithFlags.Entities
{
    using System.Collections.Generic;

    public class Order
    {
        public IList<OrderLine> OrderLines { get; set; }
    }
}
