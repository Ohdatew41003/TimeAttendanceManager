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
    public partial class TaoPhieuForm : Form
    {
        private readonly AttendanceRepository _repository;

        public TaoPhieuForm(AttendanceRepository repo)
        {
            InitializeComponent();
            _repository = repo;
        }



        private async void btnLuu_Click_1(object sender, EventArgs e)
        {
            string person = txtPerson.Text;
            DateTime date = dtDate.Value.Date;
            TimeSpan timeIn = dtIn.Value.TimeOfDay;
            TimeSpan timeOut = dtOut.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(person) || timeOut <= timeIn)
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
                return;
            }

            var record = new AttendanceRecord
            {
                Date = date,
                Person = person,
                TimeIn = timeIn,
                TimeOut = timeOut,
            };

            await _repository.CreateAsync(record);

            MessageBox.Show("Tạo phiếu thành công");
            this.DialogResult = DialogResult.OK; // để AttendanceForm biết reload
            this.Close();
        }

    }
}
