namespace Morabaraba
{
    /// <summary>
    /// The scanning interface
    /// </summary>
    public interface IScanner
    {
        /// <summary>
        /// Scan and parse coordinates input by the user
        /// </summary>
        /// <returns></returns>
        Coordinate[] Scan();
    }
}