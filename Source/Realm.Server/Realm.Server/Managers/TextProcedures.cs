using System.Data;
using System.Text;
using Realm.Library.Database;

#if SQLLITE
using System.Data.SQLite;
#else
using System.Data.SqlClient;
#endif

namespace Realm.Server.Managers
{
    public static class TextProcedures
    {
/*        public static IProcedure GetChannels()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection,
                                                          Game.Instance.Logger, "GetChannels")
                           { CommandText = "Select ChannelID, OwnerID FROM Channels ORDER BY ChannelID;" };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection,
                                                          Game.Instance.Logger, "GetChannels")
                           { CommandText = "Select ChannelID, OwnerID FROM Channels ORDER BY ChannelID;" };
#endif
            return proc;
        }

        public static IProcedure GetUserProperties()
        {
            var sb = new StringBuilder();
            sb.Append("select upm.PropertyID, p.Name, upm.Value FROM UserPropertyMap upm ");
            sb.Append("JOIN Properties p ON p.PropertyID = upm.PropertyID ");
            sb.Append("where upm.UserID = @UserId and Active = 0");

#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetUserProperties") { CommandText = sb.ToString() };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetUserProperties") { CommandText = sb.ToString() };
#endif
            proc.AddParameter("@UserId", DbType.Int32);
            return proc;
        }

        public static IProcedure GetUser()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetUser") { CommandText = "select UserID, PreHashID, PostHashID, " + 
                "Password from Users where DeletedOn is null and Username = @Username" };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetUser") { CommandText = "select UserID, PreHashID, PostHashID, " + 
                "Password from Users where DeletedOn is not null and Username = @Username" };
#endif

            proc.AddParameter("@Username", DbType.String);
            return proc;
        }

        public static IProcedure ValidateUser()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "ValidateUser") { CommandText = "select UserID from Users " + 
                "where Username = @Username and Password = @Password" };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "ValidateUser") { CommandText = "select UserID from Users " + 
                "where Username = @Username and Password = @Password" };
#endif

            proc.AddParameter("@Username", DbType.String);
            proc.AddParameter("@Password", DbType.String);
            return proc;
        }

        public static IProcedure LoginUser()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "LoginUser") { CommandText = "insert into UserLoginMap " + 
                "(UserID, LoginDate, IPAddress) VALUES (@UserId, @now, @ipAddress);" };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "LoginUser") { CommandText = "insert into UserLoginMap " + 
                "(UserID, LoginDate, IPAddress) VALUES (@UserId, @now, @ipAddress);" };
#endif

            proc.AddParameter("@UserId", DbType.Int32);
            proc.AddParameter("@now", DbType.DateTime);
            proc.AddParameter("@ipAddress", DbType.String);
            return proc;
        }

        public static IProcedure InsertNewID()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "InsertNewID") { CommandText = "insert into GeneratedIDs " + 
                "(CreatedOn, Type) VALUES (@CreatedOn, @Type);" };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "InsertNewID") { CommandText = "insert into GeneratedIDs " + 
                "(CreatedOn, Type) VALUES (@CreatedOn, @Type);" };
#endif

            proc.AddParameter("@CreatedOn", DbType.DateTime);
            proc.AddParameter("@Type", DbType.Int32);
            return proc;
        }

        public static IProcedure GetNewID()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetNewID") { CommandText = "select max(ID) from GeneratedIDs;" };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetNewID") { CommandText = "select max(ID) from GeneratedIDs;" };
#endif

            return proc;   
        }

        public static IProcedure GetCharacters()
        {
            var sb = new StringBuilder();
            sb.Append("SELECT ucm.CharacterID, c.Name, c.LocationID, ucm.LastLoginDate,");
            sb.Append(
                " (SELECT Value FROM CharacterPropertyMap WHERE CharacterID = c.CharacterID AND PropertyID = 10) AS Level, ");
            sb.Append(
                " (SELECT Value FROM CharacterPropertyMap WHERE CharacterID = c.CharacterID AND PropertyID = 19) AS Archetype, ");
            sb.Append(
                " (SELECT Value FROM CharacterPropertyMap WHERE CharacterID = c.CharacterID AND PropertyID = 20) AS Gender, ");
            sb.Append(
                " (SELECT Value FROM CharacterPropertyMap WHERE CharacterID = c.CharacterID AND PropertyID = 18) AS Race ");
            sb.Append("FROM UserCharacterMap ucm ");
            sb.Append("JOIN Characters c ON c.CharacterID = ucm.CharacterID ");
            sb.Append("WHERE ucm.UserID = @UserId AND c.DeletedOn IS NULL ");
            sb.Append("ORDER BY c.Name;");

#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection,
                Game.Instance.Logger, "GetCharacters") { CommandText = sb.ToString() };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetCharacters") { CommandText = sb.ToString() };
#endif

            proc.AddParameter("@UserId", DbType.Int32);
            return proc;
        }

        public static IProcedure GetCharacterChannels()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection,
                                                          Game.Instance.Logger, "GetCharacterChannels")
            {
                CommandText =
                    "SELECT ChannelID, StatusOn, Handle FROM CharacterChannelMap WHERE CharacterID = @CharacterId;"
            };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection,
                                                          Game.Instance.Logger, "GetCharacterChannels")
            {
                CommandText =
                    "SELECT ChannelID, StatusOn, Handle FROM CharacterChannelMap WHERE CharacterID = @CharacterId;"
            };
#endif

            proc.AddParameter("@CharacterId", DbType.Int32);
            return proc;
        }

        public static IProcedure GetCharacterFlags()
        {
#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection,
                                                          Game.Instance.Logger, "GetCharacterFlags")
                           {CommandText = "SELECT Flag FROM CharacterFlagMap WHERE CharacterID = @CharacterId;"};
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection,
                                                          Game.Instance.Logger, "GetCharacterFlags")
                           {CommandText = "SELECT Flag FROM CharacterFlagMap WHERE CharacterID = @CharacterId;"};
#endif

            proc.AddParameter("@CharacterId", DbType.Int32);
            return proc;
        }

        public static IProcedure GetCharacterProperties()
        {
            var sb = new StringBuilder();
            sb.Append("SELECT cpm.PropertyID, p.Name, cpm.Value FROM CharacterPropertyMap cpm ");
            sb.Append("JOIN Properties p ON p.PropertyID = cpm.PropertyID ");
            sb.Append("where cpm.CharacterID = @CharacterId and Active = 0");

#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection,
                Game.Instance.Logger, "GetCharacterProperties") { CommandText = sb.ToString() };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetUserPropertyMap") { CommandText = sb.ToString() };
#endif
            proc.AddParameter("@CharacterId", DbType.Int32);
            return proc;
        }

        public static IProcedure GetCharacterInventory()
        {
            var sb = new StringBuilder();
            sb.Append(
                "SELECT ItemID, Quantity, EquipLocation, ContainedInID FROM CharacterInventory WHERE CharacterID = @CharacterId");

#if SQLLITE
            var proc = new TextProcedure<SQLiteParameter>(DatabaseManager.Instance.Connection,
                Game.Instance.Logger, "GetCharacterInventory") { CommandText = sb.ToString() };
#else
            var proc = new TextProcedure<SqlParameter>(OldDatabaseManager.Instance.Connection, 
                Game.Instance.Logger, "GetCharacterInventory") { CommandText = sb.ToString() };
#endif
            proc.AddParameter("@CharacterId", DbType.Int32);
            return proc;
        }*/
    }
}
