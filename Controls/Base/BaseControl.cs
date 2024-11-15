using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls.Base
{
    internal class BaseControl: UserControl
    {
        public event EventHandler ContentChangedEvent;
        public string Title { get; set; }
        public bool HasChanges { get; set; }
        public virtual void Save()
        {
         
        }
        public virtual void SaveAs()
        {

        }
        public void ShowInDialog()
        {
            FormPopUp pop = new FormPopUp();
            pop.ShowControl(this);
        }
        public virtual void Cancel()
        {

        }
        public void ThrowContentChanged()
        {
            HasChanges = true;
            if (this.ContentChangedEvent != null)
                this.ContentChangedEvent(this, null);
        }
    }
}
