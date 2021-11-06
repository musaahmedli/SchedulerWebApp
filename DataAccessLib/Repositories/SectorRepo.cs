using DataAccessLib.IRepositories;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Repositories
{
    public class SectorRepo : ISectorRepo
    {
        private readonly Context _context;
        public SectorRepo(Context context)
        {
            _context = context;
        }
        public async Task Add(Sector sector)
        {
            await _context.Sectors.AddAsync(sector);
            _context.SaveChanges();
        }

        public async Task Delete(int sectorId)
        {
            Sector sector = await _context.Sectors.FindAsync(sectorId);
            sector.IsDeleted = true;
            _context.Sectors.Update(sector);
            _context.SaveChanges();
        }

        public async Task<List<Sector>> Get()
        {
            return await _context.Sectors.ToListAsync();
        }

        public async Task<Sector> GetById(int sectorId)
        {
            return await _context.Sectors.Where(m=>m.SectorId==sectorId).FirstOrDefaultAsync();
        }

        public async Task<List<Sector>> GetSectorsByDepartment(int deparmtentId)
        {
            return await _context.Sectors.Where(m => m.DepartmentId == deparmtentId).ToListAsync();
        }

        public void Update(Sector sector)
        {
            _context.Sectors.Update(sector);
            _context.SaveChanges();
        }
    }
}
