using Microsoft.EntityFrameworkCore;

namespace NorthWindWeb_Demo.DAL
{
    public class DataBaseContext : DbContext
    {
        protected DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }


    }
}
