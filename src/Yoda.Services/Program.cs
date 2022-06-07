using Yoda.Services.Services.Authentication;
using Yoda.Services.Services.User;


var builder = WebApplication.CreateBuilder(args);
var allowedHosts = builder.Configuration["AllowedHosts"];
var allowedLocalhostOrigins = "AllowedLocalhostOrigins";
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowedLocalhostOrigins,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.WithOrigins(allowedHosts);
        }
    );
});
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(allowedLocalhostOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
