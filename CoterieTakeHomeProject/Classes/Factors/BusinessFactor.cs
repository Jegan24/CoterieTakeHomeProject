namespace CoterieTakeHomeProject.Classes.Factors
{
    /// <summary>
    /// An implementation of <see cref="IFactor"/>, that represents some business type, e.g. plumber, programmer, etc.
    /// </summary>
    public class BusinessFactor : IFactor
    {
        public decimal Factor { get; set; }
        public string Name { get; set; }
        public string Type => Constants.FactorTypes.Business;
    }
}
