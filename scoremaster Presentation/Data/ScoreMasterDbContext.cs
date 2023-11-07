using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.Data
{
    public class ScoreMasterDbContext:DbContext
    {
        public ScoreMasterDbContext(DbContextOptions<ScoreMasterDbContext> options) : base(options)
        {

        }
        public  DbSet<Department> Departments { get; set; }
        public DbSet<UsersRegistration> UsersRegistrations { get; set; }
        public DbSet<Event> Event { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<MemberData> MemberDatas { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<ExternalUserscs> ExternalUserscs{ get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermision> UserPermisions { get; set; }

    }
}
