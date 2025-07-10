using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeAttendanceManager.Models;
using TimeAttendanceManager.Repositories;
using TimeAttendanceManager.Views;
using System.Globalization;


namespace TimeAttendanceManager
{
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceRepository _repository;

        public AttendanceForm()
        {
            InitializeComponent();
            _repository = new AttendanceRepository();
            this.Load += AttendanceForm_Load;
        }

        private async void AttendanceForm_Load(object sender, EventArgs e)
        {
            await LoadRecordsAsync();
        }

        private async void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            var form = new TaoPhieuForm(_repository); // Truyền repository vào form tạo phiếu
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadRecordsAsync(); // Reload bảng khi tạo xong
            }
        }


        private async Task LoadRecordsAsync()
        {
            try
            {
                var records = await _repository.GetAllAsync();
                var list = records
                    .Select((r, index) => new
                    {
                        STT = index + 1,
                        Ngay = r.Date.ToString("dd/MM/yyyy"),
                        Nguoi = r.Person,
                        TDVao = r.TimeIn.ToString(@"hh\:mm"),
                        TDRa = r.TimeOut.ToString(@"hh\:mm"),
                        TongGioLam = Math.Round(r.TotalHours, 2),
                        Id = r.Id,
                        OriginalRecord = r // giữ lại để thao tác sửa/xoá
                    })
                    .ToList();

                gridRecords.Columns.Clear();
                gridRecords.DataSource = list;

             
                gridRecords.Columns["STT"].HeaderText = "STT";
                gridRecords.Columns["Ngay"].HeaderText = "Ngày";
                gridRecords.Columns["Nguoi"].HeaderText = "Người";
                gridRecords.Columns["TDVao"].HeaderText = "TĐ vào";
                gridRecords.Columns["TDRa"].HeaderText = "TĐ ra";
                gridRecords.Columns["TongGioLam"].HeaderText = "Tổng Giờ Làm";

            
                gridRecords.Columns["Id"].Visible = false;
                gridRecords.Columns["OriginalRecord"].Visible = false;

                AddActionButtons();


         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }




        private void AddActionButtons()
        {
            gridRecords.CellClick -= gridRecords_CellClick;
            gridRecords.CellClick += gridRecords_CellClick; 
            if (!gridRecords.Columns.Contains("Edit"))
            {
                var btnEdit = new DataGridViewButtonColumn
                {
                    HeaderText = "Sửa",
                    Name = "Edit",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };
                gridRecords.Columns.Add(btnEdit);
            }

            if (!gridRecords.Columns.Contains("Delete"))
            {
                var btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "Xoá",
                    Name = "Delete",
                    Text = "Xoá",
                    UseColumnTextForButtonValue = true
                };
                gridRecords.Columns.Add(btnDelete);
            }
        }

        private async void gridRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = gridRecords.Rows[e.RowIndex];
                var record = (AttendanceRecord)row.Cells["OriginalRecord"].Value;

                if (gridRecords.Columns[e.ColumnIndex].Name == "Edit")
                {
                    var form = new SuaPhieuForm(_repository, record);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await LoadRecordsAsync();
                    }
                }
                else if (gridRecords.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Bạn có chắc muốn xoá phiếu này không?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        await _repository.DeleteAsync(record.Id);
                        await LoadRecordsAsync();
                    }
                }
            }
        }


        private async void lblPhieuChamCong_Click(object sender, EventArgs e)
        {
            lblPhieuChamCong.Font = new Font(lblPhieuChamCong.Font, FontStyle.Bold);
            lblPhieuChamCong.ForeColor = Color.Gold; 
            lblTongHop.Font = new Font(lblTongHop.Font, FontStyle.Regular);
            lblTongHop.ForeColor = Color.White; 
            await LoadRecordsAsync(); 

        }

        private async void lblTongHop_Click(object sender, EventArgs e)
        {
            
            lblTongHop.Font = new Font(lblTongHop.Font, FontStyle.Bold);
            lblTongHop.ForeColor = Color.Gold; 
            lblPhieuChamCong.Font = new Font(lblPhieuChamCong.Font, FontStyle.Regular);
            lblPhieuChamCong.ForeColor = Color.White;
         
            gridRecords.Columns.Clear();
            gridRecords.DataSource = null;

            var records = await _repository.GetAllAsync();
            var summary = records
                .GroupBy(r => new
                {
                    Week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(r.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday),
                    Month = r.Date.Month
                })
                .Select((g, index) => new
                {
                    STT = index + 1,
                    Tuan = g.Key.Week,
                    Thang = g.Key.Month,
                    TongGio = Math.Round(g.Sum(x => x.TotalHours), 2)
                })
                .ToList();

            gridRecords.DataSource = summary;
        }
    }
}
