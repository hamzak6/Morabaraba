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
        
        /// <summary>
        /// Gets or sets the last played move
        /// </summary>
        Move? LastPlayed { get; set; }
    }
}