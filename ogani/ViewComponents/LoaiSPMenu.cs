using Microsoft.AspNetCore.Mvc;
using ogani.Models;

namespace ogani.ViewComponents
{
    public class LoaiSPMenu : ViewComponent
    {
        private readonly QlbanVaLiContext _context;

        public LoaiSPMenu(QlbanVaLiContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            var loaiSP = _context.TLoaiSps.ToList(); //lay toan bo danh sach loai san pham tu bang tloaisp chjuyen thanh list
            return View(loaiSP);
        }
    }
}
