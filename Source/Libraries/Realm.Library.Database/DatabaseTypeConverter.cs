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
        private readonly BidirectionalDictionary<string, SqlDbType> _typeMap;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseTypeConverter()
        {
            _typeMap = new BidirectionalDictionary<string, SqlDbType>();
            _typeMap.Add("bigint", SqlDbType.BigInt);
            _typeMap.Add("bit", SqlDbType.Bit);
            _typeMap.Add("datetime", SqlDbType.DateTime);
            _typeMap.Add("decimal", SqlDbType.Decimal);
            _typeMap.Add("float", SqlDbType.Float);
            _typeMap.Add("image", SqlDbType.Image);
            _typeMap.Add("int", SqlDbType.Int);
            _typeMap.Add("ntext", SqlDbType.NText);
            _typeMap.Add("real", SqlDbType.Real);
            _typeMap.Add("smallint", SqlDbType.SmallInt);
            _typeMap.Add("tinyint", SqlDbType.TinyInt);
            _typeMap.Add("smallmoney", SqlDbType.SmallMoney);
            _typeMap.Add("text", SqlDbType.Text);
            _typeMap.Add("timestamp", SqlDbType.Timestamp);
            _typeMap.Add("binary", SqlDbType.Binary);
            _typeMap.Add("uniqueidentifier", SqlDbType.UniqueIdentifier);
            _typeMap.Add("varbinary", SqlDbType.VarBinary);
            _typeMap.Add("varchar", SqlDbType.VarChar);
            _typeMap.Add("sql_variant", SqlDbType.Variant);
            _typeMap.Add("money", SqlDbType.Money);
            _typeMap.Add("nchar", SqlDbType.NChar);
            _typeMap.Add("nvarchar", SqlDbType.NVarChar);
            _typeMap.Add("smalldatetime", SqlDbType.SmallDateTime);
            _typeMap.Add("char", SqlDbType.Char);
            _typeMap.Add("real", SqlDbType.Real);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlDbType Get(string type)
        {
            return _typeMap.GetByFirst(type.ToLower()).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string Get(SqlDbType type)
        {
            return _typeMap.GetBySecond(type).FirstOrDefault();
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