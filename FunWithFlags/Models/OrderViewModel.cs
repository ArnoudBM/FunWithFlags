namespace FunWithFlags.Models
{
    using Entities;
    using System.ComponentModel;
    using System.Linq;

    public class OrderViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderViewModel"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="postage">The postage.</param>
        public OrderViewModel(Order order, double postage)
        {
            Order = order;
            Postage = postage;
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the postage fee for the current order.
        /// </summary>
        public double Postage { get; set; }

        /// <summary>
        /// Gets or sets the total price for this order.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        [DisplayName("Total")]
        public double TotalPrice => Order?.OrderLines?.Sum(orderLine => orderLine.Price) ?? 0;

        /// <summary>
        /// Gets or sets the total price including the postage.
        /// </summary>
        /// <value>
        /// The total price with postage.
        /// </value>
        [DisplayName("Payable")]
        public double TotalPriceWithPostage => TotalPrice + Postage;
    }
}
