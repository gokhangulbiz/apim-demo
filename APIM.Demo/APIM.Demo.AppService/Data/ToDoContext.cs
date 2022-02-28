#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIM.Demo.AppService.Models;

namespace APIM.Demo.AppService.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext (DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<APIM.Demo.AppService.Models.ToDoItem> ToDoItem { get; set; }
    }
}
