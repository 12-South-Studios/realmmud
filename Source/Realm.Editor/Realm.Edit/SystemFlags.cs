using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Realm.Edit
{
    /// <summary>
    /// 
    /// </summary>
    public class Flag
    {
        private int mValue;
        private string mName;
        private string mDescription;
        private string mUniqueGroup;

        public Flag(int aValue, string aName, string aDescription, string aUniqueGroup)
        {
            mValue = aValue;
            mName = aName;
            mDescription = aDescription;
            mUniqueGroup = aUniqueGroup;
        }

        public int Value
        {
            get { return mValue; }
        }

        public string Name
        {
            get { return mName; }
        }

        public string Description
        {
            get { return mDescription; }
        }

        public string UniqueGroup
        {
            get { return mUniqueGroup; }
        }

        // override ToString() function
        public override string ToString()
        {
            return this.Name;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FlagSet
    {
        private Dictionary<string, Flag> mFlags = new Dictionary<string, Flag>();
        private Dictionary<int, Flag> mFlagsById = new Dictionary<int, Flag>();
        private int mSystemId;
        private string mName;

        public FlagSet(int aSystemId, string aName)
        {
            mSystemId = aSystemId;
            mName = aName;

            DataView viewFlags = Database.createView("ref_flag");
            viewFlags.RowFilter = "ref_flag_system_id = " + aSystemId;
            foreach (DataRowView row in viewFlags)
            {
                string name = row["name"].ToString().Trim();
                int flagValue = (int)row["value"];
                string group = string.Empty;
                if (!row.Row.IsNull("unique_group") )
                    group = row["unique_group"].ToString();

                Flag flag = new Flag(flagValue, name, row["description"].ToString(), group);
                mFlags.Add( name, flag);
                mFlagsById.Add(flagValue, flag);
            }
        }

        public Flag getFlag( string aName )
        {
            return mFlags[aName];
        }

        public Flag getFlag(int aValue)
        {
            return mFlagsById[aValue];
        }

        public Dictionary<int, Flag> Flags
        {
            get {  return mFlagsById; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class SystemFlags
    {
        private static Dictionary<string, FlagSet> mFlagSets = new Dictionary<string, FlagSet>();

        static SystemFlags()
        {
        }

        public static void init()
        {
            mFlagSets.Clear();
            DataView viewFlagSystem = Database.createView("ref_flag_system");
            if (Program.MainForm != null)
            {
                Program.MainForm.progressStatus.Minimum = 0;
                Program.MainForm.progressStatus.Maximum = viewFlagSystem.Count;
                Program.MainForm.progressStatus.Value = 0;
            }

            foreach (DataRowView rowSys in viewFlagSystem)
            {
                string name = rowSys["name"].ToString().Trim();
                FlagSet flagSet = new FlagSet((int)rowSys["ref_flag_system_id"], name);
                mFlagSets.Add(name, flagSet);

                Application.DoEvents();
                if (Program.MainForm != null)
                {
                    Program.MainForm.progressStatus.Value++;
                    Program.MainForm.SetStatusMessage("Loading Flag System [" + name + "]");
               }
            }
            Logger.Instance.Log(viewFlagSystem.Count + " flag systems loaded.");
        }

        public static FlagSet getFlagSet( string aSystemName )
        {
            return mFlagSets[aSystemName];
        }

        public static Flag getFlag( string aSystemName, string aFlagName )
        {
            return mFlagSets[aSystemName].getFlag(aFlagName);
        }

        public static Flag getFlag(string aSystemName, int aFlagValue)
        {
            return mFlagSets[aSystemName].getFlag(aFlagValue);
        }
    }
}
