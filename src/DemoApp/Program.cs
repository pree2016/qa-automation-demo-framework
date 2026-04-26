using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var users = new List<AppUser>
{
    new("qa.user@example.com", "Password123!", "QA Demo User")
};

var bugs = new List<BugItem>
{
    new(1, "Login button overlap on iPhone viewport", "Open"),
    new(2, "Cart count not refreshed after API call", "In Progress")
};

app.MapGet("/", () => Results.Redirect("/index.html"));

app.MapPost("/api/login", (LoginRequest request) =>
{
    var user = users.FirstOrDefault(u =>
        string.Equals(u.Email, request.Email, StringComparison.OrdinalIgnoreCase)
        && u.Password == request.Password);

    if (user is null)
    {
        return Results.BadRequest(new ApiResponse(false, "Invalid email or password."));
    }

    return Results.Ok(new LoginResponse(
        true,
        $"Welcome, {user.DisplayName}!",
        new UserProfile(user.Email, user.DisplayName)));
});

app.MapGet("/api/health", () => Results.Ok(new ApiResponse(true, "Demo API is healthy.")));
app.MapGet("/api/bugs", () => Results.Ok(bugs));

app.Run();

public partial class Program;

public record LoginRequest(string Email, string Password);
public record ApiResponse(bool Success, string Message);
public record UserProfile(string Email, string DisplayName);
public record LoginResponse(bool Success, string Message, UserProfile? User);
public record AppUser(string Email, string Password, string DisplayName);
public record BugItem(int Id, string Title, string Status);
