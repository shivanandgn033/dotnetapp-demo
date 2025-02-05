
using amazonbooks.Models;
using Microsoft.EntityFrameworkCore;
namespace amazonbooks.Data;




public class ApplicationDbContext : DbContext
{
    public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){

    }

    public DbSet<BooksEntity> Books {get;set;}

}
