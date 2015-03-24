using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class EffectSubControl : UserControl
    {
        public EffectSubControl()
        {
            InitializeComponent();
        }

        // Validate that the data in the sub control is valid
        public virtual bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            throw new Exception("EffectSubControl(): isSaveValid must be overriden");
        }

        // Load the data from an Effect row
        public virtual void loadEffectData(int aEffectDefId)
        {
            throw new Exception("loadEffectData(): loadEffectData must be overriden");
        }

        public virtual void initNewImpl()
        {
            throw new Exception("initNewImpl(): initNewImpl must be overridden");
        }

        // This method is invoked prior to saving an Effect row.  If this sub-editor
        // needs to save something that the Effect depends upon, now is its chance.
        public virtual void preSaveEffectData(int aEffectDefId)
        { }

        // This method is called on each sub-editor when an Effect row is to be saved.
        // This sub-editor should save data that is edited on it.
        public virtual void saveEffectData(int aEffectDefId)
        {
            throw new Exception("saveEffectData(): saveEffectData must be overriden");
        }

        // This method is called on each sub-editor when an Effect row is to be saved,
        // but is not of this editors type.  Any fields edited on it should be cleared.
        public virtual void preClearEffectData(int aEffectDefId)
        {
            throw new Exception("clearEffectData(): preClearEffectData must be overridden");
        }

        // This method is called on each sub-editor after an Effect row has been saved.
        // If aIsEffectType is true, then this sub-editor should save any data that it
        // is responsible for, and that depends on the Effect record.  Otherwise this
        // sub-editor should remove any data that it would normally add
        public virtual void postSaveEffectData(int aEffectDefId, bool aIsEffectType)
        { }
    }
}
