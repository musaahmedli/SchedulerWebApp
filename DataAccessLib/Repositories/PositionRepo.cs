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
    public class PositionRepo : IPositionRepo
    {
        private readonly Context _context;
        public PositionRepo(Context context)
        {
            _context = context;
        }
        public async Task Add(Position position)
        {
            await _context.Positions.AddAsync(position);
            _context.SaveChanges();
        }

        public async Task Delete(int positionId)
        {
            Position position = await _context.Positions.FindAsync(positionId);
            position.IsDeleted = true;
            _context.Positions.Update(position);
            _context.SaveChanges();
        }

        public async Task<List<Position>> Get()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetById(int positionId)
        {
            return await _context.Positions.FindAsync(positionId);
        }

        public async Task<List<Position>> GetDeleteds()
        {
            return await _context.Positions.IgnoreQueryFilters().Where(m=>m.IsDeleted).ToListAsync();
            
        }

        public void Update(Position position)
        {
            _context.Positions.Update(position);
            _context.SaveChanges();
        }
    }
}
