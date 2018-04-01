using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewObhodDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            treeView1.BeforeSelect += TreeView1_BeforeSelect;
            treeView1.BeforeExpand += TreeView1_BeforeExpand;

            //Заполняем дерево дисками
            fillDriveNodes();

        }

        private void fillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    FillTreeNode(driveNode, drive.Name);
                    treeView1.Nodes.Add(driveNode);

                }
                
            }
            catch (Exception)
            {
            }
        }

        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (var dir in dirs)
                {

                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    driveNode.Nodes.Add(dirNode);
                }


            }
            catch (Exception)
            {
            }
        }


        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
           
        }
    }
}
