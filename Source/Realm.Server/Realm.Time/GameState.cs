using System;
using System.Globalization;
using Ninject;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Database.Framework;

namespace Realm.Time
{
    /// <summary>
    /// 
    /// </summary>
    public class GameState : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mudTime"></param>
        public GameState(MudTime mudTime)
            : base(1, "GameState")
        {
            DateTime = mudTime;
            CalculateDayState();
        }

        ~GameState()
        {
            if (Client != null)
                Client.Dispose();
        }

        [Inject]
        public IStaticDataManager StaticDataManager { get; set; }

        [Inject]
        public IDatabaseManager DatabaseManager 
        { 
            get { return _dbManager; }
            set
            {
                _dbManager = value;
                if (Client == null)
                    Client = new DatabaseClient(this, value as IDatabaseLoadBalancer);
            } 
        }
        private IDatabaseManager _dbManager;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseClient Client { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public MonthDef Month 
        {
            get
            {
                return StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Month, 
                    DateTime.Month.ToString(CultureInfo.InvariantCulture)).CastAs<MonthDef>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MudTime DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Globals.Globals.DayStateTypes DayState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}.{1}.{2} {3}:{4}", DateTime.Year, Month.ID, DateTime.Day, DateTime.Hour,
                DateTime.Minute);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDawn { get { return DateTime.Hour == 6 && DateTime.Minute == 0; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSunrise { get { return DateTime.Hour == 7 && DateTime.Minute == 5; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNoon { get { return DateTime.Hour == 12 && DateTime.Minute == 1; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDusk { get { return DateTime.Hour == 17 && DateTime.Minute == 7; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSunset { get { return DateTime.Hour == 18 && DateTime.Minute == 1; } }

        /// <summary>
        /// 
        /// </summary>
        private void CalculateDayState()
        {
            if (IsDawn)
                DayState = Globals.Globals.DayStateTypes.Dawn;
            else if (IsDusk)
                DayState = Globals.Globals.DayStateTypes.Dusk;
            else if ((DateTime.Hour >= 6 && DateTime.Minute > 0) && (DateTime.Hour <= 17 && DateTime.Minute < 7))
                DayState = Globals.Globals.DayStateTypes.Daylight;
            else
                DayState = Globals.Globals.DayStateTypes.Night;
        }
    }
}
