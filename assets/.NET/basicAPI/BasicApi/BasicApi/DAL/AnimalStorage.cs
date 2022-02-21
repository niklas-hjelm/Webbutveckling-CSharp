using BasicApi.Models;

namespace BasicApi.DAL
{

    class AnimalStorage
    {

        private readonly AnimalContext _animalContext;

        public AnimalStorage()
        {
            _animalContext = new AnimalContext();
        }

        public bool Create(Animal? animal)
        {
            if (animal is null)
            {
                return false;
            }

            _animalContext.Animals.Add(animal);
            _animalContext.SaveChanges();
            
            return true;
        }

        public List<Animal> GetAll()
        {
            return _animalContext.Animals.Where(a => true).ToList();
        }

        public Animal? GetById(int id)
        {
            return _animalContext.Animals.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Animal existingAnimal, Animal animal)
        {
            existingAnimal.Name = animal.Name;
            existingAnimal.Type = animal.Type;
            
            _animalContext.SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var existingAnimal = GetById(id);

            if (existingAnimal is null)
            {
                return false;
            }

            _animalContext.Remove(existingAnimal);
            _animalContext.SaveChanges();
            return true;
        }

        public bool DeleteAllWithName(string name)
        {
            var existingAnimal = _animalContext.Animals.FirstOrDefault(a => a.Name == name);

            if (existingAnimal is null)
            {
                return false;
            }

            _animalContext.Remove(existingAnimal);
            _animalContext.SaveChanges();
            return true;
        }

        public void UpdateName(Animal existingAnimal, string name)
        {
            existingAnimal.Name = name;
            _animalContext.SaveChanges();
        }

        public void UpdateType(Animal existingAnimal, string type)
        {
            existingAnimal.Type = type;
            _animalContext.SaveChanges();
        }
    }
}
