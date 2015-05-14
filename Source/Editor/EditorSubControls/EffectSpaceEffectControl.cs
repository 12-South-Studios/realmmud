using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class EffectSpaceEffectControl : EffectSubControl
    {
        private int mEffectMapId;

        public EffectSpaceEffectControl()
        {
            InitializeComponent();
            linkSpaceEffect.SystemType = EditorSystemType.SpaceEffect;
        }

        public override void initNewImpl()
        {            
        }

        public override void loadEffectData(int aEffectDefId)
        {
            DataTable dt = Database.getData("effect_spaceeffect_map", "effect_def_id", aEffectDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mEffectMapId = (int)dataRow["effect_spaceeffect_map_id"];
            EditorFactory.setupLink(linkSpaceEffect, EditorSystemType.SpaceEffect, Database.getNullableId(dataRow, "space_effect_def_id"));
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            return true;
        }

        public override void preSaveEffectData(int aEffectDefId)
        {
        }

        public override void saveEffectData(int aDefId)
        {
            Database.deleteData("effect_spaceeffect_map", "effect_def_id", aDefId);

            mEffectMapId = Database.createData("effect_spaceeffect_map", "effect_def_id", aDefId, null, null);
            if (mEffectMapId == 0) throw new Exception("Failed to create new row in effect_spaceeffect_map");

            Database.updateData("effect_spaceeffect_map", "effect_spaceeffect_map_id", mEffectMapId, "space_effect_def_id", BaseEditorControl.getContentLinkId(linkSpaceEffect));
        }

        public override void preClearEffectData(int aDefId)
        {
            //Database.deleteData("effect_spaceeffect_map", "effect_def_id = " + aDefId);
            Database.deleteData("effect_spaceeffect_map", "effect_def_id", aDefId);
        }
    }
}
