
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IPositionRepo
    {
        Task Add(Position position);
        Task<List<Position>> Get();
        Task<Position> GetById(int positionId);
        Task Delete(int positionId);
        void Update(Position position);
        Task<List<Position>> GetDeleteds();
    }
}
