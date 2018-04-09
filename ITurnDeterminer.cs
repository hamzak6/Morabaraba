namespace Morabaraba
{
    /// <summary>
    /// The turn determining interface
    /// </summary>
    public interface ITurnDeterminer
    {
        /// <summary>
        /// Whose turn is it?
        /// </summary>
        /// <param name="game">The game state</param>
        /// <returns>The colour of the player with the turn</returns>
        Colour WhoseTurn(IGame game);
    }
}