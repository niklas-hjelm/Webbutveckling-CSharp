using BasicApi.Models;
using MongoDB.Driver;

namespace BasicApi.DAL
{

    class AnimalStorage
    {

        private readonly AnimalContext _animalContext;

        private readonly IMongoDatabase _database;

        public AnimalStorage()
        {
            _animalContext = new AnimalContext();

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://niklas:apa123@cluster0.j0lyf.mongodb.net/AnimalDb?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            _database = client.GetDatabase("AnimalDb");
        }

        public bool Create(Animal? animal)
        {
            if (animal is null)
            {
                return false;
            }

            //_animalContext.Animals.Add(animal);
            //_animalContext.SaveChanges();

            var collection = _database.GetCollection<Animal>("animal");

            collection.InsertOne(animal);
            
            return true;
        }

        public List<Animal> GetAll()
        {
            //return _animalContext.Animals.Where(a => true).ToList();

            var collection = _database.GetCollection<Animal>("animal");

            var allAnimals = collection.Find(_ => true).ToList();

            return allAnimals;
        }

        public Animal? GetById(int id)
        {
            //return _animalContext.Animals.FirstOrDefault(a => a.Id == id);

            var collection = _database.GetCollection<Animal>("animal");

            var animal = collection.Find(animal => animal.Id == id).FirstOrDefault();

            return animal;
        }

        public void Update(Animal existingAnimal, Animal animal)
        {
            //existingAnimal.Name = animal.Name;
            //existingAnimal.Type = animal.Type;

            //_animalContext.SaveChanges();

            var collection = _database.GetCollection<Animal>("animal");
            var filterDefinition = Builders<Animal>.Filter.Eq(a => a.Id, existingAnimal.Id);
            var updateDefinition = Builders<Animal>.Update
                .Set(a => a.Name, animal.Name)
                .Set(a => a.Type, animal.Type);

            collection.UpdateOne(filterDefinition, updateDefinition);
        }

        public bool DeleteById(int id)
        {
            //var existingAnimal = GetById(id);

            //if (existingAnimal is null)
            //{
            //    return false;
            //}

            //_animalContext.Remove(existingAnimal);
            //_animalContext.SaveChanges();
            //return true;
            var collection = _database.GetCollection<Animal>("animal");

            if (GetById(id) is null)
            {
                return false;
            }

            collection.DeleteOne(a => a.Id == id);
            return true;
        }

        public bool DeleteWithName(string name)
        {
            //var existingAnimal = _animalContext.Animals.FirstOrDefault(a => a.Name == name);

            //if (existingAnimal is null)
            //{
            //    return false;
            //}

            //_animalContext.Remove(existingAnimal);
            //_animalContext.SaveChanges();
            //return true;

            var collection = _database.GetCollection<Animal>("animal");

            if (collection.Find(a=>a.Name == name).FirstOrDefault() is null)
            {
                return false;
            }

            collection.DeleteOne(a => a.Name == name);
            return true;
        }

        public void UpdateName(Animal existingAnimal, string name)
        {
            //existingAnimal.Name = name;
            //_animalContext.SaveChanges();

            var collection = _database.GetCollection<Animal>("animal");
            var filterDefinition = Builders<Animal>.Filter.Eq(a => a.Id, existingAnimal.Id);
            var updateDefinition = Builders<Animal>.Update
                .Set(a => a.Name, name);

            collection.UpdateOne(filterDefinition, updateDefinition);
        }

        public void UpdateType(Animal existingAnimal, string type)
        {
            //existingAnimal.Type = type;
            //_animalContext.SaveChanges();
            var collection = _database.GetCollection<Animal>("animal");
            var filterDefinition = Builders<Animal>.Filter.Eq(a => a.Id, existingAnimal.Id);
            var updateDefinition = Builders<Animal>.Update
                .Set(a => a.Type, type);

            collection.UpdateOne(filterDefinition, updateDefinition);
        }
    }
}
