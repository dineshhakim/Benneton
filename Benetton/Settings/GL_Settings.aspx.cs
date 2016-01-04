using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProudMonkey.Common.Controls;
using System.Data;
using BusinessLogic;
using Domain;

namespace Benetton.Settings
{
    public partial class GL_Settings : System.Web.UI.Page
    {

        ProudMonkey.Common.Controls.MessageBox msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            msgbox = new MessageBox()
            {

            };
            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LnkIncome_OnClick(sender, e);
            }
            
        }

        public void bindPearls()
        {
            // ddlPearls = FillDropDown.FillddlPearls(ddlPearls, 7, 0, tv.SelectedNode.Value);
        }
        #region LinkButton Click

        protected void LnkIncome_OnClick(object sender, EventArgs e)
        {
            li1.Attributes.Add("class", "ui-tabs-selected ui-state-active");
            li2.Attributes.Add("class", "");
            li3.Attributes.Add("class", "");
            li4.Attributes.Add("class", "");
            BuildTree(3);
            hfValue.Value = "3";
            lblHeader.Text = lnkIncome.Text;
            
        }
        protected void LnkExpense_OnClick(object sender, EventArgs e)
        {
            li1.Attributes.Add("class", "");
            li2.Attributes.Add("class", "ui-tabs-selected ui-state-active");
            li3.Attributes.Add("class", "");
            li4.Attributes.Add("class", "");
            BuildTree(4);
            hfValue.Value = "4";
            lblHeader.Text = LnkExpense.Text;
        }
        protected void LnkAssests_OnClick(object sender, EventArgs e)
        {
            li1.Attributes.Add("class", "");
            li2.Attributes.Add("class", "");
            li3.Attributes.Add("class", "ui-tabs-selected ui-state-active");
            li4.Attributes.Add("class", "");
            BuildTree(2);
            hfValue.Value = "2";
            lblHeader.Text = LnkAssests.Text;

        }
        protected void LnkLiability_OnClick(object sender, EventArgs e)
        {
            li1.Attributes.Add("class", "");
            li2.Attributes.Add("class", "");
            li3.Attributes.Add("class", "");
            li4.Attributes.Add("class", "ui-tabs-selected ui-state-active");
            BuildTree(1);
            hfValue.Value = "1";
            lblHeader.Text = lnkLiability.Text;
        }

        #endregion

        #region Treeview Event

        #endregion

        protected void tv_SelectedNodeChanged(object sender, EventArgs e)
        {
            string childcode = "";
            txt_roottopic.Text = After(tv.SelectedNode.Text, "-").TrimStart();
            txt_roottopic.Enabled = false;
            txtParticular.Text = "";
            int id = Convert.ToInt32(hfValue.Value);
            if (id == 1 || id == 2)
            {
                txtRootCode.Text = BlLa.GetLA_CODE(5, 0, tv.SelectedNode.Value);
                childcode = BlLa.GetLA_CODE(6, 0, tv.SelectedNode.Value);
            }
            else if (id == 3 || id == 4)
            {
                txtRootCode.Text = BlIncomeExp.GetIE_CODE(5, 0, tv.SelectedNode.Value);
                childcode = BlIncomeExp.GetIE_CODE(6, 0, tv.SelectedNode.Value);
            }

            if (tv.SelectedNode.Value == "2")
            {
                txtParticularcode.Text = childcode;
            }
            else if (string.IsNullOrEmpty(childcode))
            {
                txtParticularcode.Text = txtRootCode.Text + "." + "1";
            }
            else
            {
                txtParticularcode.Text = txtRootCode.Text + "." + childcode;
            }
            bindPearls();
        }
        protected void BtnSubmit_OnClick(object sender, EventArgs e)
        {
            char Event = 'I';
            if (btnSubmit.CommandName == "Update")
            {
                Event = 'U';
            }
            else
            {
                Event = 'I';
                
            }
            int id = Convert.ToInt32(hfValue.Value);
            if (id == 1 || id == 2)
            {
                InsUpdDelLa(Event, Convert.ToInt32(tv.SelectedNode.Value));
            }
            else if (id == 3 || id == 4)
            {
                InsUpdDelIncomeExp(Event, Convert.ToInt32(tv.SelectedNode.Value));
            }

        }

        DataTable NodeItems;
        private void BuildTree(int id)
        {
            tv.Nodes.Clear();
            if (id == 1 || id == 2)
            {
                NodeItems = BlLa.GetLa(3, 0, id.ToString());
            }
            else
            {
                NodeItems = BlIncomeExp.GetIncomeExp(4, 0, id.ToString());
            }
            if (NodeItems.Rows.Count > 0)
            {
                // add top level nodes
                DataView vw = NodeItems.DefaultView;
                vw.RowStateFilter = DataViewRowState.CurrentRows;
                vw.RowFilter = "ParentID=0";
                // top level items

                // using the new (.net 2.0)in Memory Table Reader
                DataTable tb = vw.ToTable();
                DataTableReader rdr = tb.CreateDataReader();

                // Calls BuildChildNodes for each top level node - it's recursive for nested branches
                while (rdr.Read())
                {
                    TreeNode node = new TreeNode();
                    node.Text = rdr["Org_Category_Name"].ToString();
                    node.Value = rdr["ID"].ToString();

                    // could use ordinal for more speed, using column name for clarity
                    this.tv.Nodes.Add(node);
                    // get children recursively
                    Int32 parentID = Convert.ToInt32(rdr[0]);
                    // first column is item ID
                    this.BuildChildNodes(parentID, ref node);
                }

                rdr.Close();
            }

            // add to cache

            System.Collections.Generic.List<TreeNode> nds = new System.Collections.Generic.List<TreeNode>();
            foreach (TreeNode nd in this.tv.Nodes)
            {
                nds.Add(nd);
            }

        }
        private void BuildChildNodes(Int32 ParentID, ref TreeNode ParentNode)
        {
            DataView ChildrenView = this.NodeItems.DefaultView;

            ChildrenView.RowStateFilter = DataViewRowState.CurrentRows;

            ChildrenView.RowFilter = "ParentID = " + ParentID.ToString();
            DataTable temp = ChildrenView.ToTable();
            DataTableReader rdr = temp.CreateDataReader();
            while (rdr.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = rdr["Org_Category_Name"].ToString();
                child.Value = rdr["ID"].ToString();
                Int32 childID = int.Parse(rdr[0].ToString());
                ParentNode.ChildNodes.Add(child);
                this.BuildChildNodes(childID, ref child);
            }
            rdr.Close();
        }


        private string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        private string Before(string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        private string After(string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
        protected void lnkEdit_OnClick(object sender, EventArgs e)
        {
            GetDetails(Convert.ToInt32(hfValue.Value));
            txt_roottopic.Enabled = false;

        }
       
        private void GetDetails(int id)
        {
            txt_roottopic.Enabled = true;
            if (id == 1 || id == 2)
            {
                DataTable dt = BlLa.GetLa(10, 0, tv.SelectedNode.Value);
                if (dt.Rows.Count > 0)
                {
                    txt_roottopic.Text = dt.Rows[0]["Parent"].ToString();
                    txtRootCode.Text = dt.Rows[0]["ParentCode"].ToString();
                    txtParticular.Text = dt.Rows[0]["LA"].ToString();
                    txtParticularcode.Text = dt.Rows[0]["LA_Code"].ToString();
                    if (dt.Rows[0]["LA_Child"] != null)
                    {
                        //ddlUnder.SelectedValue = dt.Rows[0]["LA_Child"].ToString();
                    }
                    chkPrimary.Checked = Convert.ToBoolean(dt.Rows[0]["LA_Primary"].ToString());
                    chkIsNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["IsNeeded"].ToString());
                    btnSubmit.CommandName = "Update";
                    btnSubmit.Text = "Update";
                }
            }
            else if (id == 3 || id == 4)
            {
                DataTable dt = BlIncomeExp.GetIncomeExp(17, 0, tv.SelectedNode.Value);
                if (dt.Rows.Count > 0)
                {
                    txt_roottopic.Text = dt.Rows[0]["Parent"].ToString();
                    txtRootCode.Text = dt.Rows[0]["ParentCode"].ToString();
                    txtParticular.Text = dt.Rows[0]["IE"].ToString();
                    txtParticularcode.Text = dt.Rows[0]["IE_Code"].ToString();
                    if (dt.Rows[0]["IE_Child"] != null)
                    {
                        //ddlUnder.SelectedValue = dt.Rows[0]["IE_Child"].ToString();
                    }
                    chkPrimary.Checked = Convert.ToBoolean(dt.Rows[0]["IE_Primary"].ToString());
                    chkIsNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["IsNeeded"].ToString());
                    btnSubmit.CommandName = "Update";
                    btnSubmit.Text = "Update";
                }
            }
            else
            {

            }
        }

        private void InsUpdDelLa(char Event, int Id)
        {
            try
            {
                BlLa objbl = new BlLa();
                PL_LA obj = new PL_LA();
                obj.LA_ID = Id;
                obj.EVENT = Event;
                if (Event == 'D')
                {

                }
                else
                {
                    obj.LA_Code = txtParticularcode.Text;
                    obj.LA = txtParticular.Text;
                    obj.LA_ParentID = int.Parse(tv.SelectedNode.Value);
                    obj.LA_Primary = chkPrimary.Checked;
                    //obj.LA_Child = ddlUnder.SelectedValue;
                    obj.IsNeeded = chkIsNeeded.Checked;
                    //obj.p_headerid = int.Parse(ddlPearls.SelectedValue);
                }
                string msg = objbl.InsUpdDelLa(obj, out Id);
                if (msg == "Record Inserted Successfully" || msg == "Record Updated Successfully" || msg == "Record Deleted Successfully")
                {
                    msgbox.ShowSuccess(msg);
                    BuildTree(Convert.ToInt32(hfValue.Value));
                    Clear();
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }
            catch (Exception ex)
            {
                msgbox.ShowWarning(ex.Message);
            }


        }
        private void InsUpdDelIncomeExp(char Event, int Id)
        {
            try
            {
                BlIncomeExp objbl = new BlIncomeExp();
                PL_IncomeExp obj = new PL_IncomeExp();
                obj.IE_ID = Id;
                obj.EVENT = Event;
                if (Event == 'D')
                {

                }

                else
                {
                    obj.IE_Code = txtParticularcode.Text;
                    obj.IE = txtParticular.Text;
                    obj.IE_ParentID = int.Parse(tv.SelectedNode.Value);
                    obj.IE_Primary = chkPrimary.Checked;
                    //obj.Ie_Child = ddlUnder.SelectedValue;
                    obj.IsNeeded = chkIsNeeded.Checked;


                }
                string msg = objbl.InsUpdDelIncomeExp(obj, out Id);
                if (msg == "Record Inserted Successfully" || msg == "Record Updated Successfully" || msg == "Record Deleted Successfully")
                {
                    msgbox.ShowSuccess(msg);
                    BuildTree(Convert.ToInt32(hfValue.Value));
                    Clear();
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }
            catch (Exception ex)
            {
                msgbox.ShowWarning(ex.Message);
            }

        }

        private void Clear()
        {
            txtRootCode.Text = "";
            txtParticularcode.Text = "";
            txtParticular.Text = "";
            txt_roottopic.Text = "";
            chkPrimary.Checked = false;
            chkIsNeeded.Checked = true;
            btnSubmit.CommandName = "Save";
            btnSubmit.Text = "Submit";
            txtParticular.Enabled = true;
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Clear();
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfValue.Value);
            if (id == 1 || id == 2)
            {
                InsUpdDelLa('D', Convert.ToInt32(tv.SelectedNode.Value));
            }
            else if (id == 3 || id == 4)
            {
                InsUpdDelIncomeExp('D', Convert.ToInt32(tv.SelectedNode.Value));
            }
        }
    }
}