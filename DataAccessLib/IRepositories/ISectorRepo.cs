using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface ISectorRepo
    {
        Task Add(Sector sector);
        Task<List<Sector>> Get();
        Task<Sector> GetById(int sectorId);
        Task Delete(int sectorId);
        void Update(Sector sectorId);
        Task<List<Sector>> GetSectorsByDepartment(int deparmtentId);
    }
}
