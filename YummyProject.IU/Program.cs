var builder = WebApplication.CreateBuilder(args);

// Razor Pages projesi için aþaðýdaki satýrý ekleyin:
builder.Services.AddRazorPages();

// Eðer API veya MVC Controller kullanýyorsanýz, bu satýr kalabilir:
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Statik dosyalar için doðru yerde
app.UseRouting();
app.UseAuthorization();

// Razor Pages için aþaðýdaki satýrý ekleyin:
app.MapRazorPages();

// Eðer Controller kullanýyorsanýz, bu satýr kalabilir:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
