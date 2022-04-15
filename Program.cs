using Mvc_CmsWebapi.RepositoryLayer;
using Mvc_CmsWebapi.RepositoryLayer.Contact;
using Mvc_CmsWebapi.RepositoryLayer.Deals;
using Mvc_CmsWebapi.RepositoryLayer.Inquiry;
using Mvc_CmsWebapi.RepositoryLayer.Pages;
using Mvc_CmsWebapi.RepositoryLayer.Portal;
using Mvc_CmsWebapi.ServiceLayer;
using Mvc_CmsWebapi.ServiceLayer.Contact;
using Mvc_CmsWebapi.ServiceLayer.Deals;
using Mvc_CmsWebapi.ServiceLayer.Inquiry;
using Mvc_CmsWebapi.ServiceLayer.Pages;
using Mvc_CmsWebapi.ServiceLayer.Portal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IAdminSL, AdminSL>();
builder.Services.AddScoped<IAdminRL, AdminRL>();

builder.Services.AddScoped<ICustomerSendInquirySL, CustomerSendInquirySL>();
builder.Services.AddScoped<ICustomerSendInquiryRL, CustomerSendInquiryRL>();
builder.Services.AddScoped<IAdminViewInquirySL, AdminViewInquirySL>();
builder.Services.AddScoped<IAdminViewInquiryRL, AdminViewInquiryRL>();

builder.Services.AddScoped<IDealsAddRL, DealsAddRL>();
builder.Services.AddScoped<IDealsAddSL, DealsAddSL>();

builder.Services.AddScoped<IPagesRL, PagesRL>();
builder.Services.AddScoped<IPagesSL, PagesSL>();

builder.Services.AddScoped<IPortalRL, PortalRL>();
builder.Services.AddScoped<IPortalSL, PortalSL>();

builder.Services.AddScoped<IContactRL, ContactRL>();
builder.Services.AddScoped<IContactSL, ContactSL>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3001", "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
