using CoterieTakeHomeProject.Classes;

namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class StaticBusinessFactorSource : IFactorSource<BusinessFactor>
    {
        private readonly Dictionary<string, BusinessFactor> _factors = new Dictionary<string, BusinessFactor>();

        public StaticBusinessFactorSource()
        {
            var architectFactor = new BusinessFactor()
            {
                Name = Constants.FactorNames.Architect,
                Factor = 1M
            };
            var plumberFactor = new BusinessFactor()
            {
                Name = Constants.FactorNames.Plumber,
                Factor = 0.5M
            };
            var programmerFactor = new BusinessFactor()
            {
                Name = Constants.FactorNames.Programmer,
                Factor = 1.25M
            };
            _factors[architectFactor.Name] = architectFactor;
            _factors[plumberFactor.Name] = plumberFactor;
            _factors[programmerFactor.Name] = programmerFactor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BusinessFactor? GetFactor(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (_factors.ContainsKey(name))
            {
                return _factors[name];
            }
            return null;
        }
    }
}
