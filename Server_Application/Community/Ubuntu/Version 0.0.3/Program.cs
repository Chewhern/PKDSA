using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.
    AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("<Path to data protection>")).ProtectKeysWithCertificate(
            new X509Certificate2("<Path to X509 certificate in pfx format>", "<Certificate Password>"));

builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(System.Net.IPAddress.Parse("0.0.0.0"), 5001, listenOptions =>
    {
        listenOptions.UseHttps("<Path to X509 certificate in pfx format>", "<Certificate Password>");
    }
    );
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
