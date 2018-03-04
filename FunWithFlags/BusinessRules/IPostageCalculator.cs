namespace FunWithFlags.BusinessRules
{
    using Entities;

    /// <summary>
    /// Interface for a postage calculator.
    /// </summary>
    interface IPostageCalculator
    {
        /// <summary>
        /// Calculates the postage for the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>The postage.</returns>
        double Calculate(Order order);

        /// <summary>
        /// Calculates the postage for the specified order using the new formula.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>The postage.</returns>
        /// <remarks>For demonstration purposes only, the final solution does not use this method.</remarks>
        double CalculateUsingNewFormula(Order order);
    }
}
