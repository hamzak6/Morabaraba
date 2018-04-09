namespace Morabaraba
{
    /// <summary>
    /// Shoot determiner interface
    /// </summary>
    public interface IShootDeterminer
    {
        /// <summary>
        /// Can the player shoot?
        /// </summary>
        /// <param name="game">The game state</param>
        /// <returns>Whether the player can shoot</returns>
        bool CanShoot(IGame game);
    }
}