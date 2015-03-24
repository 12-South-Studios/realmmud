using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ninject;
using Realm.Edit.Properties;
using Realm.Edit.Tags;

namespace Realm.Edit.Extensions
{
    public static class ComboBoxExtensions
    {
        public static void Fill<T>(this ComboBox comboBox, int selectedId = 0)
        {
            var baseType = typeof (T).BaseType;
            if (baseType != null && baseType.Name != "Enum") return;

            foreach (var value in Enum.GetValues(typeof (T)))
                comboBox.Items.Add(value);

            comboBox.SelectedIndex = selectedId;
        }

        public static void Fill(this ComboBox value, string tableName, string idColumn,
            int selectedId)
        {
           /* IGeneralDal generalDal = Program.NinjectKernel.Get<IGeneralDal>();
            IEnumerable<RefTable> refTables = generalDal.GetRefData(tableName, idColumn);

            value.BeginUpdate();
            value.Items.Clear();

            var selectedIndex = 0;
            foreach (var obj in refTables)
            {
                var index = value.Items.Add(new TagInfo(obj.Name, obj.Id, 0));
                if (obj.Id == selectedId)
                    selectedIndex = index;
            }

            if (value.Items.Count > 0)
                value.SelectedIndex = selectedIndex;

            value.EndUpdate();*/
        }

        /*public static void Fill(this ComboBox value, IEnumerable<SimpleObject> simpleObjects, int selectedId = -1)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);
            if (simpleObjects == null)
                throw new ArgumentNullException("simpleObjects", Resources.NullParameterErrorMessage);

            value.BeginUpdate();
            value.Items.Clear();

            var selectedIndex = 0;
            foreach (var obj in simpleObjects)
            {
                var index = value.Items.Add(new TagInfo(obj.SystemName, obj.Id, 0));
                if (obj.Id == selectedId)
                    selectedIndex = index;
            }

            //if (value.Items.Count > 0 && selectedIndex > -1)
            //    value.SelectedIndex = selectedIndex;

            value.EndUpdate();
        }*/

        public static int GetContentId(this ComboBox value)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);

            var selectedItem = value.SelectedItem;
            if (selectedItem == null) return 0;

            var tagInfo = selectedItem as TagInfo;
            return tagInfo == null ? 0 : tagInfo.Id;
        }

        /// <summary>
        /// Fill a combobox with the tags for a category, and optionally select a specified tag 
        /// If nullEntryName is non-empty, then a NULL tag will be added
        /// </summary>
        public static void Fill(this ComboBox value, string categoryName, int selectTag, string nullEntryName)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);
            if (String.IsNullOrEmpty(categoryName))
                throw new ArgumentNullException("categoryName", Resources.NullParameterErrorMessage);
            if (nullEntryName == null)
                throw new ArgumentNullException("nullEntryName", Resources.NullParameterErrorMessage);

            value.BeginUpdate();
            value.Items.Clear();

            if (nullEntryName.Length > 0)
            {
                var sysTag = new SystemTag(0, nullEntryName);
                int index = value.Items.Add(sysTag);
                if (sysTag.Id == selectTag)
                    value.SelectedIndex = index;
            }

            var categoryTags = SystemTags.GetTagSet(categoryName);
            foreach (var sysTag in categoryTags.Tags.Values)
            {
                var index = value.Items.Add(sysTag);
                if (sysTag.Id == selectTag)
                    value.SelectedIndex = index;
            }

            if (value.SelectedIndex == -1 && value.Items.Count > 0)
                value.SelectedIndex = 0;

            value.EndUpdate();
        }

        /*public static void fillComboFlags(ComboBox value, string aSystemName, int aSelectedFlagId )
        {
            value.BeginUpdate();
            value.Items.Clear();

            int selectedIndex = 0;
            FlagSet flagSet = SystemFlags.getFlagSet(aSystemName);
            foreach (Flag flag in flagSet.Flags.Values)
            {
                int index = value.Items.Add(new TagInfo(flag.Name, flag.Value, 0));
                if (flag.Value == aSelectedFlagId)
                    selectedIndex = index;
            }

            if (value.Items.Count > 0)
                value.SelectedIndex = selectedIndex;

            value.EndUpdate();
        }*/
    }
}
