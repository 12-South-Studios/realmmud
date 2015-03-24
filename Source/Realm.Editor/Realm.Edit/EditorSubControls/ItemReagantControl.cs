using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemReagantControl : ItemSubControl
    {
        public ItemReagantControl()
        {
            InitializeComponent();
        }

        public override void loadItemData(int aItemDefId)
        {
            
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            return true;
        }

        public override void initNewImpl()
        {
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aItemDefId)
        {
        }

        public override void preClearItemData(int aItemDefId)
        {
        }
    }
}
