using System;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Time.Interfaces;

namespace Realm.Time
{
    public static class Extensions
    {
        public static Globals.Globals.SeasonTypes GetSeason(this ITimeManager manager)
        {
            return manager.CurrentGameState.Month.Season;
        }

        public static void Save(this GameState gameState)
        {
            try
            {
                gameState.Client.BeginTransaction();

                var args = new DictionaryAtom();
                args.Set("SessionStart", DateTime.Now);
                args.Set("Year", gameState.DateTime.Year);
                args.Set("MonthID", gameState.Month.ID);
                args.Set("Day", gameState.DateTime.Day);
                args.Set("Hour", gameState.DateTime.Hour);
                args.Set("Minute", gameState.DateTime.Minute);

                gameState.Client.AddCommand("live", "game_SaveGameState", args);
                gameState.Client.PerformTransaction(null, null);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }
    }
}
