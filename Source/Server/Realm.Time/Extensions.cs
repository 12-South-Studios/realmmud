using System;
using Realm.Library.Common;
using Realm.Live.DAL.Interfaces;
using Realm.Time.Interfaces;

namespace Realm.Time
{
    public static class Extensions
    {
        public static Globals.Globals.SeasonTypes GetSeason(this ITimeManager manager)
        {
            return manager.CurrentGameState.Month.Season;
        }

        public static void Save(this GameState gameState, IRealmLiveDbContext dbContext)
        {
            try
            {
                var newState = dbContext.GameStates.Create();
                newState.Sessionstart = DateTime.Now;
                newState.Year = gameState.DateTime.Year;
                newState.MonthId = gameState.Month.ID;
                newState.Day = gameState.DateTime.Day;
                newState.Hour = gameState.DateTime.Hour;
                newState.Minute = gameState.DateTime.Minute;
                dbContext.GameStates.Attach(newState);

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }
    }
}
