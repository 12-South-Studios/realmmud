using System;
using System.Collections.Generic;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.Edit.Builders;
using Realm.Edit.EditorControls;
using Realm.Edit.Properties;

namespace Realm.Edit.Editor
{
    public static class EditorFactory
    {
        static EditorFactory()
        {
            Builders = new Dictionary<SystemTypes, EditorBuilder>();
        }

        public static Dictionary<SystemTypes, EditorBuilder> Builders { get; private set; }

        public static void RegisterEditor(EditorBuilder value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            if (!Builders.ContainsKey(value.SystemType))
                Builders.Add(value.SystemType, value);
        }

        public static BaseEditorControl Create(SystemTypes systemType, int classId)
        {
            EditorBuilder value;
            return Builders.TryGetValue(systemType, out value) ? value.Create(classId) : null;
        }

        public static EditorBrowseInfo GetBrowseInfo(SystemTypes systemType, int key)
        {
            EditorBuilder value;
            return Builders.TryGetValue(systemType, out value) ? value.GetBrowseInfo(key) : null;
        }

        public static EditorBrowseInfo GetSimpleBrowseInfo(SystemTypes systemType, int id)
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var obj = dbContext.GetPrimitive(systemType, id);
            return obj != null
                ? new EditorBrowseInfo(systemType, "[" + obj.SystemName + "]", obj.SystemClass.Id, obj.Id)
                : null;
        }
    }
}
