using ScholarsHub.Commands;
using ScholarsHub.Data;

namespace ScholarsHub.Handlers
{
    public class DeleteStudentHandler
    {
        private readonly ApplicationDbContext _context;

        public DeleteStudentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteStudentCommand command)
        {
            var student = await _context.Students.FindAsync(command.Id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
