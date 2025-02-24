using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using BlazorApp1.Components;
using BlazorExternalAuthGoogle;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthentication(Constants.Auth.AuthScheme)
    .AddCookie(Constants.Auth.AuthScheme, cookieOptions =>
    {
        cookieOptions.Cookie.Name = ".ap.user";
    })
    .AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        googleOptions.SignInScheme = Constants.Auth.AuthScheme;
        googleOptions.AccessDeniedPath = "/external-login-denied";
    });


    // builder.Services.AddHttpClient("ApiClient", client =>
    // {
    //     client.BaseAddress = new Uri("https://10.125.1.6:7087/api/My/");
    // })
    // .ConfigurePrimaryHttpMessageHandler(() =>
    // {
    //     var handler = new HttpClientHandler();
    //     handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
    //     {
    //         if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
    //             return true;
    //         return cert != null && cert.Thumbprint == "CERTIFICATE_THUMBPRINT";
    //     };

    //     return handler;
    // });
var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
};

builder.Services.AddHttpClient("MyApi", client =>
{
    client.BaseAddress = new Uri("https://10.125.1.6:7087/");
}).ConfigurePrimaryHttpMessageHandler(() => handler);

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<EncryptionHelper>();
builder.Services.AddSingleton<ModalService>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();



builder.Services.AddHttpClient();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// app.Urls.Add("http://0.0.0.0:5000");
// app.Urls.Add("http://0.0.0.0:7215");


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapGet("/login", async (HttpContext context) =>
{
    var properties = new AuthenticationProperties { RedirectUri = "/" };
    await context.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
});


app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(Constants.Auth.AuthScheme);
    context.Response.Redirect("/");
});

app.MapGet("/signin-google", async (HttpContext context) =>
{
    var result = await context.AuthenticateAsync(Constants.Auth.AuthScheme);
    if (result.Succeeded)
    {
        context.Response.Redirect("/");
    }
    else
    {
        context.Response.Redirect("/login");
    }
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
