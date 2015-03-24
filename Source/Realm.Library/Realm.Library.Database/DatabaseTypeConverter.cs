using System.Data.SqlClient;
using System.Linq;
using System.Data;
using Realm.Library.Common.Collections;

namespace Realm.Library.Database
{
    /// <summary>
    /// Convert a base data type to another base data type
    /// </summary>
    /// <remarks>http://msdn.microsoft.com/en-us/library/cc716729.aspx</remarks>
    public class DatabaseTypeConverter
    {
        private readonly BidirectionalDictionary<string, SqlDbType> TypeMap;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseTypeConverter()
        {
            TypeMap = new BidirectionalDictionary<string, SqlDbType>();
            TypeMap.Add("bigint", SqlDbType.BigInt);
            TypeMap.Add("bit", SqlDbType.Bit);
            TypeMap.Add("datetime", SqlDbType.DateTime);
            TypeMap.Add("decimal", SqlDbType.Decimal);
            TypeMap.Add("float", SqlDbType.Float);
            TypeMap.Add("image", SqlDbType.Image);
            TypeMap.Add("int", SqlDbType.Int);
            TypeMap.Add("ntext", SqlDbType.NText);
            TypeMap.Add("real", SqlDbType.Real);
            TypeMap.Add("smallint", SqlDbType.SmallInt);
            TypeMap.Add("tinyint", SqlDbType.TinyInt);
            TypeMap.Add("smallmoney", SqlDbType.SmallMoney);
            TypeMap.Add("text", SqlDbType.Text);
            TypeMap.Add("timestamp", SqlDbType.Timestamp);
            TypeMap.Add("binary", SqlDbType.Binary);
            TypeMap.Add("uniqueidentifier", SqlDbType.UniqueIdentifier);
            TypeMap.Add("varbinary", SqlDbType.VarBinary);
            TypeMap.Add("varchar", SqlDbType.VarChar);
            TypeMap.Add("sql_variant", SqlDbType.Variant);
            TypeMap.Add("money", SqlDbType.Money);
            TypeMap.Add("nchar", SqlDbType.NChar);
            TypeMap.Add("nvarchar", SqlDbType.NVarChar);
            TypeMap.Add("smalldatetime", SqlDbType.SmallDateTime);
            TypeMap.Add("char", SqlDbType.Char);
            TypeMap.Add("real", SqlDbType.Real);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlDbType Get(string type)
        {
            return TypeMap.GetByFirst(type.ToLower()).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string Get(SqlDbType type)
        {
            return TypeMap.GetBySecond(type).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        public DbType GetDbType(string type)
        {
            var parameter = new SqlParameter {SqlDbType = Get(type)};
            return parameter.DbType;
        }

        /// <summary>
        /// 
        /// </summary>
        public DbType GetDbType(SqlDbType type)
        {
            var parameter = new SqlParameter {SqlDbType = type};
            return parameter.DbType;
        }
    }
}