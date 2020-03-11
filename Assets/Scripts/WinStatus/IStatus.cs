namespace Game.Arcade1942
{
    /// <summary>
    /// Interface for WinCondition status check.
    /// </summary>
    public interface IStatus
    {
        bool pIsReady { get; set; }
        void Init();
    }
}