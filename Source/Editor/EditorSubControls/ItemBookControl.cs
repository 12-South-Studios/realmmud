using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemBookControl : ItemSubControl
    {
        private int mItemMapId;
        private List<BookPage> mPages;
        private Boolean mHandlingEvent;

        public ItemBookControl()
        {
            InitializeComponent();
            linkAbility.SystemType = EditorSystemType.Ability;
            mPages = new List<BookPage>();
            mHandlingEvent = false;
        }

        public override void initNewImpl()
        {
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_book_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_book_map_id"];
            EditorFactory.setupLink(linkAbility, EditorSystemType.Ability, Database.getNullableId(dataRow, "ability_def_id"));

            DataTable pageTable = Database.getData("item_book_page_map", "item_def_id", aDefId, null);
            if (pageTable == null) return;
            if (pageTable.Rows.Count == 0) return;

            mPages.Clear();
            listBoxPages.Items.Clear();
            foreach (DataRow pageRow in pageTable.Rows)
            {
                BookPage bookPage = new BookPage();
                bookPage.book_page_def_id = (int)pageRow["item_book_page_map_id"];
                bookPage.page_number = (int)pageRow["page_number"];
                bookPage.page_text = pageRow["page_text"].ToString();
                mPages.Add(bookPage);

                /* Find the first page and select it by default */
                listBoxPages.Items.Add(bookPage.page_number.ToString());
            }
            pageTable.Dispose();
            dt.Dispose();

            loadListToUI();
            if (listBoxPages.Items.Count != 0)
            {
                listBoxPages.SelectedIndex = 0;
            }
        }

        private void loadListToUI()
        {
            if (mHandlingEvent) return;
            mHandlingEvent = true;
            if (listBoxPages.SelectedIndex == -1)
            {
                mHandlingEvent = false;
                return;
            }

            BookPage bookPage = mPages[listBoxPages.SelectedIndex];
            txtPageText.Text = bookPage.page_text;
            mHandlingEvent = false;
        }

        private void saveUIToList()
        {
            if (mHandlingEvent) return;
            mHandlingEvent = true;
            try
            {
                BookPage bookPage = null;
                if (listBoxPages.SelectedIndex == -1)
                {
                    bookPage = new BookPage();
                    bookPage.page_text = "<new>";
                    bookPage.book_page_def_id = 0;
                    bookPage.page_number = mPages.Count + 1;
                    mPages.Add(bookPage);
                    listBoxPages.Items.Add(bookPage.page_number);
                    listBoxPages.SelectedIndex = listBoxPages.Items.Count - 1;
                }
                else
                {
                    bookPage = mPages[listBoxPages.SelectedIndex];
                }
                listBoxPages.Items[listBoxPages.SelectedIndex] = bookPage.page_number;
                bookPage.page_text = txtPageText.Text;
            }
            catch (Exception ex)
            {
                Logger.Instance.log(ex);
                MessageBox.Show(ex.Message);
            }
            mHandlingEvent = false;
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
            Database.deleteData("item_book_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_book_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_book_map");

            Database.updateData("item_book_map", "item_book_map_id", mItemMapId, "ability_def_id", BaseEditorControl.getContentLinkId(linkAbility));

            int i = 0;
            foreach (BookPage bookPage in mPages)
            {
                int rowId = Database.createData("item_book_page_map", "item_def_id", aDefId, null, null);
                if (rowId == 0) throw new Exception("Failed to create new row in item_book_page_map");

                Database.updateData("item_book_page_map", "item_book_page_map_id", rowId, "page_text", bookPage.page_text);
                Database.updateData("item_book_page_map", "item_book_page_map_id", rowId, "page_number", i++);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveUIToList();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            listBoxPages.SelectedIndex = -1;
            saveUIToList();
            txtPageText.Text = "<new>";
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadListToUI();
        }

        private void txtPageText_Enter(object sender, EventArgs e)
        {
            saveUIToList();
        }

        private void txtPageText_TextChanged(object sender, EventArgs e)
        {
            saveUIToList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedIndex != -1)
            {
                mHandlingEvent = true;
                mPages.RemoveAt(listBoxPages.SelectedIndex);
                listBoxPages.Items.RemoveAt(listBoxPages.SelectedIndex);
                if (listBoxPages.Items.Count == 0)
                {
                    listBoxPages.SelectedIndex = -1;
                    txtPageText.Text = "";
                }
                else
                {
                    listBoxPages.SelectedIndex = 0;
                }
                mHandlingEvent = false;
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedIndex != -1 && listBoxPages.SelectedIndex != 0)
            {
                // Swap them in the list.
                BookPage p0 = mPages[listBoxPages.SelectedIndex];
                BookPage p1 = mPages[listBoxPages.SelectedIndex - 1];
                mPages[listBoxPages.SelectedIndex] = p1;
                mPages[listBoxPages.SelectedIndex - 1] = p0;

                // Swap them in the UI.
                object pp0 = listBoxPages.Items[listBoxPages.SelectedIndex];
                object pp1 = listBoxPages.Items[listBoxPages.SelectedIndex - 1];
                listBoxPages.Items[listBoxPages.SelectedIndex] = pp1;
                listBoxPages.Items[listBoxPages.SelectedIndex - 1] = pp0;
                listBoxPages.SelectedIndex--;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedIndex != -1 && listBoxPages.SelectedIndex != (listBoxPages.Items.Count - 1))
            {
                // Swap them in the list.
                BookPage p0 = mPages[listBoxPages.SelectedIndex];
                BookPage p1 = mPages[listBoxPages.SelectedIndex + 1];
                mPages[listBoxPages.SelectedIndex] = p1;
                mPages[listBoxPages.SelectedIndex + 1] = p0;

                // Swap them in the UI.
                object pp0 = listBoxPages.Items[listBoxPages.SelectedIndex];
                object pp1 = listBoxPages.Items[listBoxPages.SelectedIndex + 1];
                listBoxPages.Items[listBoxPages.SelectedIndex] = pp1;
                listBoxPages.Items[listBoxPages.SelectedIndex + 1] = pp0;
                listBoxPages.SelectedIndex++;
            }
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_book_page_map", "item_def_id", aDefId);
            Database.deleteData("item_book_map", "item_def_id", aDefId);
        }

        public class BookPage
        {
            public int book_page_def_id;
            public int page_number;
            public string page_text;
        }
    }
}