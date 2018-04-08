namespace Morabaraba
{
    /// <summary>
    /// A Morabaraba printer
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints relevant game information to the user
        /// </summary>
        void Print();
        
        /// <summary>
        /// Handles an error
        /// </summary>
        /// <param name="error">Description of the error</param>
        void Error(string error);
    }
}