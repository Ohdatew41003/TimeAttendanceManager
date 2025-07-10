using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeAttendanceManager
{
    public partial class AttendanceForm : Form
    {
        public AttendanceForm()
        {
            InitializeComponent();
            this.Load += AttendanceForm_Load;
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
     
        }

    }
}
