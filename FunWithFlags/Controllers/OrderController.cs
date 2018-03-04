namespace FunWithFlags.Controllers
{
    using FunWithFlags.BusinessRules;
    using FunWithFlags.Features;
    using FunWithFlags.Models;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        /// <summary>
        /// The order system
        /// </summary>
        private readonly OrderSystem _orderSystem;

        /// <summary>
        /// Returns a view result with the order.
        /// FeatureFlag logic inside the code.
        /// </summary>
        public IActionResult OrderVersion1()
        {
            var order = _orderSystem.GetOrder();
            var postageCalculator = new PostageCalculator();
            var postage = 0D;

            if (NewPostageCalculationFeature.FeatureEnabled)
            {
                // use the new calculation formula to calculate the postage
                postage = postageCalculator.CalculateUsingNewFormula(order);
            }
            else
            {
                // use the existing calculation formula to calculate the postage 
                postage = postageCalculator.Calculate(order);
            }

            return View("order", new OrderViewModel(order, postage));
        }

        private readonly IPostageCalculator _postageCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// FeatureFlag logic outside the code
        /// </summary>
        public OrderController()
        {
            _orderSystem = new OrderSystem();

            // let the feature flag determine which calculator to use
            if (NewPostageCalculationFeature.FeatureEnabled)
            {
                _postageCalculator = new AdvancedPostageCalculator();
            }
            else
            {
                _postageCalculator = new PostageCalculator();
            }
        }

        /// <summary>
        /// Returns a view result with the order.
        /// FeatureFlag logic outside of the code.
        /// </summary>
        public IActionResult OrderVersion2()
        {
            var order = _orderSystem.GetOrder();

            var postage = _postageCalculator.Calculate(order);

            return View("order", new OrderViewModel(order, postage));
        }
    }
}