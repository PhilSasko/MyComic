using MyComic.Domain.DataAccess;
using MyComic.Domain.PageNavigation;
using MyComic.Domain.PageProviding;
using MyComic.Domain.PageProviding.DataRetrieval;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DefaultComicPageRetriever, DefaultComicPageRetriever>();
builder.Services.AddTransient<IComicIssueResolver, ComicIssueResolver>();
builder.Services.AddTransient<IComicIssuePageRetriever, ComicIssuePageRetriever>();
builder.Services.AddTransient<IComicPageFromIdRetriever, ComicPageFromIdRetriever>();
builder.Services.AddTransient<INextComicPageIdRetriever, NextComicPageIdRetriever>();
builder.Services.AddTransient<IPreviousComicPageIdRetriever, PreviousComicPageIdRetriever>();
builder.Services.AddTransient<ILastComicPageIdRetriever, LastComicPageIdRetriever>();
builder.Services.AddTransient<IFirstComicPageIdRetriever, FirstComicPageIdRetriever>();
builder.Services.AddTransient<IComicIssueByIdRetriever, ComicIssueByIdRetriever>();
builder.Services.AddTransient<IComicIssuePageRetriever, ComicIssuePageRetriever>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
