using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WinFormsApp21;

namespace _23_08_2022
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base(@"Data Source=BEVLPC;Initial Catalog=Goods;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        { }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Typ> Typs { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
