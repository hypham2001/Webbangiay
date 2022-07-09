using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using Webbansach.ViewModels;

namespace Webbansach.Controllers
{
    public class AdminController : Controller
    {
        dbQLBangiayDataContext data = new dbQLBangiayDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var tendn = f["Username"];
            var matkhau = f["Password"];
            if (String.IsNullOrEmpty(tendn))
                ViewData["Loi1"] = "Vui lòng nhập tên đăng nhập";
            else if (String.IsNullOrEmpty(matkhau))
                ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
            else
            {
                var ad = data.ADMIN.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("TaiKhoan", "Admin");
                }
                else
                    ViewData["Loi"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
            }

            return View();
        }

        public ActionResult TaiKhoan()
        {
            List<KHACHHANG> kHACHHANGs = data.KHACHHANG.ToList();
            return View(kHACHHANGs);
        }

        public ActionResult EditTaiKhoan(int id)
        {
            if (data.KHACHHANG.Any(p => p.MaKH == id))
            {
                KHACHHANG kHACHHANG = data.KHACHHANG.Single(p => p.MaKH == id);

                KhachHangViewModel khachHangViewModel = new KhachHangViewModel
                {
                    MaKH = kHACHHANG.MaKH,
                    HoTen = kHACHHANG.HoTen,
                    Taikhoan = kHACHHANG.Taikhoan,
                    Matkhau = kHACHHANG.Matkhau,
                    Email = kHACHHANG.Email,
                    DiachiKH = kHACHHANG.DiachiKH,
                    DienthoaiKH = kHACHHANG.DienthoaiKH,
                    Ngaysinh = Convert.ToDateTime(kHACHHANG.Ngaysinh)
                };

                return View(khachHangViewModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTaiKhoan(KhachHangViewModel viewmodel)
        {
            if (data.KHACHHANG.Any(p => p.MaKH == viewmodel.MaKH))
            {
                KHACHHANG kHACHHANG = data.KHACHHANG.Single(p => p.MaKH == viewmodel.MaKH);

                kHACHHANG.HoTen = viewmodel.HoTen;
                kHACHHANG.Matkhau = viewmodel.Matkhau;
                kHACHHANG.Email = viewmodel.Email;
                kHACHHANG.DiachiKH = viewmodel.DiachiKH;
                kHACHHANG.DienthoaiKH = viewmodel.DiachiKH;
                kHACHHANG.Ngaysinh = Convert.ToDateTime(kHACHHANG.Ngaysinh);

                data.SaveChanges();
                List<KHACHHANG> kHACHHANGs = data.KHACHHANG.ToList();
                return RedirectToAction("TaiKhoan", "Admin");
            }
            return View();
        }

        public ActionResult DetailTaiKhoan(int id)
        {
            if (data.KHACHHANG.Any(p => p.MaKH == id))
            {
                KHACHHANG kHACHHANG = data.KHACHHANG.Single(p => p.MaKH == id);

                return View(kHACHHANG);
            }
            return View();
        }

        public ActionResult DeleteTaiKhoan(int id, string CurrentURL)
        {
            if (data.KHACHHANG.Any(p => p.MaKH == id))
            {
                KHACHHANG kHACHHANG = data.KHACHHANG.Single(p => p.MaKH == id);
                kHACHHANG.TinhTrang = !kHACHHANG.TinhTrang;
                data.SaveChanges();
                return Redirect(CurrentURL);
            }
            return View();
        }

        public ActionResult ThuongHieu()
        {
            List<THUONGHIEU> th = data.THUONGHIEU.ToList();
            return View(th);
        }

        public ActionResult EditThuongHieu(int id)
        {
            if (data.THUONGHIEU.Any(p => p.MaThuonghieu == id))
            {
                THUONGHIEU tHUONGHIEU = data.THUONGHIEU.FirstOrDefault(p => p.MaThuonghieu == id);
                ThuongHieuViewModel viewModel = new ThuongHieuViewModel
                {
                    MaThuonghieu = tHUONGHIEU.MaThuonghieu,
                    TenThuongHieu = tHUONGHIEU.TenThuongHieu,
                    Diachi = tHUONGHIEU.Diachi,
                    DienThoai = tHUONGHIEU.DienThoai
                };
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditThuongHieu(int id, ThuongHieuViewModel thuongHieu)
        {
            THUONGHIEU tHUONGHIEU = data.THUONGHIEU.FirstOrDefault(p => p.MaThuonghieu == id);
            tHUONGHIEU.TenThuongHieu = thuongHieu.TenThuongHieu;
            tHUONGHIEU.Diachi = thuongHieu.Diachi;
            tHUONGHIEU.DienThoai = thuongHieu.DienThoai;
            data.SaveChanges();
            return RedirectToAction("ThuongHieu", "Admin");
        }

        public ActionResult DetailThuongHieu(int id)
        {
            if (data.THUONGHIEU.Any(p => p.MaThuonghieu == id))
            {
                THUONGHIEU tHUONGHIEU = data.THUONGHIEU.Single(p => p.MaThuonghieu == id);
                return View(tHUONGHIEU);
            }
            return View();
        }

        public ActionResult Giay()
        {
            List<GIAY> giays = data.GIAY.ToList();
            return View(giays);
        }

        public ActionResult EditGiay(int id)
        {
            if (data.GIAY.Any(p => p.Magiay == id))
            {
                GIAY giay = data.GIAY.Single(p => p.Magiay == id);
                ViewBag.ThuongHieu = data.THUONGHIEU.ToList();

                GiayViewModel viewModel = new GiayViewModel
                {
                    Magiay = giay.Magiay,
                    Tengiay = giay.Tengiay,
                    Giaban = giay.Giaban,
                    Mota = giay.Mota,
                    Anhbia = giay.Anhbia,
                    Ngaycapnhat = giay.Ngaycapnhat,
                    Soluongton = giay.Soluongton,
                    MaThuongHieu = giay.MaThuongHieu
                };

                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditGiay(GiayViewModel viewModel)
        {
            if (data.GIAY.Any(p => p.Magiay == viewModel.Magiay))
            {
                GIAY giay = data.GIAY.Single(p => p.Magiay == viewModel.Magiay);

                giay.Tengiay = viewModel.Tengiay;
                giay.Giaban = viewModel.Giaban;
                giay.Mota = viewModel.Mota;
                giay.Soluongton = viewModel.Soluongton;
                giay.MaThuongHieu = viewModel.MaThuongHieu;
                data.SaveChanges();

                return RedirectToAction("Giay", "Admin");
            }
            return View();
        }

        public ActionResult DetailGiay(int id)
        {
            if (data.GIAY.Any(p => p.Magiay == id))
            {
                GIAY giay = data.GIAY.Single(p => p.Magiay == id);
                return View(giay);
            }
            return View();
        }

        public ActionResult DeleteGiay(int id, string CurrentURL)
        {
            if (data.GIAY.Any(p => p.Magiay == id))
            {
                GIAY giay = data.GIAY.Single(p => p.Magiay == id);
                giay.TinhTrang = !giay.TinhTrang;
                data.SaveChanges();
                return Redirect(CurrentURL);
            }
            return View();
        }

        public ActionResult DonHang()
        {
            List<DONDATHANG> ds = data.DONDATHANG.ToList();
            return View(ds);
        }

        public ActionResult DetailDonHang(int id)
        {
            if (data.DONDATHANG.Any(p => p.MaDonHang == id))
            {
                List<CHITIETDONTHANG> ctddh = (from A in data.DONDATHANG
                                               join B in data.CHITIETDONTHANG
                                               on A.MaDonHang equals B.MaDonHang
                                               where A.MaDonHang == id
                                               select B).ToList();
                return View(ctddh);
            }
            return View();
        }

        public ActionResult ThayDoiTrangThai(int id, string CurrentURL)
        {
            if (data.DONDATHANG.Any(p => p.MaDonHang == id))
            {
                DONDATHANG ddh = data.DONDATHANG.Single(p => p.MaDonHang == id);
                ddh.Tinhtranggiaohang = !ddh.Tinhtranggiaohang;
                data.SaveChanges();
                return Redirect(CurrentURL);
            }
            return View();
        } 

        public ActionResult DangXuat()
        {
            Session["Taikhoanadmin"] = null;
            return View("Login", "Admin");
        }
    } 
}