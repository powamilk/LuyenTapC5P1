namespace AppView.Models
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
