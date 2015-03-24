using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemVehicleControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemVehicleControl()
        {
            InitializeComponent();
            initTerrainGrid();
        }

        public override void initNewImpl()
        {
        }

        private void initTerrainGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Terrain;
                col.Name = "terrain_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Terrain";
                col.CellTemplate = cell;
                gridTerrain.Columns.Add(col);
            }
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_vehicle_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_vehicle_map_id"];
            numMaxSeating.Value = (int)dataRow["max_capacity"];
            dt.Dispose();

            loadTerrainGrid(aDefId);
        }

        private void loadTerrainGrid(int aId)
        {
            gridTerrain.Rows.Clear();

            DataTable dt = Database.getData("item_vehicle_terrain_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridTerrain.Rows.Add();
                DataGridViewRow gridRow = gridTerrain.Rows[gridIndex];

                DataGridViewLinkCell cellTerrain = gridRow.Cells["terrain_def_id"] as DataGridViewLinkCell;
                cellTerrain.Value = EditorFactory.getBrowseInfo(EditorSystemType.Terrain, rowView, "terrain_def_id");

                gridRow.Tag = (int)rowView["item_vehicle_terrain_map_id"];
            }
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_vehicle_terrain_map", "item_def_id", aDefId);
            Database.deleteData("item_vehicle_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_vehicle_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_vehicle_map");

            Database.updateData("item_vehicle_map", "item_vehicle_map_id", mItemMapId, "max_capacity", (int)numMaxSeating.Value);

            saveTerrainGrid(aDefId);
        }

        private void saveTerrainGrid(int aDefId)
        {
            foreach (DataGridViewRow gridRow in gridTerrain.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo terrainDefIdBrowseInfo = gridRow.Cells["terrain_def_id"].Value as EditorBrowseInfo;
                    if (terrainDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_vehicle_terrain_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_vehicle_terrain_map");

                    Database.updateData("item_vehicle_terrain_map", "item_vehicle_terrain_map_id", rowId, "statistic_def_id", terrainDefIdBrowseInfo.Id);
                }
            }

            gridTerrain.flushDeletedRows();
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_vehicle_terrain_map", "item_def_id", aDefId);
            Database.deleteData("item_vehicle_map", "item_def_id", aDefId);
        }
    }
}
