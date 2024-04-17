using cw4.Properties.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Properties.Controlers;

[Route("api/animals")]
[ApiController ]
public class AnimalControlers : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal{IdAnimal = 1, Name = "bob", Category = "cat", Weight = 10, FurColor = "black"},
        new Animal{IdAnimal = 2, Name = "john", Category = "dog", Weight = 8, FurColor = "white"},
        new Animal{IdAnimal = 3, Name = "zofia", Category = "hamster", Weight = 0.1, FurColor = "grey"}
    };
        
        
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(s => s.IdAnimal == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToEdit == null)
        {
            return NotFound($"Animal witk id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }
}