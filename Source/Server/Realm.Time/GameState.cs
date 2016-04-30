using System.Globalization;
using Ninject;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common.Objects;

namespace Realm.Time
{
    public class GameState : Entity
    {
        public MudTime DateTime { get; }
        public Globals.DayStateTypes DayState { get; set; }

        [Inject]
        public IStaticDataManager StaticDataManager { get; set; }

        public GameState(MudTime mudTime) : base(1, "GameState")
        {
            DateTime = mudTime;
            CalculateDayState();
        }

        public MonthDef Month => StaticDataManager.GetStaticData(Globals.SystemTypes.Month, 
            DateTime.Month.ToString(CultureInfo.InvariantCulture)).CastAs<MonthDef>();

        public override string ToString()
        {
            return $"{DateTime.Year}.{Month.ID}.{DateTime.Day} {DateTime.Hour}:{DateTime.Minute}";
        }

        public bool IsDawn => DateTime.Hour == 6 && DateTime.Minute == 0;
        public bool IsSunrise => DateTime.Hour == 7 && DateTime.Minute == 5;
        public bool IsNoon => DateTime.Hour == 12 && DateTime.Minute == 1;
        public bool IsDusk => DateTime.Hour == 17 && DateTime.Minute == 7;
        public bool IsSunset => DateTime.Hour == 18 && DateTime.Minute == 1;

        private void CalculateDayState()
        {
            if (IsDawn)
                DayState = Globals.DayStateTypes.Dawn;
            else if (IsDusk)
                DayState = Globals.DayStateTypes.Dusk;
            else if (DateTime.Hour >= 6 && DateTime.Minute > 0 && DateTime.Hour <= 17 && DateTime.Minute < 7)
                DayState = Globals.DayStateTypes.Daylight;
            else
                DayState = Globals.DayStateTypes.Night;
        }
    }
}
