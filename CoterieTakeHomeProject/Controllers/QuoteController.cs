using CoterieTakeHomeProject.Classes;
using CoterieTakeHomeProject.Interfaces;
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

        private QuoteResponse? GetPremium(QuoteRequest request)
        {
            var factors = GetFactors(request);

            if (factors.Any(factor => factor is null))
            {
                return null;
            }

            decimal baseRate = GetBaseRate(request.Revenue);

            return new QuoteResponse()
            {
                Premium = factors.Aggregate(1M, (accumulation, factor) => accumulation * factor.Factor) * baseRate
            };
        }
        private IEnumerable<IFactor?> GetFactors(QuoteRequest request)
        {
            return new List<IFactor?>()
            {
                _stateFactorSource.GetFactor(request.State),
                _businessFactorSource.GetFactor(request.Business),
                _hazardFactorSource.GetFactor(Constants.FactorTypes.Hazard)
            };
        }

        private decimal GetBaseRate(decimal revenue) => Math.Ceiling(revenue / 1000M);
    }
}