using BasicApi.DAL;
using BasicApi.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AnimalStorage>();

var app = builder.Build();

app.UseStaticFiles();

app.MapPost("/animals", ([FromServices] AnimalStorage storage, Animal animal) =>
{
    if (string.IsNullOrEmpty(animal.Name))
    {
        return Results.BadRequest("Name property must exist and not be empty!");
    }

    if (!storage.Create(animal))
    {
        return Results.StatusCode(418);
    }

    return Results.Ok(storage.GetAll());
});

app.MapGet("/", () => Results.Redirect("/index.html"));

app.MapGet("/animals", ([FromServices] AnimalStorage storage) => Results.Ok(storage.GetAll()));

app.MapGet("/animals/{id}", ([FromServices] AnimalStorage storage, int id) =>
{
    var animal = storage.GetById(id);
    return animal is null ? Results.StatusCode(418) : Results.Ok(animal);
});

app.MapPut("/animals/{id}", ([FromServices] AnimalStorage storage, int id, Animal animal) =>
{
    var existingAnimal = storage.GetById(id);
    if (existingAnimal is null)
    {
        return Results.NotFound();
    }

    storage.Update(existingAnimal, animal);
    return Results.Ok(storage.GetById(id));
});

app.MapPut("/animals/changeName/{id}", ([FromServices] AnimalStorage storage, int id, string name) =>
{
    var existingAnimal = storage.GetById(id);
    if (existingAnimal is null)
    {
        return Results.NotFound();
    }

    storage.UpdateName(existingAnimal, name);
    return Results.Ok(storage.GetById(id));
});

app.MapPut("/animals/changeType/{id}", ([FromServices] AnimalStorage storage, int id, string type) =>
{
    var existingAnimal = storage.GetById(id);
    if (existingAnimal is null)
    {
        return Results.NotFound();
    }

    storage.UpdateType(existingAnimal, type);
    return Results.Ok(storage.GetById(id));
});

app.MapDelete("/animals/{id}", ([FromServices] AnimalStorage storage, int id) =>
{
    if (!storage.DeleteById(id))
    {
        return Results.NotFound();
    }

    return Results.Ok($"Animal at id: {id} was removed!");
});

app.MapDelete("/animals/withName/{name}", ([FromServices] AnimalStorage storage, string name) =>
{
    if (!storage.DeleteWithName(name))
    {
        return Results.NotFound(name);
    }
    return Results.Ok($"First {name} was removed!");
});

app.Run();
