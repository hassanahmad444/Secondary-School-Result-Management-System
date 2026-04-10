using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Secondary_School_Result_Management_System.Data;
using Secondary_School_Result_Management_System.Roles;
using Secondary_School_Result_Management_System.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SchoolResultDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SchoolResultDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IAdminService, AdminService>();








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
app.UseAuthentication();    
app.UseAuthorization();
app.MapRazorPages();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Fix any lowercase roles that were created previously
    var oldAdminRole = await roleManager.FindByNameAsync("admin");
    if (oldAdminRole != null)
    {
        oldAdminRole.Name = "Admin";
        oldAdminRole.NormalizedName = "ADMIN";
        await roleManager.UpdateAsync(oldAdminRole);
    }

    // Reassign admin user to correct role
    var existingAdmin = await userManager.FindByEmailAsync("admin@school.com");
    if (existingAdmin != null)
    {
        var currentRoles = await userManager.GetRolesAsync(existingAdmin);
        await userManager.RemoveFromRolesAsync(existingAdmin, currentRoles);
        await userManager.AddToRoleAsync(existingAdmin, "Admin");
    }

    if (!await roleManager.RoleExistsAsync(Roles.Admin))
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin));

    if (!await roleManager.RoleExistsAsync(Roles.Student))
        await roleManager.CreateAsync(new IdentityRole(Roles.Student));

    if (!await roleManager.RoleExistsAsync(Roles.Teacher))
        await roleManager.CreateAsync(new IdentityRole(Roles.Teacher));


    string adminEmail = "admin@school.com";
    string adminPassword = "Admin@123";

    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);  

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, Roles.Admin);
        }
    }
}


app.Run();
