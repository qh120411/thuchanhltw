using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ogani.Models;

namespace ogani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachSanPham : ControllerBase
    {
        private readonly QlbanVaLiContext _context;
        public DanhSachSanPham(QlbanVaLiContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDanhMucSp>>> layTatCa()
        {
              var sanPham = _context.TDanhMucSps.ToListAsync();
              return await sanPham;
        }
        [HttpGet("{maLoai}")]

        public async Task<ActionResult<IEnumerable<TDanhMucSp>>> layTatCa(string maLoai)
        {
            var sanPham = _context.TDanhMucSps.Where(s => s.MaLoai == maLoai).ToListAsync();
            return await sanPham;
        }
    }
}
