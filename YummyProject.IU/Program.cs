var builder = WebApplication.CreateBuilder(args);

// Razor Pages projesi i�in a�a��daki sat�r� ekleyin:
builder.Services.AddRazorPages();

// E�er API veya MVC Controller kullan�yorsan�z, bu sat�r kalabilir:
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Statik dosyalar i�in do�ru yerde
app.UseRouting();
app.UseAuthorization();

// Razor Pages i�in a�a��daki sat�r� ekleyin:
app.MapRazorPages();

// E�er Controller kullan�yorsan�z, bu sat�r kalabilir:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
