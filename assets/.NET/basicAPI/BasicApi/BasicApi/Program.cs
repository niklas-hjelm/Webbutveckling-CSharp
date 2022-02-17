using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AnimalStorage>();

var app = builder.Build();

app.MapGet("/", ([FromServices] AnimalStorage storage) => "Jag heter Niklas");

app.MapGet("/animals", ([FromServices] AnimalStorage storage) => Results.Ok(storage.GetAll()));

app.MapGet("/animals/{id}", ([FromServices] AnimalStorage storage, Guid id) =>
{
    var animal = storage.GetById(id);
    return animal is null ? Results.StatusCode(418) : Results.Ok(animal);
});

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

app.MapPut("/animals/{id}", ([FromServices] AnimalStorage storage, Guid id, Animal animal) =>
{
    var existingAnimal = storage.GetById(id);
    if (existingAnimal is null)
    {
        return Results.NotFound();
    }

    storage.Update(animal);
    return Results.Ok(animal);
});

app.MapDelete("/animals/{id}", ([FromServices] AnimalStorage storage, Guid id) =>
{
    storage.DeleteById(id);
    return Results.Ok($"Animal at id: {id} was removed!");
});

app.MapDelete("/animals/allWithName/{name}", ([FromServices] AnimalStorage storage, string name) =>
{
    storage.DeleteAllWithName(name);
    return Results.Ok($"All {name}'s were removed!");
});

app.Run();

internal record Animal(Guid Id, string Name);

class AnimalStorage
{
    private readonly Dictionary<Guid, Animal> _animals = new();

    public bool Create(Animal animal)
    {
        if (animal is null)
        {
            return false;
        }

        _animals[animal.Id] = animal;
        return true;
    }

    public List<Animal> GetAll()
    {
        return _animals.Values.ToList();
    }

    public Animal GetById(Guid id)
    {
        return _animals[id];
    }

    public void Update(Animal animal)
    {
        if (animal is null)
        {
            return;
        }

        _animals[animal.Id] = animal;
    }

    public void DeleteById(Guid id)
    {
        _animals.Remove(id);
    }

    public void DeleteAllWithName(string name)
    {
        var animalWithName = _animals.Values.Where(a => a.Name == name).ToList();
        if (animalWithName.Count == 0)
        {
            return;
        }

        foreach (var animal in animalWithName)
        {
            _animals.Remove(animal.Id);
        }
    }
}