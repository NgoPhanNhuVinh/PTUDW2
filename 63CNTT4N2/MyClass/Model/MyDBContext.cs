using MyClass.Model.MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{//chua xong
    public class MyDBContext: DbContext
    {
        //tao ra ket noi
        public MyDBContext(): base("name= StrConnect") { }
        // ket noi cac bang
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<MyDBContext> MyDBContexts { get; set; }
        public DbSet<Orders> O{ get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}
