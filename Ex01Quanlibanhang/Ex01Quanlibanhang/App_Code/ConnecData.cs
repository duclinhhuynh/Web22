using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace Ex01Quanlibanhang.App_Code
{
    public class ConnecData
    {
        OleDbConnection cnn;
        /// <summary>
        /// Hàm khởi tạo của lớp KETNOIDULIEU
        /// Khởi tạo đối tượng cnn
        /// khởi tạo chuỗi kết nối thông qua thuộc tính
        /// ConnectionString
        /// </summary>
        public ConnecData(System.Web.UI.Page p)
        {
            cnn = new OleDbConnection();
            cnn.ConnectionString = "provider=Microsoft.Jet.Oledb.4.0;Data Source=" +
            p.Server.MapPath(".\\App_Data\\quanlybanhang.mdb");
        }
        /// <summary>
        //Phương thức mở kết nối nếu thành công
        /// trả về kết quả có giá trị là True
        /// thất bại trả về giá trị false
        /// </summary>
        /// <returns></returns>
        public bool Moketnoi()
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                return true;
            }
            catch (OleDbException ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Phương thức đóng kết nối
        /// sau khi mở kết nối để thao tác dữ liệu
        ///</summary>
        public void Dongketnoi()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        /// <summary>
        /// Phương thức thực thi lệnh
        /// SQL(Insert into, Delete, Update)
        /// Phương thức này chỉ thực thi lệnh
        /// SQL (thêm mới dữ liệu, xoá dữ liệu,Sửa dữ liệu)
        ///</summary>
        /// <param name="SQL"> </param>
        public void ThucthiSQL(String SQL)
        {
            if (this.Moketnoi())
            {
                OleDbCommand cmd = new OleDbCommand(SQL, cnn);
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable Bang(String SQL)
        {
            if (this.Moketnoi())
            {
                OleDbDataAdapter adp = new OleDbDataAdapter(SQL, cnn);
                DataTable tb = new DataTable();
                adp.Fill(tb);
                return tb;
            }
            return null;
        }
    }

}