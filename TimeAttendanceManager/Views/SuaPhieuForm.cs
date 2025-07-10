using System;
using System.Windows.Forms;
using TimeAttendanceManager.Models;
using TimeAttendanceManager.Repositories;

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

            // Gán dữ liệu cũ
            dtDate.Value = _record.Date;
            txtPerson.Text = _record.Person;
            dtIn.Value = DateTime.Today + _record.TimeIn;
            dtOut.Value = DateTime.Today + _record.TimeOut;

            // Cập nhật tổng giờ ban đầu
            UpdateTongGioLam();

            // Lắng nghe sự kiện đổi giờ
            dtIn.ValueChanged += DtTimeChanged;
            dtOut.ValueChanged += DtTimeChanged;
        }

      

        private void DtTimeChanged(object sender, EventArgs e)
        {
            UpdateTongGioLam();
        }

        private void UpdateTongGioLam()
        {
            TimeSpan timeIn = dtIn.Value.TimeOfDay;
            TimeSpan timeOut = dtOut.Value.TimeOfDay;

            if (timeOut > timeIn)
            {
                TimeSpan duration = timeOut - timeIn;
                lblTongGioLam.Text = $"{duration.TotalHours:0.##} giờ";
            }
            else
            {
                lblTongGioLam.Text = "0 giờ";
            }
        }

        private async void btnLuu_Click_1(object sender, EventArgs e)
        {
            _record.Date = dtDate.Value.Date;
            _record.Person = txtPerson.Text;
            _record.TimeIn = dtIn.Value.TimeOfDay;
            _record.TimeOut = dtOut.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(_record.Person) || _record.TimeOut <= _record.TimeIn)
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
                return;
            }

            await _repository.UpdateAsync(_record.Id, _record);

            MessageBox.Show("Cập nhật thành công");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
