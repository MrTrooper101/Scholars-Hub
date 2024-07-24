using ScholarsHub.Commands;
using ScholarsHub.Data;
using ScholarsHub.Models;

namespace ScholarsHub.Handlers
{
    public class UpdateStudentHandler
    {
        private readonly ApplicationDbContext _context;

        public UpdateStudentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(UpdateStudentCommand command)
        {
            var student = await _context.Students.FindAsync(command.Id);
            if (student != null)
            {
                student.Name = command.Name;
                student.Email = command.Email;
                student.Age = command.Age;

                _context.Students.Update(student);
                await _context.SaveChangesAsync();
            }
            return student;
        }
    }
}
