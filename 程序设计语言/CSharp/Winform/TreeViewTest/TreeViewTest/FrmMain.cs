using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewTest
{
    public partial class FrmMain : Form
    {
        private List<TVNode> nodeList = null;
        private TreeViewService treeViewService = new TreeViewService();
        public FrmMain()
        {
            InitializeComponent();

            LoadTVMenu();
        }

        private void LoadTVMenu()
        {
            this.nodeList = treeViewService.GetAllTVNodes();
            this.treeView.Nodes.Clear();
            //添加根节点
            TreeNode root = new TreeNode();
            root.Text = "学员管理系统";
            root.Tag = "0";
            root.ImageIndex = 0;
            this.treeView.Nodes.Add(root);

            CreateChildNode(root, 0);
        }

        private void CreateChildNode(TreeNode parentNode, int parentId)
        {
            var childList = from node in this.nodeList
                            where node.ParentId.Equals(parentId)
                            select node;
            foreach (var child in childList)
            {
                TreeNode node = new TreeNode();
                node.Text = child.MenuName;
                node.Tag = child.MenuCode;
                node.ImageIndex = child.MenuCode == string.Empty ? child.MenuLevel + 1 : 1;

                parentNode.Nodes.Add(node);
                CreateChildNode(node, child.MenuId);
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {

        }
    }
}
