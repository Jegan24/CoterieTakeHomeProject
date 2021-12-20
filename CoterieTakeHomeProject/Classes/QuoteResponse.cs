namespace CoterieTakeHomeProject.Classes
{
    /// <summary>
    /// This is the object returned by <see cref="QuoteController.Get(QuoteRequest)"/>
    /// </summary>
    public class QuoteResponse
    {
        /// <summary>
        /// The price of the premium.
        /// </summary>        
        public decimal Premium { get; set; }
    }
}