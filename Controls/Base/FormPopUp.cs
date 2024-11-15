using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls.Base
{
    internal partial class FormPopUp : Form
    {

        Base.BaseControl _control;
        public FormPopUp()
        {
            InitializeComponent();
        }
        public void ShowControl(BaseControl ctrl)
        {
            this._control = ctrl;
            this.panelContainer.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
            this.Text = ctrl.Title;
            this.ShowDialog();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {

            _control.Save();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_control.HasChanges)
            {
                //ask for changed lost
            }
            else
            {
                _control.Cancel();

                this.Close();
            }
        }
    }
}
