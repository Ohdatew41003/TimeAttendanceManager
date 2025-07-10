using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeAttendanceManager.Models;
using TimeAttendanceManager.Repositories;
using TimeAttendanceManager.Views;

namespace TimeAttendanceManager
{
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceRepository _repository;

        public AttendanceForm()
        {
            InitializeComponent();

            // Khởi tạo AttendanceRepository dùng chuỗi kết nối trực tiếp
            _repository = new AttendanceRepository();

            // Load dữ liệu khi mở form
            this.Load += AttendanceForm_Load;
        }

        // Load dữ liệu từ MongoDB khi form mở
        private async void AttendanceForm_Load(object sender, EventArgs e)
        {
            await LoadRecordsAsync();
        }

        // Xử lý khi nhấn nút "Tạo Phiếu"
        private async void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            var form = new TaoPhieuForm(_repository); // Truyền repository vào form tạo phiếu
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadRecordsAsync(); // Reload bảng khi tạo xong
            }
        }

        // Load tất cả phiếu từ MongoDB lên DataGridView
        private async Task LoadRecordsAsync()
        {
            try
            {
                var records = await _repository.GetAllAsync();

                gridRecords.Columns.Clear(); // ❗ xoá toàn bộ cột cũ
                gridRecords.DataSource = records;

                AddActionButtons(); // ➕ thêm nút sau khi gán datasource
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }



        private void AddActionButtons()
        {
            if (!gridRecords.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
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
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "Xoá",
                    Name = "Delete",
                    Text = "Xoá",
                    UseColumnTextForButtonValue = true
                };
                gridRecords.Columns.Add(btnDelete);
            }

            gridRecords.CellClick += gridRecords_CellClick;
        }
        private async void gridRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRecord = (AttendanceRecord)gridRecords.Rows[e.RowIndex].DataBoundItem;

                if (gridRecords.Columns[e.ColumnIndex].Name == "Edit")
                {
                    var form = new SuaPhieuForm(_repository, selectedRecord);
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
                        await _repository.DeleteAsync(selectedRecord.Id);
                        await LoadRecordsAsync();
                    }
                }
            }
        }

   
    }
}
