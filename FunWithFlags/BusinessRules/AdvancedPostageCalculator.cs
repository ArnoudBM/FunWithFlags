namespace FunWithFlags.BusinessRules
{
    using System.Linq;
    using Entities;

    /// <summary>
    /// The calculator for the postage of the order that uses a base postage tariff.
    /// </summary>
    public class AdvancedPostageCalculator : IPostageCalculator
    {
        private const double BasePostage = 1.95D;
        private const double PostagePerItem = 1.0D;

        /// <summary>
        /// Calculates the postage for the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>The postage.</returns>
        public double Calculate(Order order)
        {
            return order?.OrderLines.Sum(l => l.Amount * PostagePerItem) + BasePostage ?? 0;
        }

        public double CalculateUsingNewFormula(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
