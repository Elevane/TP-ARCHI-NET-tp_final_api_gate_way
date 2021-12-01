using tp_final_api_gate_way.ApiServices;
using tp_final_api_gate_way.Extensions;
using tp_final_api_gate_way.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<ApiManager>();
builder.Services.AddHttpClient();

// verification de la configuration
JsonExtension.VerifyConfig();
builder.Services.InjectJsonService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
