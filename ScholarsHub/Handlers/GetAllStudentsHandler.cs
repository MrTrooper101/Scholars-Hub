using Microsoft.EntityFrameworkCore;
using ScholarsHub.Data;
using ScholarsHub.Models;
using ScholarsHub.Queries;

namespace ScholarsHub.Handlers
{
    public class GetAllStudentsHandler
    {
        private readonly ApplicationDbContext _context;

        public GetAllStudentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query)
        {
            return await _context.Students.ToListAsync();
        }
    }
}
