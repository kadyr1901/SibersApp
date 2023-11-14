using Microsoft.EntityFrameworkCore;
using Sibers.Data;
using Sibers.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();
await app.ConfigureApplicationAsync();
