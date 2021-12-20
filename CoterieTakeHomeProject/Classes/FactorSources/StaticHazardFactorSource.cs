namespace CoterieTakeHomeProject.Classes.FactorSources
{
    /// <summary>
    /// An implementation of <see cref="IFactorSource{T}"/> for <see cref="HazardFactor"/>.
    /// </summary>
    public class StaticHazardFactorSource : IFactorSource<HazardFactor>
    {
        /// <summary>
        /// Will always return a default <see cref="HazardFactor"/>
        /// </summary>
        /// <param name="name">Needed only to fulfill the interface</param>
        /// <returns>An instance of the <see cref="HazardFactor"/> class.</returns>
        public HazardFactor? GetFactor(string name) => new HazardFactor();
    }
}
