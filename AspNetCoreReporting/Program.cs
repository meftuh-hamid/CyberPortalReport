using AspNetCoreReporting.Data;
using AspNetCoreReporting.Services;
using DevExpress.AspNetCore;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using ServerSideApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddDevExpressControls();
builder.Services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();
// ...
builder.Services.AddDbContext<ReportDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => {
    options.AddPolicy("AllowCorsPolicy", builder => {
        // Allow all ports on local host.
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseDevExpressControls();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();
