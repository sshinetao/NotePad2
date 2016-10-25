using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotePad2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开(Open)";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "文本文件(*.txt)|*.txt";
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.Default);
                    this.richTextBox1.Text = sr.ReadToEnd();
                    this.toolStripStatusLabel1.Text = ofd.FileName;
                    //MessageBox.Show(this.toolStripStatusLabel1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void closeFile_Click(object sender, EventArgs e)
        {

            this.richTextBox1.Text = null;
            this.toolStripStatusLabel1.Text = null;
        }

        private void saveFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            StreamReader sr = new StreamReader(this.toolStripStatusLabel1.Text, System.Text.Encoding.Default);
            sr.Close();
            File.WriteAllText(this.toolStripStatusLabel1.Text, this.richTextBox1.Text, Encoding.UTF8);
        }


    }
}
