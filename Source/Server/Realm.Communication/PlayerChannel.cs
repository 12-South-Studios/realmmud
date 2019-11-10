namespace Realm.Communication
{
    /// <summary>
    /// Handles the tracking of channel data for a player character
    /// </summary>
    public class PlayerChannel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PlayerChannel(long id, bool isOn, string handle)
        {
            Id = id;
            IsOn = isOn;
            Handle = handle;
        }

        /// <summary>
        /// ID of the channel
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Alias to the channel
        /// </summary>
        public string Handle { get; }

        /// <summary>
        /// Status of the channel
        /// </summary>
        public bool IsOn { get; }
    }
}