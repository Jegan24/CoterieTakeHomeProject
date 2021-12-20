namespace CoterieTakeHomeProject.Classes.Factors
{
    /// <summary>
    /// A read only implementation of <see cref="IFactor"/>, in the future this
    /// may need to be changed to allow different values.
    /// </summary>
    public class HazardFactor : IFactor
    {
        public decimal Factor => 4.0M;
        public string Name => Constants.FactorTypes.Hazard;
        public string Type => Constants.FactorTypes.Hazard;
    }
}
