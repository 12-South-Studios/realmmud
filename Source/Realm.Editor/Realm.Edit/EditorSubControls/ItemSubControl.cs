using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemSubControl : UserControl
    {
        public ItemSubControl()
        {
            InitializeComponent();
        }

        // Validate that the data in the sub control is valid
        public virtual bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            throw new Exception("ItemSubControl(): isSaveValid must be overriden");
        }

        // Load the data from an item row
        public virtual void loadItemData(int aItemDefId)
        {
            throw new Exception("loadItemData(): loadItemData must be overriden");
        }

        public virtual void initNewImpl()
        {
            throw new Exception("initNewImpl(): initNewImpl must be overridden");
        }

        // This method is invoked prior to saving an item row.  If this sub-editor
        // needs to save something that the item depends upon, now is its chance.
        public virtual void preSaveItemData(int aItemDefId)
        { }

        // This method is called on each sub-editor when an item row is to be saved.
        // This sub-editor should save data that is edited on it.
        public virtual void saveItemData(int aItemDefId)
        {
            throw new Exception("saveItemData(): saveItemData must be overriden");
        }

        // This method is called on each sub-editor when an item row is to be saved,
        // but is not of this editors type.  Any fields edited on it should be cleared.
        public virtual void preClearItemData(int aItemDefId)
        {
            throw new Exception("clearItemData(): preClearItemData must be overridden");
        }

        // This method is called on each sub-editor after an item row has been saved.
        // If aIsItemType is true, then this sub-editor should save any data that it
        // is responsible for, and that depends on the item record.  Otherwise this
        // sub-editor should remove any data that it would normally add
        public virtual void postSaveItemData(int aItemDefId, bool aIsItemType)
        { }
    }
}
