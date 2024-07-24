using ScholarsHub.Commands;
using ScholarsHub.Data;
using ScholarsHub.Models;

namespace ScholarsHub.Handlers
{
    public class CreateStudentHandler
    {
        private readonly ApplicationDbContext _context;

        public CreateStudentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(CreateStudentCommand command)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Age = command.Age,
                Email = command.Email,
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
