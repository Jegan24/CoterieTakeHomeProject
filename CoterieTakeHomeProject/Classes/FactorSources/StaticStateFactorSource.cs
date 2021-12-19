using CoterieTakeHomeProject.Classes;

namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class StaticStateFactorSource : IFactorSource<StateFactor>
    {
        private readonly Dictionary<string, StateFactor> _factors = new Dictionary<string, StateFactor>();
        public StaticStateFactorSource()
        {
            var ohioFactor = new StateFactor()
            {
                Name = Constants.States.Ohio,
                Factor = 1M
            };
            var floridaFactor = new StateFactor()
            {
                Name = Constants.States.Florida,
                Factor = 1.2M
            };
            var texasFactor = new StateFactor()
            {
                Name = Constants.States.Texas,
                Factor = 0.943M
            };
            _factors[ohioFactor.Name] = ohioFactor;
            _factors[floridaFactor.Name] = floridaFactor;
            _factors[texasFactor.Name] = texasFactor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public StateFactor? GetFactor(string name)
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
