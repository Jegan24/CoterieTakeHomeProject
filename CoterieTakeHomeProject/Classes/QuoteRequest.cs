namespace CoterieTakeHomeProject.Classes
{
    /// <summary>
    /// Represents the request body of <see cref="QuoteController.Get(QuoteRequest)"/>
    /// </summary>
    public class QuoteRequest
    {
        /// <summary>
        /// The revenue of the potential policy holder.
        /// </summary>
        /// <remarks>
        /// This might be better represented by a decimal.
        /// </remarks>
        public int Revenue { get; set; }
        /// <summary>
        /// The state of the potential policy holder.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The business type of the potential policy holder.
        /// </summary>
        public string Business { get; set; }
    }
}