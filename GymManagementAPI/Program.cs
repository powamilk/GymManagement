using FluentValidation;
using GymManagementAPI.Entities;
using GymManagementAPI.MapperProfile;
using GymManagementAPI.Service.Implement;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.ClassRegistrationVM;
using GymManagementAPI.ViewModel.ClassVM;
using GymManagementAPI.ViewModel.MemberVM;
using GymManagementAPI.ViewModel.TrainerVM;
using GymManagementAPI.ViewModel.Validator.ClassRegistrationValidator;
using GymManagementAPI.ViewModel.Validator.ClassValidator;
using GymManagementAPI.ViewModel.Validator.MemberValidator;
using GymManagementAPI.ViewModel.Validator.TrainerValidator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database context configuration (replace connection string as needed)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GymManagementDB")));

// Add controllers
builder.Services.AddControllers();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<IValidator<CreateMemberVM>, CreateMemberVMValidator>();
builder.Services.AddTransient<IValidator<UpdateMemberVM>, UpdateMemberVMValidator>();
builder.Services.AddTransient<IValidator<CreateTrainerVM>, CreateTrainerVMValidator>();
builder.Services.AddTransient<IValidator<UpdateTrainerVM>, UpdateTrainerVMValidator>();
builder.Services.AddTransient<IValidator<CreateClassVM>, CreateClassVMValidator>();
builder.Services.AddTransient<IValidator<UpdateClassVM>, UpdateClassVMValidator>();
builder.Services.AddTransient<IValidator<CreateClassRegistrationVM>, CreateClassRegistrationVMValidator>();
builder.Services.AddTransient<IValidator<UpdateClassRegistrationVM>, UpdateClassRegistrationVMValidator>();

// Register Services
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassRegistrationService, ClassRegistrationService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
