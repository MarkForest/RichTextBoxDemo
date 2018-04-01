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

namespace TreeViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            TreeNode tovarNode = new TreeNode("Товары");
            //добавляем новый дочерний узел к tovarNode
            TreeNode smartFon = new TreeNode("Смартфон");
            tovarNode.Nodes.Add(smartFon);

            //string[] items = {"first", "second", "Thirth", "fourth", "fivth" };

            //IEnumerable<string> result = (from item in items where item.StartsWith("f") select item).Distinct();
            //foreach (string item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //Добавляем ветку к treeView
            this.treeView1.Nodes.Add(tovarNode);

            //Доюовляем второй дочерний узел к первому узлу treeNode
            treeView1.Nodes[0].Nodes.Add(new TreeNode("Планшеты"));

            //Удаление
            //treeView1.Nodes[0].Nodes.RemoveAt(1);
            //treeView1.Nodes.Remove(tovarNode);

            ImageList imageList = new ImageList();
            //....
            imageList.Images.Add(Image.FromFile("image.png"));

            treeView1.ImageList = imageList;
            treeView1.Nodes[0].Nodes.Add(new TreeNode("Планшеты", 0,1));
            //....
        }
    }
}
