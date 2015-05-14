namespace Realm.Edit.Extensions
{
    public static class ListBoxExtensions
    {
        /*public static void fillCheckedFlags(CheckedListBox aCheckedList, string aFlagSystemName, int aFlags, Label aDescriptionText)
        {
            fillCheckedFlags(aCheckedList, aFlagSystemName, aFlags, aDescriptionText, 0);
        }*/

        /*/// <summary>
        /// Last parameter are flags not to display because they're represented in other UI elements.
        /// </summary>
        public static void fillCheckedFlags(CheckedListBox aCheckedList, string aFlagSystemName, int aFlags, Label aDescriptionText, int aMask)
        {
            aCheckedList.BeginUpdate();
            aCheckedList.Items.Clear();

            aCheckedList.CheckOnClick = true; 

            FlagSet flagSet = SystemFlags.getFlagSet(aFlagSystemName);
            aCheckedList.ItemCheck += new ItemCheckEventHandler(CheckedList_ItemCheck);

            if ( aDescriptionText != null )
                aCheckedList.SelectedIndexChanged += new EventHandler(CheckedList_SelectedIndexChanged);

            foreach (Flag flg in flagSet.Flags.Values)
            {
                if ((flg.Value & aMask) != 0) continue;
                aCheckedList.Items.Add(flg, (flg.Value & aFlags) > 0);
            }

            aCheckedList.EndUpdate();
            aCheckedList.Tag = aDescriptionText;
        }*/

        /*public static int getCheckedFlags(CheckedListBox aCheckedList)
        {
            int resultFlags = 0;
            foreach (Flag flag in aCheckedList.CheckedItems)
            {
                resultFlags |= flag.Value;
            }

            return resultFlags;
        }*/

        /*private static void CheckedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox list = sender as CheckedListBox;
            Label txtDescription = list.Tag as Label;

            if (txtDescription != null)
            {
                Flag flag = list.SelectedItem as Flag;
                if (flag != null)
                {
                    txtDescription.Text = flag.Description;
                }
            }
        }*/

        /*public static void handleItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedList_ItemCheck(sender, e);
            CheckedListBox list = sender as CheckedListBox;
            foreach (Flag flag in list.Items)
            {
                if (e.Index == flag.Value)
                {
                    // do nothing?
                }
            }
        }*/

        /*private static void CheckedList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If the item checked is in a unique group, ensure others in the same group are unchecked
            if (e.NewValue == CheckState.Checked)
            {
                CheckedListBox list = sender as CheckedListBox;
                Flag flag = list.Items[e.Index] as Flag;

                if (flag.UniqueGroup != string.Empty)
                {
                    foreach (int index in list.CheckedIndices)
                    {
                        if ( index != e.Index && ((Flag)list.Items[index]).UniqueGroup == flag.UniqueGroup )
                        {
                            list.SetItemChecked(index, false );
                        }
                    }
                }
            }
        }*/
    }
}
