using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        private readonly SchoolContext _context;
        public ClassroomRepository(SchoolContext context) : base(context) {
            _context = context;
        }

        public async Task<Classroom> FindByNameAsync(string name)
        {
            var res = await _context.Classrooms.FirstOrDefaultAsync(e =>  e.Name == name);
            return res;
        }
    }
}