namespace Morabaraba
{
    /// <summary>
    /// Determines Morabaraba moves
    /// </summary>
    public interface IMoveDeterminer
    {
        /// <summary>
        /// Gets the current move
        /// </summary>
        Move CurrentMove { get; }
        
        /// <summary>
        /// Gets the next move
        /// </summary>
        Move NextMove { get; }

        /// <summary>
        /// Transition the moves
        /// </summary>
        void Transition();
    }
}