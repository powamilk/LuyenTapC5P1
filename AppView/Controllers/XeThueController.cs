using AppData.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class XeThueController : Controller
    {
        private readonly HttpClient _httpClient;

        public XeThueController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7025/api/XeThue");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var xeThueEntities = JsonConvert.DeserializeObject<List<AppData.Entities.XeThue>>(content);

                var xeThueModels = xeThueEntities.ConvertAll(x => new XeThue
                {
                    ID = x.ID,
                    TenXe = x.TenXe,
                    HangXe = x.HangXe,
                    NgayThue = x.NgayThue,
                    NgayTra = x.NgayTra,
                    TrangThai = x.TrangThai,
                    GiaThueMoiNgay = x.GiaThueMoiNgay
                });

                return View(xeThueModels);
            }

            return View(new List<XeThue>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(XeThue xeThue)
        {
            var content = JsonConvert.SerializeObject(xeThue);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7025/api/XeThue", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(xeThue);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7025/api/XeThue/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var xeThueEntity = JsonConvert.DeserializeObject<AppData.Entities.XeThue>(content);

                var xeThueModel = new XeThue
                {
                    ID = xeThueEntity.ID,
                    TenXe = xeThueEntity.TenXe,
                    HangXe = xeThueEntity.HangXe,
                    NgayThue = xeThueEntity.NgayThue,
                    NgayTra = xeThueEntity.NgayTra,
                    TrangThai = xeThueEntity.TrangThai,
                    GiaThueMoiNgay = xeThueEntity.GiaThueMoiNgay
                };

                return View(xeThueModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, XeThue xeThue)
        {
            var content = JsonConvert.SerializeObject(xeThue);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7025/api/XeThue/{id}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(xeThue);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7025/api/XeThue/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
