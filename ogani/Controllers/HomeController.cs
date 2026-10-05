using Microsoft.AspNetCore.Mvc;
using ogani.Models;
using System.Diagnostics;
using X.PagedList;

namespace ogani.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlbanVaLiContext _context;

        public HomeController(QlbanVaLiContext context)
        {
            this._context = context;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 1 ? 1 : (int)page;
            var sanPham = _context.TDanhMucSps.ToList(); //lay toan bo danh sach san pham tu bang tdanhmucsp chjuyen thanh list
            PagedList<TDanhMucSp> pageSanPham = new PagedList<TDanhMucSp>(sanPham, pageNumber, pageSize); //chuyen doi sang dang PagedList
            return View(pageSanPham);
        }

        [HttpGet]
        public IActionResult xoaSanPham(string maSP)
        {
            var sanPham = _context.TDanhMucSps.FirstOrDefault(s => s.MaSp == maSP);

            _context.TAnhSps.RemoveRange(_context.TAnhSps.Where(a => a.MaSp == maSP).ToList());
            _context.TChiTietSanPhams.RemoveRange(_context.TChiTietSanPhams.Where(a => a.MaSp == maSP).ToList());
            _context.TDanhMucSps.Remove(sanPham);
            _context.SaveChanges();

            TempData["XoaThanhCong"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
