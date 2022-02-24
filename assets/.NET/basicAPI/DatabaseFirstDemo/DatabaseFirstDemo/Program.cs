using DatabaseFirstDemo.DAL;
using DatabaseFirstDemo.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HeroSchoolStorage>();

var app = builder.Build();

app.MapGet("/", () => Results.Ok("Welcome to the school for heroes!"));


//Get
app.MapGet("/students", ([FromServices] HeroSchoolStorage storage) =>
{
    var allStudents = storage.GetAllStudents();
    return Results.Ok(allStudents);
});

app.MapGet("/courses", ([FromServices] HeroSchoolStorage storage) =>
{
    var allCourses = storage.GetAllCourses();
    return Results.Ok(allCourses);
});

app.MapGet("/students/{id}", ([FromServices] HeroSchoolStorage storage, int id) =>
{
    var student = storage.GetStudentById(id);
    if (student is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(student);
});

app.MapGet("/courses/{id}", ([FromServices] HeroSchoolStorage storage, int id) =>
{
    var course = storage.GetCourseById(id);
    if (course is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(course);
});

//Post
app.MapPost("/students", ([FromServices] HeroSchoolStorage storage, Student student) =>
{
    var result = storage.CreateStudent(student);
    return Results.Ok(result);
});

app.MapPost("/courses", ([FromServices] HeroSchoolStorage storage, Course course) =>
{
    var result = storage.CreateCourse(course);
    return Results.Ok(result);
});

app.MapPost("/studentPlans", ([FromServices] HeroSchoolStorage storage, object studentPlan) =>
{
    //storage.Create(studentPlan, "studentPlans");
    //return Results.Ok();
});

//Put
app.MapPut("/students/{id}", ([FromServices] HeroSchoolStorage storage, int id, object student) => "Students");

app.MapPut("/courses/{id}", ([FromServices] HeroSchoolStorage storage, int id, object course) => "Courses");
//TODO: Fix path
app.MapPut("/studentPlans", () => "StudentPlans");

//Delete
app.MapDelete("/students/{id}", ([FromServices] HeroSchoolStorage storage, int id) =>
{
    storage.Delete(id, "students");
    return Results.Ok();
});

app.MapDelete("/courses/{id}", ([FromServices] HeroSchoolStorage storage, int id) =>
{
    storage.Delete(id, "courses");
    return Results.Ok();
});
//TODO: Fix path
app.MapDelete("/studentPlans", () => "StudentPlans");

app.Run();
