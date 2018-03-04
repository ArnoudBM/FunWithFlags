namespace FunWithFlags.BusinessRules
{
    using System.Linq;
    using Entities;

    /// <summary>
    /// The calculator for the postage of the order
    /// </summary>
    public class PostageCalculator : IPostageCalculator
    {
        private const double PostagePerItem = 2.95D;

        /// <summary>
        /// Calculates the postage for the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>The postage.</returns>
        public double Calculate(Order order)
        {
            return order?.OrderLines.Sum(l => l.Amount * PostagePerItem) ?? 0;
        }

        /// <summary>
        /// Calculates the postage for the specified order using the new formula.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>The postage.</returns>
        /// <remarks>For demonstration purposes only, the final solution does not use this method.</remarks>
        public double CalculateUsingNewFormula(Order order)
        {
            return new AdvancedPostageCalculator().Calculate(order);
        }
    }
}
