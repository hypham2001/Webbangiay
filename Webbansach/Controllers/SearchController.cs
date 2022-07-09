using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;

namespace Webbansach.Controllers
{
    public class SearchController : Controller
    {
        dbQLBangiayDataContext context = new dbQLBangiayDataContext();

        // GET: Search
        public ActionResult SearchData(string tuKhoa, int? page)
        {
            string data = tuKhoa;
            int pagesize = 8;
            int pagenum = (page ?? 1);

            if (tuKhoa != null)
            {
                data = tuKhoa.ToString().Trim();
            }
            List<GIAY> giayList = new List<GIAY>();
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                giayList = context.GIAY.ToList();
            }
            else
            {
                List<GIAY> timGiayBangTenGiay = context.GIAY.Where(p => p.Tengiay.Contains(data)).ToList();
                List<GIAY> timGiayBangTenThuongHieu = (from A in context.GIAY
                                                       join B in context.THUONGHIEU
                                                       on A.MaThuongHieu equals B.MaThuonghieu
                                                       where B.TenThuongHieu.Contains(data)
                                                       select A).ToList();
                HashSet<GIAY> temp = new HashSet<GIAY>();
                ViewBag.TuKhoa = tuKhoa;
                foreach (var item in timGiayBangTenGiay)
                {
                    temp.Add(item);
                }
                foreach (var item in timGiayBangTenThuongHieu)
                {
                    temp.Add(item);
                }
                

                giayList = temp.ToList();
                return View(giayList.ToPagedList(pagenum, pagesize));
            }
            return View(giayList.ToPagedList(pagenum, pagesize));
        }
    }
}