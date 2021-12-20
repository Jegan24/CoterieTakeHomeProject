using Microsoft.AspNetCore.Mvc;

namespace CoterieTakeHomeProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {


        private readonly ILogger<QuoteController> _logger;
        private readonly IFactorSource<StateFactor> _stateFactorSource;
        private readonly IFactorSource<BusinessFactor> _businessFactorSource;
        private readonly IFactorSource<HazardFactor> _hazardFactorSource;
        public QuoteController(
            ILogger<QuoteController> logger,
            IFactorSource<StateFactor> stateFactorSource,
            IFactorSource<BusinessFactor> businessFactorSource,
            IFactorSource<HazardFactor> hazardFactorSource)
        {
            _logger = logger;
            _stateFactorSource = stateFactorSource;
            _businessFactorSource = businessFactorSource;
            _hazardFactorSource = hazardFactorSource;
        }

        [HttpPost(Name = "GetQuote")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuoteResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<QuoteResponse> Get(QuoteRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest();
                }

                var premium = GetPremium(request);

                if (premium is null)
                {
                    return NotFound();
                }

                return premium;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.Data);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Given more time, this could be changed to an interface similar to that of <see cref="IFactorSource{T}"/>
        /// to allow different means of calcuating premiums to be injected.
        /// </summary>
        /// <param name="request">The request body.</param>
        /// <returns>An instance of <see cref="QuoteResponse"/> if all factors were found, otherwise null.</returns>
        private QuoteResponse? GetPremium(QuoteRequest request)
        {
            var factors = GetFactors(request);

            // If any factor wasn't found, do not try to calcuate a premium
            if (factors.Any(factor => factor is null))
            {
                return null;
            }

            decimal baseRate = GetBaseRate(request.Revenue);


            return new QuoteResponse()
            {
                // Multiply each factor's value together, then multiply the result by the base rate.
                // 1M represents the initial value, which is 1                
                Premium = factors.Aggregate(1M, (accumulation, factor) => accumulation * factor.Factor) * baseRate
            };
        }

        // Attempts to find all factors needed to compute the premium.
        // Given more time this could be replaced by an Interface that
        // is responsible for finding all factors for a request.
        private IEnumerable<IFactor?> GetFactors(QuoteRequest request)
        {
            return new List<IFactor?>()
            {
                _stateFactorSource.GetFactor(request.State),
                _businessFactorSource.GetFactor(request.Business),
                _hazardFactorSource.GetFactor(string.Empty)
            };
        }

        private static decimal GetBaseRate(decimal revenue) => Math.Ceiling(revenue / 1000M);
    }
}