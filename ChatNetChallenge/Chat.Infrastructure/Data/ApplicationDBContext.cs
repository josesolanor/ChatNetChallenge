using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data
{
    class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
    }
}
