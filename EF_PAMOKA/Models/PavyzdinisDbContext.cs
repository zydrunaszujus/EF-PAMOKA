using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_PAMOKA.Models
{
    public class PavyzdinisDbContext : DbContext//forma kokia norim,kad suformuotu duombaze
    {
        public PavyzdinisDbContext(DbContextOptions<PavyzdinisDbContext> options) : base(options) { }
       
        public DbSet<Savininkas> Savininkai { get; set; }
        public DbSet<Daiktas> Daiktai { get; set; }
        public DbSet<Automobilis> Automobiliai { get; set; }
        public DbSet<Mopedas> Mopedai { get; set; }

        //  private DbSet<Daiktas> daiktai;

        //    public DbSet<Daiktas> GetDaiktai()
        //    {
        //        return daiktai;
        //    }

        //    public void SetDaiktai(DbSet<Daiktas> value)
        //    {
        //        daiktai = value;
        //    }

        //    public IEnumerable<object> Daiktai { get; internal set; }
    }
}
