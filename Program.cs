using DisasterApiService;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.PostgreSql;
using DisasterApiService.Common;
using DisasterApiService.Batch;

var builder = WebApplication.CreateBuilder(args);
//DB Settings
builder.Services.AddDbContextFactory<DisasterDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("db")));

//Hang Fireの設定
builder.Services.AddHangfire(config =>
    config.UsePostgreSqlStorage(c =>
        c.UseNpgsqlConnection(builder.Configuration.GetConnectionString("db"))));

builder.Services.AddHangfireServer();

DiscordSendMessages.DiscordSettingsAsync();
int i = 0;
while(!DiscordSendMessages.IsStarted){
    await Task.Delay(100);
    i ++ ;
    if(i >= 100){
        //10秒経っても接続できなかったら強制終了する
       throw new Exception();
    }
}


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapHangfireDashboard();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await DiscordSendMessages.SendMessageAsync(CommonParameter.TextId,"TestSending for ASP.NET By yokugyoku");
}else{
    await DiscordSendMessages.SendMessageAsync(CommonParameter.TextId,"Run Server");
}

app.UseMiddleware<CustomExceptionCatch>();
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
RecurringJob.RemoveIfExists("daily-job");

// 一日に一回実行する処理
RecurringJob.AddOrUpdate<OneDateOnceExecution>("daily-job", job => job.ExecuteMethods(), Cron.Daily);
//BackgroundJob.Enqueue<OneDateOnceExecution>(job => job.ExecuteMethods());

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
