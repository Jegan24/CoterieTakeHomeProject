namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// Represents some numeric factor to include when determining the price of a premium.
    /// </summary>
    public interface IFactor
    {
        /// <summary>
        /// The numeric value used when determining the price of a premium.
        /// </summary>
        /// <remarks>
        /// If the value is a percent, divide it by 100, e.g. 125% => 1.25
        /// </remarks>
        public decimal Factor { get; }
        /// <summary>
        /// The name of the factor.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// What the type of factor is, e.g. business, state, hazard etc.
        /// </summary>
        /// <remarks>
        /// Given more time, this would potentially be changed to a class or enum.
        /// </remarks>
        public string Type { get; }
    }
}
