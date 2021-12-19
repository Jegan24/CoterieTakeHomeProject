namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class StaticHazardFactorSource : IFactorSource<HazardFactor>
    {
        public HazardFactor? GetFactor(string name) => new HazardFactor();
    }
}
