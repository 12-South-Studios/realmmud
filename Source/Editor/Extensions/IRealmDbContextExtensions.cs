using System;
using System.Linq;
using Realm.DAL.Enumerations;
using Realm.DAL.Interfaces;
using Realm.DAL.Models;
using Realm.Edit.Editor;

namespace Realm.Edit.Extensions
{
    public static class IRealmDbContextExtensions
    {
        public static int GetBitValue(this IRealmDbContext dbContext, BitTypes bitType, string name)
        {
            var bit =
                dbContext.Bits.Where(x => x.BitType == bitType)
                    .FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return bit == null ? 0 : bit.Value;
        }

        public static bool DoesPrimitiveHaveBit(this IRealmDbContext dbContext, BitTypes bitType, int bitField, string bitName)
        {
            var bits = dbContext.Bits.Where(x => x.BitType == bitType).ToList();
            var bit = bits.FirstOrDefault(x => x.Name.Equals(bitName, StringComparison.OrdinalIgnoreCase));
            if (bit == null) return false;

            return (bitField & bit.Value) != 0;
        }

        public static string GetClassName(this IRealmDbContext dbContext, int classId)
        {
            var obj = dbContext.SystemClasses.FirstOrDefault(x => x.Id == classId);
            return obj != null ? obj.Name : string.Empty;
        }

        public static int GetClassId(this IRealmDbContext dbContext, SystemTypes systemType, string className)
        {
            var obj = dbContext.SystemClasses.Where(x => x.SystemType == systemType)
                .Where(x => x.Name == className);
            return obj.Count() != 1 ? 0 : obj.ToList()[0].Id;
        }

        public static SystemClass GetClass(this IRealmDbContext dbContext, int classId)
        {
            return dbContext.SystemClasses.FirstOrDefault(x => x.Id == classId);
        }

        public static EditorSystemClass GetSystemClass(this IRealmDbContext dbContext, int classId)
        {
            var classList = dbContext.SystemClasses.Where(x => x.ParentClassId == null).ToList();

            var foundClass = classList.Find(x => x.Id == classId);
            if (foundClass == null) return null;

            return new EditorSystemClass
            {
                ClassId = foundClass.Id,
                Name = foundClass.Name,
                SystemType = (int)foundClass.SystemType
            };
        }

        public static SystemTypes GetSystemType(this IRealmDbContext dbContext, int classId)
        {
            return dbContext.GetClass(classId).SystemType;
        }
    }
}
