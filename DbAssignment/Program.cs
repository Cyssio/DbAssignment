using DbAssignment.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VS-Projects\DbAssignment\DbAssignment\Data\DbForAssignment.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

}).Build();