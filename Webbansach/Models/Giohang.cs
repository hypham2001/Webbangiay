using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbansach.Models;
namespace Webbansach.Models
{
    public class Giohang
    {
        //Tao doi tuong data chua dữ liệu từ model dbBansach đã tạo. 
        dbQLBangiayDataContext data = new dbQLBangiayDataContext();
        public int iMaGiay { set; get; }
        public string sTengiay { set; get; }
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
        //Khoi tao gio hàng theo Masach duoc truyen vao voi Soluong mac dinh la 1
        public Giohang(int Magiay)
        {
            iMaGiay = Magiay;
            GIAY giay = data.GIAY.Single(n => n.Magiay == iMaGiay);
            sTengiay = giay.Tengiay;
            sAnhbia = giay.Anhbia;
            dDongia = double.Parse(giay.Giaban.ToString());
            iSoluong = 1;
        }
    }
}