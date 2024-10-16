using AppData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositories
{
    public interface IXeThueRepository
    {
        Task<IEnumerable<XeThue>> GetAllXeThueAsync();
        Task<XeThue> GetXeThueByIdAsync(Guid id);
        Task AddXeThueAsync(XeThue xeThue);
        Task UpdateXeThueAsync(XeThue xeThue);
        Task DeleteXeThueAsync(XeThue xeThue);
        Task<decimal> TinhChiPhiThueXeAsync(Guid xeThueId, DateTime ngayThue, DateTime ngayTra);
    }
}
