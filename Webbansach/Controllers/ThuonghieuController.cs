using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;

namespace Webbansach.Controllers
{
    public class ThuonghieuController : Controller
    {
        dbQLBangiayDataContext data = new dbQLBangiayDataContext();
        //1. Hiện thị danh sách các thương hiệu
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.THUONGHIEU.ToList());
        }
        //2. Hiện thi chi tiết 1 thương hiệu
        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var th = from i in data.THUONGHIEU where i.MaThuonghieu == id select i;
                return View(th.SingleOrDefault());
            }
        }
        //3. Thêm mới thương hiệu
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
        }
        [HttpPost]
        public ActionResult Create(THUONGHIEU thuonghieu)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                data.THUONGHIEU.Add(thuonghieu);
                data.SaveChanges();
                
                return RedirectToAction("Index", "ThuongHieu");
            }
        }
        //4. Xóa 1 thương hiệu gồm 2 trang: xác nhận xóa và xử lý xóa
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var th = from i in data.THUONGHIEU where i.MaThuonghieu == id select i;
                return View(th.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                THUONGHIEU th = data.THUONGHIEU.SingleOrDefault(n => n.MaThuonghieu==id);
                data.THUONGHIEU.Remove(th);
                data.SaveChanges();
                
                return RedirectToAction("Index", "ThuongHieu");
            }
        }
        //5. Điều chỉnh thông tin 1  thương hiệu gồm 2 trang: Xem và điều chỉnh và cập nhật lưu lại
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var th = from i in data.THUONGHIEU where i.MaThuonghieu == id select i;
                return View(th.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                THUONGHIEU th = data.THUONGHIEU.SingleOrDefault(n => n.MaThuonghieu == id);

                UpdateModel(th);
                data.SaveChanges();
                return RedirectToAction("Index", "ThuongHieu");
            }
        }
    }
}