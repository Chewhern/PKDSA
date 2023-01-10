/*using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography.X509Certificates;*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*builder.Services.
    AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("<Path to Data Protection Folder>")).ProtectKeysWithCertificate(
            new X509Certificate2("<Path to PFX certificate + Key>", "<Password>"));*/

builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
//5001 is port number,
//if you do any programming you should be familiar with java related
//server variant which uses port to host the server's application.
    serverOptions.Listen(System.Net.IPAddress.Parse("0.0.0.0"), 5001, listenOptions =>
    {
        listenOptions.UseHttps("<Path to PFX certificate + Key>", "<Password>");
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