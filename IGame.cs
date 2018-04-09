namespace Morabaraba
{
    /// <summary>
    /// Morabaraba game state
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Morabaraba board state
        /// </summary>
        IBoard Board { get; }
        
        /// <summary>
        /// Get a Morabaraba Dark Player
        /// </summary>
        IPlayer DarkPlayer { get; }
        
        /// <summary>
        /// Get a Morabaraba Light Player
        /// </summary>
        IPlayer LightPlayer { get; }
    }
}