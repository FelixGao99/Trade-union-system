using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.BLL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection") { }

        public DbSet<Position> Positions { get; set; }

        public DbSet<WorkingUnit> WorkingUnits { get; set; }

        public DbSet<WorkingGroup> WorkingGroups { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Honor> Honors { get; set; }

        public DbSet<ModelWorker> ModelWorkers { get; set; }

        public DbSet<WorkingTeam> WorkingTeams { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<WorkersCongress> WorkersCongresses { get; set; }
    }
}
