using API.Dtos;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IClassroomRepository _classRepository;
        public StudentController(IStudentRepository repository, IClassroomRepository classRepository)
        {
            _repository = repository;
            _classRepository = classRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetMany([FromQuery] int limit = 10, [FromQuery] int page = 0) 
        {
            var students = await _repository.FindManyAsync(limit, page);
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id) 
        {
            var student = await _repository.FindByIdAsync(id);
            if (student == null) return NotFound("Student not found");
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(CreateStudentDto createStudentDto) 
        {
            // verifica se turma existe
            var classroom = await _classRepository.FindByIdAsync(createStudentDto.ClassroomID);
            if (classroom == null) return NotFound("Classroom not found");

            var student = new Student();
            student.Name = createStudentDto.Name;
            student.classroom = classroom;
            await _repository.CreateAsync(student);

            return Created($"/get-student-by-id?id={student.ID}", student);
        }
    }
}