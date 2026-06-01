using Proyecto_Polleria.Data;
using Proyecto_Polleria.Repository;
using Proyecto_Polleria.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<Conexion>(_ =>
    new Conexion(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<TrabajadorRepository>();
builder.Services.AddScoped<TrabajadorService>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProveedorRepository>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddScoped<IngredienteRepository>();
builder.Services.AddScoped<IngredienteService>();
builder.Services.AddScoped<InventarioRepository>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<Movimiento_CompraRepository>();
builder.Services.AddScoped<Movimiento_CompraService>();
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<MesaService>();
builder.Services.AddScoped<Registrar_IngresoRepository>();
builder.Services.AddScoped<Registrar_IngresoService>();
builder.Services.AddScoped<ProcesoRepository>();
builder.Services.AddScoped<ProcesoService>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.UseSession();

app.Run();
