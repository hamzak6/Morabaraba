namespace Morabaraba
{
    /// <summary>
    /// The Morabaraba Printing interface
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints relevant game information to the user
        /// </summary>
        /// <param name="game">Game state to be printed</param>
        void Print(IGame game);
        
        /// <summary>
        /// Handles an error
        /// </summary>
        /// <param name="error">Description of the error</param>
        void Error(string error);
    }
}