using System.Data.SqlClient;
using System.Configuration;

namespace demo_app
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy chuỗi kết nối đã lưu trong file App.config
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            // Lấy dữ liệu người dùng nhập vào
            // !!! Hãy chắc chắn tên control của bạn là txtUsername và txtPassword !!!
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. KIỂM TRA NHẬP LIỆU CƠ BẢN
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. KẾT NỐI VÀ TRUY VẤN DATABASE
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // === THAY ĐỔI 1: CÂU LỆNH SQL ===
                    // Thay vì đếm, chúng ta lấy ra Tên Vai Trò (TenVT)
                    // bằng cách nối (JOIN) bảng NguoiDung với bảng VaiTro
                    string query = @"SELECT T2.TenVT 
                             FROM NguoiDung AS T1
                             INNER JOIN VaiTro AS T2 ON T1.MaVT = T2.MaVT
                             WHERE T1.TenDN = @user AND T1.MatKhau = @pass";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", password);

                    // === THAY ĐỔI 2: LẤY KẾT QUẢ VAI TRÒ ===
                    // ExecuteScalar vẫn phù hợp vì ta chỉ cần 1 giá trị (tên vai trò)
                    // Dùng object để có thể kiểm tra null một cách an toàn
                    object result = command.ExecuteScalar();

                    // 3. KIỂM TRA KẾT QUẢ VÀ PHÂN QUYỀN
                    if (result != null) // Nếu tìm thấy tài khoản (result không phải là null)
                    {
                        string vaiTro = result.ToString(); // Lấy tên vai trò

                        MessageBox.Show($"Đăng nhập thành công với vai trò: {vaiTro}", "Thành công");

                        // === THAY ĐỔI 3: PHÂN LUỒNG MỞ FORM ===
                        // Dựa vào chuỗi vaiTro để quyết định mở form nào
                        if (vaiTro == "Admin")
                        {
                            // Giả sử bạn có form tên là AdminForm
                            AdminForm f = new AdminForm();
                            f.Show();
                            this.Hide(); // Ẩn form đăng nhập
                        }
                        else if (vaiTro == "Quản lý") // Dựa theo yêu cầu ban đầu của bạn
                        {
                            // Giả sử bạn có form tên là QuanLiForm
                            QuanLiForm f = new QuanLiForm();
                            f.Show();
                            this.Hide();
                        }
                        else if (vaiTro == "Thu ngân") // Dựa theo dữ liệu mẫu bạn cung cấp
                        {
                            // Thu ngân có thể vào MainForm hoặc một form bán hàng riêng
                            MainForm f = new MainForm();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Vai trò của bạn không được hỗ trợ trong hệ thống.", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Nếu result là null, tức là không tìm thấy dòng nào khớp
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc truy vấn CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
