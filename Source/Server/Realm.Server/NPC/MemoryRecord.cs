using System;

namespace Realm.Server.NPC
{
    /// <summary>
    /// Records a memory for a mobile
    /// </summary>
    public class MemoryRecord
    {
        private const int ExpirationSeconds = 600; // Number of seconds since last change to expire

        #region Variables
        private long _characterId;
        private DateTime _enterTimestamp;
        private DateTime _leaveTimestamp;
        private DateTime _combatTimestamp;
        private int _damageInflicted;
        private int _damageTaken;
        private DateTime _expirationTimestamp;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public long CharacterID
        {
            get { return _characterId; }
            set
            {
                _characterId = value;
                Expires = DateTime.Now;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime TimestampEnter
        {
            get { return _enterTimestamp; }
            set
            {
                _enterTimestamp = value;
                Expires = DateTime.Now;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime TimestampLeave
        {
            get { return _leaveTimestamp; }
            set
            {
                _leaveTimestamp = value;
                Expires = DateTime.Now;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartedCombat
        {
            get { return _combatTimestamp; }
            set
            {
                _combatTimestamp = value;
                Expires = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets and sets the amount of damage taken
        /// </summary>
        public int DamageTaken
        {
            get { return _damageTaken; }
            set
            {
                _damageTaken = value;
                Expires = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets and sets the amount of damage inflicted
        /// </summary>
        public int DamageInflicted
        {
            get { return _damageInflicted; }
            set
            {
                _damageInflicted = value;
                Expires = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets and sets the expiration time of the record
        /// </summary>
        public DateTime Expires
        {
            get { return _expirationTimestamp; }
            private set { _expirationTimestamp = value.AddSeconds(ExpirationSeconds); }
        }
    }
}
