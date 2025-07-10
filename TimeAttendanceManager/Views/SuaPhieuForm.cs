using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeAttendanceManager.Models;
using TimeAttendanceManager.Repositories;
using static System.Windows.Forms.AxHost;

namespace TimeAttendanceManager.Views
{
    public partial class SuaPhieuForm : Form
    {
        private readonly AttendanceRepository _repository;
        private readonly AttendanceRecord _record;

        public SuaPhieuForm(AttendanceRepository repository, AttendanceRecord record)
        {
            InitializeComponent();
            _repository = repository;
            _record = record;

            // Điền dữ liệu cũ vào form
            dtDate.Value = _record.Date;
            txtPerson.Text = _record.Person;
            dtIn.Value = DateTime.Today + _record.TimeIn;
            dtOut.Value = DateTime.Today + _record.TimeOut;
        }

   

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void btnLuu_Click_1(object sender, EventArgs e)
        {
            _record.Date = dtDate.Value.Date;
            _record.Person = txtPerson.Text;
            _record.TimeIn = dtIn.Value.TimeOfDay;
            _record.TimeOut = dtOut.Value.TimeOfDay;

            await _repository.UpdateAsync(_record.Id, _record);

            MessageBox.Show("Cập nhật thành công");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}