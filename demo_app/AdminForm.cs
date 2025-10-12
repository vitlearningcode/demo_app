using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data; // Cần cho DataTable


namespace demo_app
{
    public partial class AdminForm : Form
    {
        // Lấy chuỗi kết nối từ App.config
        string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Gọi các hàm để tải dữ liệu lên Dashboard
            LoadDashboardMetrics();
            LoadMonBanChay();
            LoadVaiTroToComboBox();
            LoadNhanVienToGrid();
            LoadDanhMucToComboBox();

        }

        // Hàm để tải các chỉ số chính: Doanh thu, Hóa đơn, Bàn
        private void LoadDashboardMetrics()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Lấy Doanh thu hôm nay
                    string queryDoanhThu = "SELECT SUM(TongTien) FROM HoaDon WHERE CAST(NgayTao AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmdDoanhThu = new SqlCommand(queryDoanhThu, conn);
                    object resultDoanhThu = cmdDoanhThu.ExecuteScalar();
                    // Kiểm tra kết quả có null không (trường hợp chưa có hóa đơn nào)
                    if (resultDoanhThu != DBNull.Value)
                    {
                        lblDoanhThuHomNay.Text = string.Format("{0:N0} đ", Convert.ToDecimal(resultDoanhThu));
                    }
                    else
                    {
                        lblDoanhThuHomNay.Text = "0 đ";
                    }

                    // 2. Lấy Tổng số hóa đơn hôm nay
                    string queryHoaDon = "SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayTao AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, conn);
                    int soHoaDon = (int)cmdHoaDon.ExecuteScalar();
                    lblTongHoaDon.Text = soHoaDon.ToString();

                    // 3. Lấy số bàn đang có khách
                    string queryBan = "SELECT COUNT(*) FROM Ban WHERE TrangThai = N'Có khách'";
                    SqlCommand cmdBan = new SqlCommand(queryBan, conn);
                    int soBanCoKhach = (int)cmdBan.ExecuteScalar();
                    lblBanCoKhach.Text = soBanCoKhach.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu dashboard: " + ex.Message);
                }
            }
        }

        // Hàm tải danh sách các món bán chạy nhất
        private void LoadMonBanChay()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Câu SQL này hơi phức tạp:
                    // - Nối bảng Chi Tiết và bảng Món để lấy Tên Món
                    // - Gom nhóm theo Tên Món và tính tổng số lượng bán được
                    // - Sắp xếp giảm dần và lấy 5 món đầu tiên
                    string query = @"SELECT TOP 5
                                    m.TenMon,
                                    SUM(ct.SL) AS TongSoLuong
                                 FROM CTHoaDon ct
                                 JOIN Mon m ON ct.MaMon = m.MaMon
                                 GROUP BY m.TenMon
                                 ORDER BY TongSoLuong DESC";

                    // Sử dụng SqlDataAdapter để đổ dữ liệu vào DataTable, rất tiện lợi
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dgvMonBanChay.DataSource = dt;

                    // Chỉnh lại tên cột cho đẹp
                    dgvMonBanChay.Columns["TenMon"].HeaderText = "Tên Món";
                    dgvMonBanChay.Columns["TongSoLuong"].HeaderText = "Số Lượng Bán";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách món bán chạy: " + ex.Message);
                }
            }

        }

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để đặt lại mật khẩu.", "Chưa chọn nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hỏi xác nhận trước khi thực hiện
            string tenNhanVien = dgvNhanVien.SelectedRows[0].Cells["HoTen"].Value.ToString();
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn đặt lại mật khẩu cho nhân viên '{tenNhanVien}' không?",
                                                     "Xác nhận hành động",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // 3. Lấy MaNV từ dòng đang được chọn
                int maNV = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value);

                // Mật khẩu mặc định mới. Bạn có thể thay đổi tùy ý.
                string matKhauMoi = "123456";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // 4. Câu lệnh SQL để cập nhật mật khẩu trong bảng NguoiDung
                        string query = "UPDATE NguoiDung SET MatKhau = @MatKhauMoi WHERE MaNV = @MaNV";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi); // !! Nên mã hóa mật khẩu
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                        int result = cmd.ExecuteNonQuery();

                        // 5. Thông báo kết quả
                        if (result > 0)
                        {
                            MessageBox.Show($"Đã đặt lại mật khẩu thành công cho nhân viên '{tenNhanVien}'. Mật khẩu mới là: {matKhauMoi}",
                                            "Thành công",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản tương ứng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đặt lại mật khẩu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Hàm tải danh sách Vai Trò vào ComboBox
        private void LoadVaiTroToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT MaVT, TenVT FROM VaiTro";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Cấu hình cho ComboBox
                    cboVaiTro.DataSource = dt;
                    cboVaiTro.DisplayMember = "TenVT"; // Hiển thị tên vai trò
                    cboVaiTro.ValueMember = "MaVT";    // Lấy giá trị là mã vai trò
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách vai trò: " + ex.Message);
                }
            }
        }

        // Hàm tải danh sách Nhân viên vào DataGridView
        private void LoadNhanVienToGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Câu lệnh SQL JOIN 3 bảng để lấy đủ thông tin
                    string query = @"SELECT 
                                nv.MaNV, nv.HoTen, nv.SDT, nv.Email, nv.NgayVaoLam, nv.TrangThai,
                                nd.TenDN, vt.TenVT
                             FROM NhanVien nv
                             LEFT JOIN NguoiDung nd ON nv.MaNV = nd.MaNV
                             LEFT JOIN VaiTro vt ON nd.MaVT = vt.MaVT";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvNhanVien.DataSource = dt;

                    // Chỉnh lại tên cột cho đẹp
                    dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
                    dgvNhanVien.Columns["SDT"].HeaderText = "SĐT";
                    dgvNhanVien.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
                    dgvNhanVien.Columns["TrangThai"].HeaderText = "Còn làm";
                    dgvNhanVien.Columns["TenDN"].HeaderText = "Tên đăng nhập";
                    dgvNhanVien.Columns["TenVT"].HeaderText = "Vai trò";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng không click vào header và có dòng được chọn
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count - 1)
            {
                // Lấy ra dòng đang được chọn
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Điền dữ liệu từ dòng đó vào các control
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);

                // Xử lý các giá trị có thể là NULL
                txtTenDN.Text = row.Cells["TenDN"].Value?.ToString() ?? "";

                string tenVaiTro = row.Cells["TenVT"].Value?.ToString();
                if (!string.IsNullOrEmpty(tenVaiTro))
                {
                    cboVaiTro.Text = tenVaiTro; // Tự động chọn vai trò trong ComboBox
                }
                else
                {
                    cboVaiTro.SelectedIndex = -1; // Không chọn gì nếu không có vai trò
                }

                // Để mật khẩu trống vì lý do bảo mật
                txtMatKhau.Text = "";
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTenDN.Clear();
            txtMatKhau.Clear();
            dtpNgayVaoLam.Value = DateTime.Now; // Đặt ngày vào làm là ngày hiện tại
            cboVaiTro.SelectedIndex = -1; // Bỏ chọn vai trò
            chkTrangThai.Checked = true; // Mặc định là "Còn làm"

            // Bỏ chọn dòng đang được chọn trong DataGridView
            dgvNhanVien.ClearSelection();

            // Di chuyển con trỏ chuột đến ô Họ Tên để người dùng nhập liệu
            txtHoTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- 1. Kiểm tra dữ liệu đầu vào (Validation) ---
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenDN.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }
            if (cboVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò cho tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. Xác định là Thêm mới hay Cập nhật ---
            // Nếu không có dòng nào được chọn, nghĩa là đang thêm mới
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                // --- THÊM MỚI ---
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }

                // Dùng transaction để đảm bảo cả 2 lệnh insert đều thành công
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // Bước 1: Thêm vào bảng NhanVien và lấy MaNV vừa tạo
                        string queryNhanVien = "INSERT INTO NhanVien (HoTen, SDT, Email, NgayVaoLam, TrangThai) OUTPUT INSERTED.MaNV VALUES (@HoTen, @SDT, @Email, @NgayVaoLam, @TrangThai)";
                        SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                        cmdNhanVien.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmdNhanVien.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmdNhanVien.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmdNhanVien.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value);
                        cmdNhanVien.Parameters.AddWithValue("@TrangThai", chkTrangThai.Checked);

                        // Lấy MaNV mới
                        int newMaNV = (int)cmdNhanVien.ExecuteScalar();

                        // Bước 2: Thêm vào bảng NguoiDung với MaNV vừa có
                        string queryNguoiDung = "INSERT INTO NguoiDung (TenDN, MatKhau, MaNV, MaVT) VALUES (@TenDN, @MatKhau, @MaNV, @MaVT)";
                        SqlCommand cmdNguoiDung = new SqlCommand(queryNguoiDung, conn, transaction);
                        cmdNguoiDung.Parameters.AddWithValue("@TenDN", txtTenDN.Text);
                        cmdNguoiDung.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text); // !! Nên mã hóa mật khẩu ở đây
                        cmdNguoiDung.Parameters.AddWithValue("@MaNV", newMaNV);
                        cmdNguoiDung.Parameters.AddWithValue("@MaVT", cboVaiTro.SelectedValue);
                        cmdNguoiDung.ExecuteNonQuery();

                        // Nếu mọi thứ thành công, commit transaction
                        transaction.Commit();
                        MessageBox.Show("Thêm nhân viên mới thành công!", "Thành công");
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback lại tất cả
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi");
                    }
                }
            }
            else
            {
                // --- CẬP NHẬT ---
                // Lấy MaNV từ dòng đang được chọn
                int maNV = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // Bước 1: Cập nhật bảng NhanVien
                        string queryNhanVien = "UPDATE NhanVien SET HoTen = @HoTen, SDT = @SDT, Email = @Email, NgayVaoLam = @NgayVaoLam, TrangThai = @TrangThai WHERE MaNV = @MaNV";
                        SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                        cmdNhanVien.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmdNhanVien.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmdNhanVien.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmdNhanVien.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value);
                        cmdNhanVien.Parameters.AddWithValue("@TrangThai", chkTrangThai.Checked);
                        cmdNhanVien.Parameters.AddWithValue("@MaNV", maNV);
                        cmdNhanVien.ExecuteNonQuery();

                        // Bước 2: Cập nhật bảng NguoiDung
                        string queryNguoiDung = "UPDATE NguoiDung SET TenDN = @TenDN, MaVT = @MaVT WHERE MaNV = @MaNV";
                        // Nếu người dùng nhập mật khẩu mới thì mới cập nhật
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            queryNguoiDung = "UPDATE NguoiDung SET TenDN = @TenDN, MatKhau = @MatKhau, MaVT = @MaVT WHERE MaNV = @MaNV";
                        }
                        SqlCommand cmdNguoiDung = new SqlCommand(queryNguoiDung, conn, transaction);
                        cmdNguoiDung.Parameters.AddWithValue("@TenDN", txtTenDN.Text);
                        cmdNguoiDung.Parameters.AddWithValue("@MaVT", cboVaiTro.SelectedValue);
                        cmdNguoiDung.Parameters.AddWithValue("@MaNV", maNV);
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            cmdNguoiDung.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        }
                        cmdNguoiDung.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi");
                    }
                }
            }

            // --- 3. Tải lại dữ liệu lên GridView ---
            LoadNhanVienToGrid();
            // Xóa trắng các ô để chuẩn bị cho lần thao tác tiếp theo
            btnThemMoi_Click(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cho nhân viên này nghỉ việc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Lấy MaNV từ dòng đang được chọn
                int maNV = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Chỉ cần cập nhật trạng thái, không cần xóa
                        string query = "UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = @MaNV";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Đã cập nhật trạng thái nghỉ việc cho nhân viên.", "Thành công");
                            LoadNhanVienToGrid(); // Tải lại danh sách
                            btnThemMoi_Click(null, null); // Xóa trắng các ô
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi");
                    }
                }
            }
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            // Trong tương lai, chúng taa có thể mở một form mới ở đây
            // vd: FormQuanLyDanhMuc f = new FormQuanLyDanhMuc();
            // f.ShowDialog();
            // Sau khi form đó đóng, tải lại ComboBox: LoadDanhMucToComboBox();

            MessageBox.Show("Chức năng quản lý danh mục sẽ được phát triển sau!", "Thông báo");

        }

        // Hàm tải danh sách Danh mục vào ComboBox
        private void LoadDanhMucToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT MaDM, TenDM FROM DanhMuc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboDanhMuc.DataSource = dt;
                    cboDanhMuc.DisplayMember = "TenDM";
                    cboDanhMuc.ValueMember = "MaDM";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
                }
            }
        }

        // Hàm tải danh sách Món vào Grid dựa trên danh mục được chọn
        private void LoadMonAnToGrid(int maDM)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT MaMon, TenMon, DonGia, HoatDong FROM Mon WHERE MaDM = @MaDM";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaDM", maDM);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMonAn.DataSource = dt;

                    // Chỉnh tên cột
                    dgvMonAn.Columns["MaMon"].HeaderText = "Mã Món";
                    dgvMonAn.Columns["TenMon"].HeaderText = "Tên Món";
                    dgvMonAn.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvMonAn.Columns["HoatDong"].HeaderText = "Còn Bán";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách món: " + ex.Message);
                }
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (cboDanhMuc.SelectedValue != null)
            {
               // int maDM = Convert.ToInt32(cboDanhMuc.SelectedValue);
                // SỬA LẠI NHƯ SAU
                int maDM = Convert.ToInt32(((DataRowView)cboDanhMuc.SelectedItem)["MaDM"]);
                LoadMonAnToGrid(maDM);
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonAn.Rows.Count - 1)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];

                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                numDonGia.Value = Convert.ToDecimal(row.Cells["DonGia"].Value);
                chkHoatDong.Checked = Convert.ToBoolean(row.Cells["HoatDong"].Value);
            }
        }

        private void btnThemMoiMon_Click(object sender, EventArgs e)
        {
            // Xóa trắng các ô
            txtTenMon.Clear();
            numDonGia.Value = 0;
            chkHoatDong.Checked = true; // Mặc định là "Còn bán"

            // Bỏ chọn dòng trong DataGridView
            dgvMonAn.ClearSelection();

            // Đưa con trỏ vào ô Tên món
            txtTenMon.Focus();
        }

        private void btnLuuMon_Click(object sender, EventArgs e)
        {
            // --- 1. Kiểm tra dữ liệu đầu vào ---
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }
            if (cboDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDM = Convert.ToInt32(cboDanhMuc.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // --- 2. Xác định là Thêm mới hay Cập nhật ---
                    if (dgvMonAn.SelectedRows.Count == 0)
                    {
                        // --- THÊM MỚI ---
                        string query = "INSERT INTO Mon (MaDM, TenMon, DonGia, HoatDong) VALUES (@MaDM, @TenMon, @DonGia, @HoatDong)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaDM", maDM);
                        cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                        cmd.Parameters.AddWithValue("@DonGia", numDonGia.Value);
                        cmd.Parameters.AddWithValue("@HoatDong", chkHoatDong.Checked);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm món mới thành công!", "Thành công");
                    }
                    else
                    {
                        // --- CẬP NHẬT ---
                        // Lấy MaMon từ dòng đang được chọn
                        int maMon = Convert.ToInt32(dgvMonAn.SelectedRows[0].Cells["MaMon"].Value);

                        string query = "UPDATE Mon SET TenMon = @TenMon, DonGia = @DonGia, HoatDong = @HoatDong, MaDM = @MaDM WHERE MaMon = @MaMon";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                        cmd.Parameters.AddWithValue("@DonGia", numDonGia.Value);
                        cmd.Parameters.AddWithValue("@HoatDong", chkHoatDong.Checked);
                        cmd.Parameters.AddWithValue("@MaDM", maDM);
                        cmd.Parameters.AddWithValue("@MaMon", maMon);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật món thành công!", "Thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu món: " + ex.Message, "Lỗi");
                }
            }

            // --- 3. Tải lại dữ liệu và xóa trắng các ô ---
            LoadMonAnToGrid(maDM);
            btnThemMoiMon_Click(null, null);
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có món nào được chọn không
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa món này không? Hành động này không thể hoàn tác.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int maMon = Convert.ToInt32(dgvMonAn.SelectedRows[0].Cells["MaMon"].Value);
                int maDM = Convert.ToInt32(cboDanhMuc.SelectedValue);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Câu lệnh xóa món khỏi CSDL
                        string query = "DELETE FROM Mon WHERE MaMon = @MaMon";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaMon", maMon);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa món thành công.", "Thành công");
                            // Tải lại Grid và xóa trắng các ô
                            LoadMonAnToGrid(maDM);
                            btnThemMoiMon_Click(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Bắt lỗi nếu món ăn đã tồn tại trong hóa đơn
                        MessageBox.Show("Lỗi khi xóa món: Món này có thể đã được sử dụng trong một hóa đơn cũ. Bạn chỉ nên tắt hoạt động của nó.", "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}