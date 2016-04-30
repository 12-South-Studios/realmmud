using System;
using System.Configuration;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Server.Properties;

namespace Realm.Server.Extensions

{
    // ReSharper disable CSharpWarnings::CS1591
    public static class GameExtensions
    // ReSharper restore CSharpWarnings::CS1591
    {
        /// <summary>
        /// Gets the current user for the game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        /*public static GameUser CurrentUser(this IGame game)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNull(game.Properties, "game.Properties");

            return game.Properties.GetProperty<GameUser>("current user");
        }

        public static T GetProperty<T>(this IGame game, string name)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNull(game.Properties, "game.Properties");
            Validation.IsNotNullOrEmpty(name, "name");

            return game.Properties.GetProperty<T>(name);
        }

        public static void SetProperty(this IGame game, string name, object value, PropertyTypeOptions bits = PropertyTypeOptions.None)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNull(game.Properties, "game.Properties");
            Validation.IsNotNullOrEmpty(name, "name");

            game.Properties.SetProperty(name, value, bits);
        }*/

        /// <summary>
        /// Creates an item instance using the given template and adds it to the given location
        /// </summary>
        /*public static ItemInstance CreateAndPlaceItemInstance(this IGame game, IEntityManager entityManager,
                                                              ILog log, IGameEntity location, ItemTemplate template)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNull(entityManager, "entityManager");
            Validation.IsNotNull(log, "log");
            Validation.IsNotNull(location, "location");
            Validation.IsNotNull(template, "template");

            var factory = new GameItemFactory();
            var instance = factory.CreateInstance(string.Empty, template) as ItemInstance;
            game.SetManagerReferences(instance);
            location.AddEntity(instance);
            return instance;
        }*/

        /// <summary>
        /// Creates an item instance using the given template
        /// </summary>
        /*public static ItemInstance CreateItemInstance(this IGame game, IEntityManager entityManager, ILog log, ItemTemplate template)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNull(entityManager, "entityManager");
            Validation.IsNotNull(log, "log");
            Validation.IsNotNull(template, "template");

            var factory = new GameItemFactory();
            var instance = factory.CreateInstance(string.Empty, template) as ItemInstance;
            game.SetManagerReferences(instance);
            return instance;
        }*/

        /// <summary>
        /// Gets a integer property from the AppSettings section of App.config
        /// </summary>
        public static int? GetIntConstant(this IGame game, string name)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNullOrEmpty(name, "name");

            try
            {
                if (game.HasGameConstantKey(name))
                    return Convert.ToInt32(ConfigurationManager.AppSettings[name]);
            }
            catch (FormatException ex)
            {
                ex.Handle<GeneralException>(ExceptionHandlingOptions.RecordOnly, null,
                    ErrorResources.ERR_APP_SETTING_NOT_FOUND, name);
            }
            catch (Exception ex)
            {
                ex.Handle<GeneralException>(ExceptionHandlingOptions.RecordAndThrow, null, ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets a string property from the AppSettings section of App.config
        /// </summary>
        public static string GetStringConstant(this IGame game, string name)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNullOrEmpty(name, "name");

            try
            {
                if (game.HasGameConstantKey(name))
                    return ConfigurationManager.AppSettings[name];
            }
            catch (FormatException ex)
            {
                ex.Handle<GeneralException>(ExceptionHandlingOptions.RecordOnly, null,
                    ErrorResources.ERR_APP_SETTING_NOT_FOUND, name);
            }
            catch (Exception ex)
            {
                ex.Handle<GeneralException>(ExceptionHandlingOptions.RecordAndThrow, null, ex.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// Determines if the given setting is present in the AppSettings of App.config
        /// </summary>
        public static bool HasGameConstantKey(this IGame game, string name)
        {
            Validation.IsNotNull(game, "game");
            Validation.IsNotNullOrEmpty(name, "name");

            return ConfigurationManager.AppSettings.Keys.Cast<object>().Contains(name);
        }
    }
}
