using demo_app.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace demo_app
{
    public partial class MainForm : Form
    {
        private int selectedTableID = -1; // Biến lưu mã bàn đang được chọn
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTableList();

            LoadCategoryComboBox(); // Gọi hàm tải danh mục

        }

        void LoadTableList()
        {
            // Xóa các button bàn cũ trước khi tải lại
            flpTable.Controls.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaBan, TenBan, TrangThai FROM Ban";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Tạo một button mới cho mỗi bàn
                        Button btn = new Button() { Width = 90, Height = 90 };

                        // Lấy thông tin từ database
                        int maBan = reader.GetInt32(0);
                        string tenBan = reader.GetString(1);
                        string trangThai = reader.GetString(2);

                        // Thiết lập hiển thị cho button
                        btn.Text = tenBan + Environment.NewLine + trangThai;
                        btn.Tag = maBan; // Lưu lại mã bàn để dùng sau này

                        // Đặt màu nền dựa vào trạng thái
                        switch (trangThai)
                        {
                            case "Trống":
                                btn.BackColor = Color.LightGreen;
                                break;
                            default: // Có khách, Đã đặt, etc.
                                btn.BackColor = Color.LightCoral;
                                break;
                        }

                        // Thêm sự kiện Click
                        btn.Click += tableButton_Click;

                        // Thêm button vào FlowLayoutPanel
                        flpTable.Controls.Add(btn);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách bàn: " + ex.Message);
                }
            }
        }



        void LoadCategoryComboBox()
        {
            // Code để lấy dữ liệu từ DB và đổ vào ComboBox
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {connection.Open();
                    
                    string query = "SELECT MaDM, TenDM FROM DanhMuc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbCategory.DataSource = dt;
                    cbCategory.DisplayMember = "TenDM"; // Hiển thị tên danh mục
                    cbCategory.ValueMember = "MaDM";   // Giá trị ẩn là mã danh mục
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
                }
            }
        }



        // Sự kiện được gọi khi bấm vào bất kỳ nút bàn nào
        void tableButton_Click(object sender, EventArgs e)
        {
            // Lấy mã bàn được lưu trong Tag của button
            //Button clickedButton = sender as Button;
            //int tableID = (int)clickedButton.Tag;

            //// Tạm thời hiển thị mã bàn để kiểm tra
            //MessageBox.Show("Bạn đã chọn bàn có mã số: " + tableID);

            // TODO: Các bước tiếp theo sẽ hiển thị hóa đơn của bàn này

            //tieepspppp
            // Lấy mã bàn được lưu trong Tag của button
            //Button clickedButton = sender as Button;
            //int tableID = (int)clickedButton.Tag;
            // Gọi hàm hiển thị hóa đơn cho bàn được chọn
            //ShowBill(tableID);

            Button clickedButton = sender as Button;
            selectedTableID = (int)clickedButton.Tag; // Lưu lại mã bàn

            // Hiển thị Hóa đơn (giữ nguyên như cũ)
            ShowBill(selectedTableID);



        }

        // Hàm hiển thị hóa đơn cho một bàn cụ thể
        void ShowBill(int tableID)
        {
            // Xóa các món cũ trong ListView
            lvBill.Items.Clear();
            float totalPrice = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Câu lệnh SQL để lấy chi tiết hóa đơn của bàn đang có trạng thái "Mở"
                    string query = @"SELECT m.TenMon, c.SL, m.DonGia, c.ThanhTien
                           FROM CTHoaDon AS c
                           JOIN HoaDon AS h ON c.MaHD = h.MaHD
                           JOIN Mon AS m ON c.MaMon = m.MaMon
                           WHERE h.MaBan = @MaBan AND h.TrangThai = N'Mở'";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBan", tableID);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Tạo một dòng mới cho ListView
                        ListViewItem item = new ListViewItem(reader["TenMon"].ToString());

                        // Thêm các cột phụ
                        item.SubItems.Add(reader["SL"].ToString());
                        item.SubItems.Add(string.Format("{0:N0}", reader["DonGia"])); // Định dạng số cho đẹp
                        item.SubItems.Add(string.Format("{0:N0}", reader["ThanhTien"])); // Định dạng số cho đẹp

                        // Tính tổng tiền
                        totalPrice += Convert.ToSingle(reader["ThanhTien"]);

                        // Thêm dòng vào ListView
                        lvBill.Items.Add(item);
                    }
                    reader.Close();

                    // Hiển thị tổng tiền
                    lblTotalPrice.Text = string.Format("{0:N0} VNĐ", totalPrice);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị hóa đơn: " + ex.Message);
                }
            }
        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryID = 0;
            // Đảm bảo rằng có một item đang được chọn và giá trị của nó là một số nguyên
            if (cbCategory.SelectedItem != null && cbCategory.SelectedValue is int)
            {
                categoryID = (int)cbCategory.SelectedValue;
            }

            // Tải danh sách món ăn tương ứng
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaMon, TenMon FROM Mon WHERE MaDM = @MaDM";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaDM", categoryID);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbFood.DataSource = dt;
                    cbFood.DisplayMember = "TenMon";
                    cbFood.ValueMember = "MaMon";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách món ăn: " + ex.Message);
                }
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTableID == -1)
            {
                MessageBox.Show("Vui lòng chọn một bàn trước khi thêm món!");
                return;
            }
            if (cbFood.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một món ăn!");
                return;
            }

            int foodID = (int)cbFood.SelectedValue;
            int quantity = (int)numQuantity.Value;

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // 1. Tìm hóa đơn đang Mở của bàn được chọn
                    string findBillQuery = "SELECT MaHD FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = N'Mở'";
                    SqlCommand findBillCmd = new SqlCommand(findBillQuery, connection);
                    findBillCmd.Parameters.AddWithValue("@MaBan", selectedTableID);
                    object result = findBillCmd.ExecuteScalar();
                    int billID;

                    if (result != null)
                    {
                        billID = (int)result;
                    }
                    else
                    {
                        // 2. Nếu chưa có, tạo hóa đơn mới
                        string soHoaDon = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string createBillQuery = "INSERT INTO HoaDon (SoHD, MaBan, MaND, TrangThai) OUTPUT INSERTED.MaHD VALUES (@SoHD, @MaBan, @MaND, N'Mở')";
                        SqlCommand createBillCmd = new SqlCommand(createBillQuery, connection);
                        createBillCmd.Parameters.AddWithValue("@SoHD", soHoaDon);
                        createBillCmd.Parameters.AddWithValue("@MaBan", selectedTableID);
                        createBillCmd.Parameters.AddWithValue("@MaND", 2); // Tạm thời hardcode MaND
                        billID = (int)createBillCmd.ExecuteScalar();

                        string updateTableQuery = "UPDATE Ban SET TrangThai = N'Có khách' WHERE MaBan = @MaBan";
                        SqlCommand updateTableCmd = new SqlCommand(updateTableQuery, connection);
                        updateTableCmd.Parameters.AddWithValue("@MaBan", selectedTableID);
                        updateTableCmd.ExecuteNonQuery();
                    }

                    // --- PHẦN SỬA LỖI BẮT ĐẦU TỪ ĐÂY ---

                    // A. Lấy đơn giá của món ăn từ bảng Mon
                    string getPriceQuery = "SELECT DonGia FROM Mon WHERE MaMon = @MaMon";
                    SqlCommand getPriceCmd = new SqlCommand(getPriceQuery, connection);
                    getPriceCmd.Parameters.AddWithValue("@MaMon", foodID);
                    decimal donGia = (decimal)getPriceCmd.ExecuteScalar();

                    // B. Thêm món vào chi tiết hóa đơn (bao gồm cả DonGia)
                    string addFoodQuery = "INSERT INTO CTHoaDon (MaHD, MaMon, SL, DonGia) VALUES (@MaHD, @MaMon, @SL, @DonGia)";
                    SqlCommand addFoodCmd = new SqlCommand(addFoodQuery, connection);
                    addFoodCmd.Parameters.AddWithValue("@MaHD", billID);
                    addFoodCmd.Parameters.AddWithValue("@MaMon", foodID);
                    addFoodCmd.Parameters.AddWithValue("@SL", quantity);
                    addFoodCmd.Parameters.AddWithValue("@DonGia", donGia); // <-- Thêm dòng này
                    addFoodCmd.ExecuteNonQuery();

                    // --- KẾT THÚC PHẦN SỬA LỖI ---

                    // 4. Tải lại giao diện
                    ShowBill(selectedTableID);
                    LoadTableList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm món: " + ex.Message);
                }
            }


        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //    // Kiểm tra xem đã chọn bàn và bàn đó có hóa đơn chưa
            //    if (selectedTableID != -1 && lvBill.Items.Count > 0)
            //    {
            //        // Lấy tổng tiền từ label
            //        float totalPrice = float.Parse(lblTotalPrice.Text.Split(' ')[0].Replace(",", ""));

            //        // Lấy mã hóa đơn từ database
            //        int billID = -1;
            //        string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            connection.Open();
            //            string query = "SELECT MaHD FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = N'Mở'";
            //            SqlCommand command = new SqlCommand(query, connection);
            //            command.Parameters.AddWithValue("@MaBan", selectedTableID);
            //            object result = command.ExecuteScalar();
            //            if (result != null)
            //            {
            //                billID = (int)result;
            //            }
            //        }

            //        // --- PHẦN NÂNG CẤP TIẾP THEO SẼ XỬ LÝ Ở ĐÂY ---
            //        // Hiện tại chỉ hiển thị thông báo để xác nhận
            //        DialogResult dialogResult = MessageBox.Show(
            //            string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho Bàn {0}?\nTổng tiền: {1:N0} VNĐ", selectedTableID, totalPrice),
            //            "Xác nhận thanh toán",
            //            MessageBoxButtons.YesNo);

            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            // TODO: Xử lý logic thanh toán (cập nhật DB)
            //            MessageBox.Show("Thanh toán thành công! (Chức năng sẽ được hoàn thiện ở bước sau)");

            //            // Tải lại giao diện
            //            LoadTableList();
            //            ShowBill(selectedTableID);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng chọn bàn có hóa đơn để thanh toán.");
            //    }
            //

            if (selectedTableID != -1 && lvBill.Items.Count > 0)
            {
                float totalPrice = float.Parse(lblTotalPrice.Text.Split(' ')[0].Replace(",", ""));

                DialogResult dialogResult = MessageBox.Show(
                    string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho Bàn {0}?\nTổng tiền: {1:N0} VNĐ", selectedTableID, totalPrice),
                    "Xác nhận thanh toán", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            // Lấy MaHD để xử lý
                            string getBillIDQuery = "SELECT MaHD FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = N'Mở'";
                            SqlCommand getBillIDCmd = new SqlCommand(getBillIDQuery, connection);
                            getBillIDCmd.Parameters.AddWithValue("@MaBan", selectedTableID);
                            int billID = (int)getBillIDCmd.ExecuteScalar();

                            // 1. Cập nhật trạng thái Hóa đơn -> Đã thanh toán
                            string updateBillQuery = "UPDATE HoaDon SET TrangThai = N'Đã thanh toán', TongTien = @TongTien, NgayDong = GETDATE() WHERE MaHD = @MaHD";
                            SqlCommand updateBillCmd = new SqlCommand(updateBillQuery, connection);
                            updateBillCmd.Parameters.AddWithValue("@TongTien", totalPrice);
                            updateBillCmd.Parameters.AddWithValue("@MaHD", billID);
                            updateBillCmd.ExecuteNonQuery();

                            // 2. Thêm vào bảng ThanhToan (giả sử thanh toán tiền mặt)
                            string insertPaymentQuery = "INSERT INTO ThanhToan (MaHD, SoTien, HinhThuc) VALUES (@MaHD, @SoTien, N'Tiền mặt')";
                            SqlCommand insertPaymentCmd = new SqlCommand(insertPaymentQuery, connection);
                            insertPaymentCmd.Parameters.AddWithValue("@MaHD", billID);
                            insertPaymentCmd.Parameters.AddWithValue("@SoTien", totalPrice);
                            insertPaymentCmd.ExecuteNonQuery();

                            // 3. Cập nhật trạng thái Bàn -> Trống
                            string updateTableQuery = "UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = @MaBan";
                            SqlCommand updateTableCmd = new SqlCommand(updateTableQuery, connection);
                            updateTableCmd.Parameters.AddWithValue("@MaBan", selectedTableID);
                            updateTableCmd.ExecuteNonQuery();

                            MessageBox.Show("Thanh toán thành công!");

                            // Tải lại toàn bộ giao diện
                            LoadTableList();
                            ShowBill(selectedTableID);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn có hóa đơn để thanh toán.");
            }
        }


    }
}
