using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Entities
{
    public class XeThue
    {
        public Guid ID { get; set; }
        public string TenXe { get; set; }
        public string HangXe { get; set; }
        public DateTime NgayThue { get; set; }
        public DateTime NgayTra { get; set; }
        public string TrangThai { get; set; } 
        public decimal GiaThueMoiNgay { get; set; }
    }
}
