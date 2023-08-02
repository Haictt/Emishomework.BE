using DPHai.Fresher032023.EmisHomework.API.Middlewares;
using DPHai.Fresher032023.EmisHomework.DL.Repository;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.BL.App.AppServices;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ITopicRepository,TopicRepository>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://127.0.0.1:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithExposedHeaders("Content-Disposition"));
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
