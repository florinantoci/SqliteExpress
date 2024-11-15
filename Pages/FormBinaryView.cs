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

namespace SQlite.WF.Pages
{
    public partial class FormBinaryView : Form
    {
        byte[] content;
        public FormBinaryView()
        {
            InitializeComponent();
        }
        public void LoadByte(byte[] content)
        {
            textBoxBinary.Text = BitConverter.ToString(content).Replace("-","");
            textBoxPlainText.Text = System.Text.ASCIIEncoding.ASCII.GetString(content);
            try
            {
                pictureBox.Image = Image.FromStream(new MemoryStream(content));
            }
            catch
            {
                labelNoImage.Visible = true;
            }
        }
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string filepath = saveFileDialog1.FileName;
            try
            {
                FileStream s = new FileStream(filepath, FileMode.Create);
                s.Write(this.content, 0, this.content.Length);
                s.Flush();
                s.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
