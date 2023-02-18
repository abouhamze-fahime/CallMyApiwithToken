using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ClientDbContext
{
   public class ClientDbContext :DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> tblUsers { get; set; }
        public DbSet<UserViewModel> UserSecurity { get; set; }
    }
}
