using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeAttendanceManager.Repositories;
using TimeAttendanceManager.Views;

namespace TimeAttendanceManager
{
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceRepository _repository;
        private IConfiguration _config;

        public AttendanceForm()
        {
            InitializeComponent();

            // Load config từ appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _config = builder.Build();

            _repository = new AttendanceRepository(); 


            this.Load += AttendanceForm_Load;
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            // có thể gọi await LoadRecordsAsync(); nếu muốn load ngay dữ liệu
        }

        private async void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            TaoPhieuForm form = new TaoPhieuForm(_repository); // truyền repository
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadRecordsAsync();
            }
        }

        private async Task LoadRecordsAsync()
        {
            var records = await _repository.GetAllAsync();
            gridRecords.DataSource = null;
            gridRecords.DataSource = records;
        }
    }
}
