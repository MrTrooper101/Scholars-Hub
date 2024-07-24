using ScholarsHub.Data;
using ScholarsHub.Models;
using ScholarsHub.Queries;

namespace ScholarsHub.Handlers
{
    public class GetStudentByIdHandler
    {
        private readonly ApplicationDbContext _context;

        public GetStudentByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentByIdQuery query)
        {
            return await _context.Students.FindAsync(query.Id);
        }
    }
}
