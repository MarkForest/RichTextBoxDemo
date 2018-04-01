using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextBoxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            undoToolStripMenuItem.Enabled = false;
            сToolStripMenuItem.Enabled = false;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (MessageBox.Show("What!...") == DialogResult.OK)
            {
                Process.Start(e.LinkText);
            }
        }

        //В момент изменения текста проверяем есть ли что оменять
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox1.CanUndo;
            сToolStripMenuItem.Enabled = richTextBox1.CanRedo;
        }

        //Открытие файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = @"Lorem Ipsum - це текст-, що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною  аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів.  не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files|*.txt|Rich Text Document|*.rtf|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.EndsWith("rtf"))
                {
                    richTextBox1.LoadFile(dlg.FileName);
                }else
                {
                    richTextBox1.Text = File.ReadAllText(dlg.FileName);
                }
            }
        }

        //Выбор шрифта выделеного текста
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richTextBox1.SelectionFont;
            fontDialog.Color = richTextBox1.SelectionColor;
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
                richTextBox1.SelectionColor = fontDialog.Color;
            }

        }

        //Отступ
        private void identToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = 20;
        }

        //Маркировка текста
        private void bulletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
        }

        //Отменить действие
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
               richTextBox1.Undo();
        }

        //Отменить отмененое действие
        private void сToolStripMenuItem_Click(object sender, EventArgs e)
        {
               richTextBox1.Redo();
        }

        //Сохранения в нужном на формате
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = dlg.Filter = "Text Files|*.txt|Rich Text Document|*.rtf|All Files|*.*";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(dlg.FileName))
                {
                    if (dlg.FileName.EndsWith("rtf"))
                    {
                        richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }
    }
}
