namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessFactor : IFactor
    {
        public decimal Factor { get; set; }
        public string Name { get; set; }
        public string Type => "Business";
    }
}
