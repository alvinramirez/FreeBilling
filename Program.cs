var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async ctx =>
{
    await ctx.Response.WriteAsync("Welcome to FreeBillng");
});

//app.Run(async ctxx =>
//{
//    await ctxx.Response.WriteAsync("<html>" +
//                                        "<body>" +
//                                            "<h1>Welcome to FreeBilling</h1>" +
//                                        "</body>" +
//                                  "</html>");
//});

app.Run();
