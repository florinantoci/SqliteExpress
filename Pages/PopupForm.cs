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

namespace SQlite.WF
{
    public partial class PopupForm : Form
    {
        public string samplePath;

        public PopupForm()
        {
            InitializeComponent();
            samplePath = "";
        }


        private void browseBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select location for database sample";
            saveFileDialog.FileName = "sample_database_" + DateTime.Now.ToString("dd_MM_yyyy");
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "SQLite Database (*.db)|*.db";
            saveFileDialog.DefaultExt = ".db";

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTb.Text = saveFileDialog.FileName;
            }

        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pathTb.Text))
            {
                samplePath = pathTb.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please complete with a valid path or Browse your computer!");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
