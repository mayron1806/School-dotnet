using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class StudentsRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly SchoolContext _context;
        public StudentsRepository(SchoolContext context) : base(context) {
            _context = context;
        }
        public override async Task<Student> CreateAsync(Student student) {
            await _context.Students.AddAsync(student);
            _context.Classrooms.Attach(student.classroom);
            await _context.SaveChangesAsync();
            return student;
        }

    }
}