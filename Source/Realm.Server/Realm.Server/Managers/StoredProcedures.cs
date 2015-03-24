using System.Data;
using Realm.Library.Database;
using System.Data.SqlClient;

namespace Realm.Server.Managers
{
    public class StoredProcedures
    {
/*        public static IProcedure sp_GetHash()
        {
            return new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_GetHash");
        }

        public static IProcedure sp_CreateUser()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_CreateUser");
            sproc.AddParameter("@username", DbType.String);
            sproc.AddParameter("@preHashId", DbType.Int32);
            sproc.AddParameter("@postHashId", DbType.Int32);
            sproc.AddParameter("@password", DbType.String);
            return sproc;
        }

        public static IProcedure sp_GetUser()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_GetUser");
            sproc.AddParameter("@username", DbType.String);
            return sproc;
        }

        public static IProcedure sp_ValidateUser()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_ValidateUser");
            sproc.AddParameter("@username", DbType.String);
            sproc.AddParameter("@password", DbType.String);
            return sproc;
        }

        public static IProcedure sp_LoginUser()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_LoginUser");
            sproc.AddParameter("@userId", DbType.Int32);
            sproc.AddParameter("@ipAddress", DbType.String);
            return sproc;
        }

        public static IProcedure sp_ChangePassword()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_ChangePassword");
            sproc.AddParameter("@userId", DbType.Int32);
            sproc.AddParameter("@oldPassword", DbType.String);
            sproc.AddParameter("@newPassword", DbType.String);
            sproc.AddParameter("@preHashId", DbType.Int32);
            sproc.AddParameter("@postHashId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_DeleteUser()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_DeleteUser");
            sproc.AddParameter("@userId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_GetUserProperties()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_GetUserProperties");
            sproc.AddParameter("@userId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_UpdateUserProperty()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_UpdateUserProperty");
            sproc.AddParameter("@userId", DbType.Int32);
            sproc.AddParameter("@propertyId", DbType.Int32);
            sproc.AddParameter("@value", DbType.String);
            sproc.AddParameter("@active", DbType.Boolean);
            return sproc;
        }

        public static IProcedure sp_GetCharacters()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_GetCharacters");
            sproc.AddParameter("@userId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_CreateCharacter()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_CreateCharacter");
            sproc.AddParameter("@userId", DbType.Int32);
            sproc.AddParameter("@name", DbType.String);
            return sproc;
        }

        public static IProcedure sp_UpdateCharacter()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_UpdateCharacter");
            sproc.AddParameter("@characterId", DbType.Int32);
            sproc.AddParameter("@locationId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_DeleteCharacter()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger, "sp_DeleteCharacter");
            sproc.AddParameter("@characterId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_GetCharacterProperties()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger,
                                            "sp_GetCharacterProperties");
            sproc.AddParameter("@characterId", DbType.Int32);
            return sproc;
        }

        public static IProcedure sp_UpdateCharacterProperty()
        {
            var sproc = new StoredProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, Game.Instance.Logger,
                                            "sp_UpdateCharacterProperty");
            sproc.AddParameter("@characterId", DbType.Int32);
            sproc.AddParameter("@propertyId", DbType.Int32);
            sproc.AddParameter("@value", DbType.String);
            sproc.AddParameter("@active", DbType.Boolean);
            return sproc;
        }*/
    }
}
