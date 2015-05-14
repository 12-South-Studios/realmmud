using System;
using System.Globalization;
using Ninject;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common;

namespace Realm.Time
{
    public class GameState : Entity
    {
        public MudTime DateTime { get; set; }
        public Globals.Globals.DayStateTypes DayState { get; set; }

        [Inject]
        public IStaticDataManager StaticDataManager { get; set; }

        public GameState(MudTime mudTime) : base(1, "GameState")
        {
            DateTime = mudTime;
            CalculateDayState();
        }

        public MonthDef Month 
        {
            get
            {
                return StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Month, 
                    DateTime.Month.ToString(CultureInfo.InvariantCulture)).CastAs<MonthDef>();
            }
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2} {3}:{4}", DateTime.Year, Month.ID, DateTime.Day, DateTime.Hour,
                DateTime.Minute);
        }

        public bool IsDawn { get { return DateTime.Hour == 6 && DateTime.Minute == 0; } }
        public bool IsSunrise { get { return DateTime.Hour == 7 && DateTime.Minute == 5; } }
        public bool IsNoon { get { return DateTime.Hour == 12 && DateTime.Minute == 1; } }
        public bool IsDusk { get { return DateTime.Hour == 17 && DateTime.Minute == 7; } }
        public bool IsSunset { get { return DateTime.Hour == 18 && DateTime.Minute == 1; } }

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
