namespace Game.Arcade1942
{
    /// <summary>
    /// Objects with Health extend the Ihealth
    /// The bullet hitting an object searching for Ihealth and send its damange value through the TakeDamage method
    /// </summary>
    public interface IHealth
    {

        void TakeDamage(float value);
        void OnHealthDepleted();
    }
}

