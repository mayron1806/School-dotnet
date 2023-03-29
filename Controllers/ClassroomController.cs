using API.Dtos;
using API.Models;
using API.Repository;
using API.Repository.Interfaces;
using API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepository _repository;
        public ClassroomController(IClassroomRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetMany([FromQuery] int limit = 10, [FromQuery] int page = 0) 
        {
            var classroom = await _repository.FindManyAsync(limit, page);
            return Ok(classroom);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroomByID(int id) 
        {
            var classroom = await _repository.FindByIdAsync(id);
            if (classroom == null) return NotFound("Classroom not found");
            return Ok(classroom);
        }
        [HttpPost]
        public async Task<ActionResult<Classroom>> CreateClassroom(CreateClassroomDto createClassroomDto) 
        {

            // valida tipo da classroom 
            bool valid = ClassroomType.IsValid(createClassroomDto.Type);
            if (!valid) return BadRequest("Invalid classroom type");

            // criar nome e verifica duplicidade
            var name = ClassroomUtils.GetClassroomName(createClassroomDto.Type);
            var classroomWithName = await _repository.FindByNameAsync(name);
            if(classroomWithName != null) return BadRequest("Classroom already exists");
            // salva turma
            var classroom = new Classroom();
            classroom.Name = ClassroomUtils.GetClassroomName(createClassroomDto.Type);
            classroom.Description = createClassroomDto.Description;
            classroom.Type = createClassroomDto.Type;
            await _repository.CreateAsync(classroom);

            return Created($"/get-student-by-id?id={classroom.ID}", classroom);
        }
    }
}