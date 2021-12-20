namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// Objects that implement this interface provide a means
    /// to retrieve an <see cref="IFactor"/> by name. This could be
    /// done in multiple ways, e.g. a database access, external APIs,
    /// reading a file, hard coded etc.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="IFactor"/> the source is for.</typeparam>
    public interface IFactorSource<T> where T : IFactor
    {
        /// <summary>
        /// Returns an <see cref="IFactor"/> with the provided name.
        /// </summary>
        /// <param name="name">The name of the factor to retrieve.</param>
        /// <returns>An <see cref="IFactor"/> with the provided name, or null if not found.</returns>
        public T? GetFactor(string name);
    }
}
