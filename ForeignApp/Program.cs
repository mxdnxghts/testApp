var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("CleanerFull", client =>
{
    client.BaseAddress = new Uri($"{builder.Configuration.GetRequiredSection("WebCleanerUri").Value}clean-");
});

builder.Services.AddHttpClient("CleanerDto", client =>
{
    client.BaseAddress = new Uri($"{builder.Configuration.GetRequiredSection("WebCleanerUri").Value}cleanDto-");
});

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

