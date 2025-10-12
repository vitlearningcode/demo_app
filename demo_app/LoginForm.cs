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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 1. KIỂM TRA NHẬP LIỆU CƠ BẢN
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return; // Dừng lại không làm gì thêm
            }

            // 2. KẾT NỐI VÀ TRUY VẤN DATABASE
            // 'using' sẽ đảm bảo kết nối được đóng lại ngay cả khi có lỗi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Câu lệnh SQL để đếm xem có user nào khớp không
                    // Dùng tham số @user và @pass để TRÁNH lỗi bảo mật SQL Injection
                    string query = "SELECT COUNT(1) FROM NguoiDung WHERE TenDN = @user AND MatKhau = @pass";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Gán giá trị cho các tham số
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", password);

                    // Thực thi câu lệnh và lấy kết quả
                    // ExecuteScalar() dùng khi chỉ cần lấy về 1 giá trị duy nhất (ở đây là số đếm)
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // 3. KIỂM TRA KẾT QUẢ
                    if (count == 1)
                    {
                        //// Nếu đếm được 1 dòng, tức là tên đăng nhập và mật khẩu khớp
                        //MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                        // Ở các bước sau, chúng ta sẽ mở form chính ở đây
                        //gòi vô

                            // Đăng nhập thành công
                            // Tạo một đối tượng của MainForm
                            MainForm f = new MainForm();

                            // Hiện MainForm lên
                            f.Show();

                            // Ẩn form đăng nhập hiện tại đi
                            this.Hide();
                        
                    }
                    else
                    {
                        // Nếu không, tức là sai thông tin
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có bất kỳ lỗi nào xảy ra trong quá trình kết nối DB
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }
    }
}
