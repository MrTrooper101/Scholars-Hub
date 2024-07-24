using Microsoft.AspNetCore.Mvc;
using ScholarsHub.Commands;
using ScholarsHub.Handlers;
using ScholarsHub.Queries;
using ScholarsHub.Models;

namespace ScholarsHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentHandler _createStudentHandler;
        private readonly UpdateStudentHandler _updateStudentHandler;
        private readonly DeleteStudentHandler _deleteStudentHandler;
        private readonly GetAllStudentsHandler _getAllStudentsHandler;
        private readonly GetStudentByIdHandler _getStudentByIdHandler;

        public StudentController(
            CreateStudentHandler createStudentHandler,
            DeleteStudentHandler deleteStudentHandler,
            UpdateStudentHandler updateStudentHandler,
            GetAllStudentsHandler getAllStudentsHandler,
            GetStudentByIdHandler getStudentByIdHandler)
        {
            _createStudentHandler = createStudentHandler;
            _deleteStudentHandler = deleteStudentHandler;
            _updateStudentHandler = updateStudentHandler;
            _getAllStudentsHandler = getAllStudentsHandler;
            _getStudentByIdHandler = getStudentByIdHandler;
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<Student>> CreateStudent(CreateStudentCommand command)
        {
            try
            {
                var student = await _createStudentHandler.Handle(command);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(UpdateStudentCommand command)
        {
            try
            {
                var student = await _updateStudentHandler.Handle(command);
                return student != null ? Ok(student) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                await _deleteStudentHandler.Handle(new DeleteStudentCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(Guid id)
        {
            try
            {
                var student = await _getStudentByIdHandler.Handle(new GetStudentByIdQuery { Id = id });
                return Ok(student);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            try
            {
                var students = await _getAllStudentsHandler.Handle(new GetAllStudentsQuery());
                return students != null ? Ok(students) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
