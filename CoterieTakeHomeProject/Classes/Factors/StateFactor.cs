namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class StateFactor : IFactor
    {
        public decimal Factor { get; set; }
        public string Name { get; set; }
        public string Type => "State";
    }
}
