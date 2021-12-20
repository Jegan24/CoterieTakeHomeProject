namespace CoterieTakeHomeProject.Classes.FactorSources
{
    /// <summary>
    /// An implementation of <see cref="IFactorSource{T}"/> for <see cref="BusinessFactor"/>.
    /// It is a hard coded/static implementation, and should not be considered a long term solution.
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
        /// Retrieves a <see cref="BusinessFactor"/> for the given business type.
        /// </summary>
        /// <param name="name">Values found in <see cref="Constants.FactorNames"/> will return a corresponding <see cref="BusinessFactor"/>, otherwise null.</param>
        /// <returns>A <see cref="BusinessFactor"/> if found, otherwise null.</returns>
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
