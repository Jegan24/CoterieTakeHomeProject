namespace CoterieTakeHomeProject.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactorSource<T> where T : IFactor
    {
        public T? GetFactor(string name);
    }
}
