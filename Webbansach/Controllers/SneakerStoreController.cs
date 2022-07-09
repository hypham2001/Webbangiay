using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;
using PagedList;
using PagedList.Mvc;

namespace Webbansach.Controllers
{
    public class SneakerStoreController : Controller
    {
        dbQLBangiayDataContext data = new dbQLBangiayDataContext();

        private List<GIAY> Laygiaymoi(int count)
        {
            return data.GIAY.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }

        public ActionResult Index(int ? page)
        {
            int pagesize = 8;
            int pagenum = (page ?? 1);
            var giaymoi = Laygiaymoi(15);
            return View(giaymoi.ToPagedList(pagenum, pagesize));
        }

        public ActionResult ThuongHieu()
        {
            var th = from i in data.THUONGHIEU select i;
            return PartialView(th);
        }

        public ActionResult GiayTheoThuongHieu(int id, int? page)
        {
            int pagesize = 8;
            int pagenum = (page ?? 1);

            List<GIAY> giay = data.GIAY.Where(p => p.MaThuongHieu == id).ToList();
            ViewBag.MaThuongHieu = id;
            ViewBag.TenThuongHieu = data.THUONGHIEU.Single(p => p.MaThuonghieu == id).TenThuongHieu;
            return View(giay.ToPagedList(pagenum, pagesize));

        }
        public ActionResult Chitietgiay(int id)
        {
            var giay = from s in data.GIAY where s.Magiay == id select s;
            return View(giay.Single());
        }
    }
}