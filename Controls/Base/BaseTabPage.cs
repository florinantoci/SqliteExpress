using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls.Base
{
    internal class BaseTabPage:TabPage
    {
        private BaseControl _control;
        public void AddControl(BaseControl c)
        {
            this.Text = c.Title;
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);
            c.ContentChangedEvent += C_ContentChangedEvent;
            _control = c;
        }

        private void C_ContentChangedEvent(object sender, EventArgs e)
        {
            if (_control.HasChanges)
                this.Text = _control.Title + " *";
            else
                this.Text = _control.Title ;
        }
    }
}
