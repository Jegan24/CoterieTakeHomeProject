namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class HazardFactor : IFactor
    {
        public decimal Factor => 4.0M;
        public string Name => "Hazard";
        public string Type => "Hazard";
    }
}
