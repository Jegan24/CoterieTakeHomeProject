namespace CoterieTakeHomeProject.Classes.Factors
{
    /// <summary>
    /// An implementation of <see cref="IFactor"/> that represents a state within the USA.
    /// </summary>
    public class StateFactor : IFactor
    {
        public decimal Factor { get; set; }
        public string Name { get; set; }
        public string Type => "State";
    }
}
