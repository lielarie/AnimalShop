using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Threading.Tasks;
using AnimalShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using AnimalShopProject.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;

namespace AnimalShopProject.Controllers

{
    public class AnimalShopController : Controller
    {
        private IWebHostEnvironment _environment;
        private AnimalContext _context;
        public List<Animal> _requestedAnimals { get; set; }

        public AnimalShopController(AnimalContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult AnimalPage(int animalId)
        {
            Animal animal = _context.GetAnimals().First(a => a.AnimalId == animalId);
            ViewBag.Comments = _context.Comments.Where(a => a.AnimalId == animalId).ToList();
            return View(animal);
        }

        public IActionResult CatalogPage(int cat)
        {
            var list = new List<Animal>();
            if (cat == 0)
            {
                list = _context.GetAnimals();
            }
            else
            {
                list = _context.GetAnimals().Where(a => a.CategoryId == cat).ToList();
            }

            ViewBag.CategoryList = _context.Categories.ToList();
            return View(list);
        }

        public IActionResult MainPage()
        {
            var list = _context.GetAnimals().OrderByDescending(a => a.Comments.Count()).Take(2);
            return View(list);
        }

        public IActionResult AdminPage(int cat)
        {
            var list = new List<Animal>();
            if (cat == 0)
            {
                list = _context.GetAnimals();
            }
            else
            {
                list = _context.GetAnimals().Where(a => a.CategoryId == cat).ToList();
            }

            ViewBag.CategoryList = _context.Categories.ToList();

            return View(list);
        }

        public IActionResult AddPage()
        {
            ViewBag.CategoryList = _context.Categories.ToList();
            return View();
        }

        public IActionResult EditAnimalPage(int animalId)
        {
            Animal animal = _context.GetAnimals().First(a => a.AnimalId == animalId);
            ViewBag.CategoryList = _context.Categories.ToList();
            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> EditAnimal(string name, int age, string description, IFormFile iFile, Image image, string category, int animalId)
        {
            try
            {
                Animal animal = _context.GetAnimals().First(a => a.AnimalId == animalId);
                if (name != null && age != 0 && description != null && iFile != null && category != null && image != null)
                {
                    string imageText = Path.GetExtension(iFile.FileName);
                    if (imageText != ".jpg" && imageText != ".gif" && imageText != ".png")
                    {
                        TempData["Message"] = "Please upload only .jpg / .gif / .png items";
                        return RedirectToAction("EditAnimalPage", new { animalId = animalId });
                    }
                    var saveImage = Path.Combine(_environment.WebRootPath, "Images", iFile.FileName);
                    var stream = new FileStream(saveImage, FileMode.Create);
                    await iFile.CopyToAsync(stream);
                    Animal newAnimal = _context.Animals.FirstOrDefault(a => a.Name == name);
                    if (newAnimal != null && newAnimal.Name != animal.Name) throw new ArgumentException();
                    image.ImageName = iFile.FileName;
                    image.ImagePath = saveImage;
                    await _context.Images.AddAsync(image);
                    await _context.SaveChangesAsync();

                    Category cat = new Category();

                    try
                    {
                        cat = _context.Categories.First(x => x.CategoryName == category);
                        cat.CategoryName = category;
                    }
                    catch
                    {
                        cat.CategoryName = category;
                        _context.Categories.Add(cat);
                    }
                    finally
                    {
                        animal.Name = name;
                        animal.Age = age;
                        animal.Category = cat;
                        animal.Description = description;
                        animal.Picture = new Image
                        {
                            ImagePath = "images/" + iFile.FileName,
                            ImageName = name
                        };
                        _context.SaveChanges();
                    }
                }

                else
                {
                    TempData["Message"] = "Please try again and fill all the information";
                    return RedirectToAction("EditAnimalPage", "AnimalShop", new { animalId = animalId });
                }
            }
            catch
            {
                TempData["Message"] = "This animal already exists";
                return RedirectToAction("EditAnimalPage", "AnimalShop", new { animalId = animalId });
            }
            return RedirectToAction("AdminPage");
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(string name, int age, string description, IFormFile iFile, Image image, string category)
        {
            if (name != null && age != 0 && description != null && iFile != null && category != null && image != null)
            {
                try
                {
                    Animal animal = _context.Animals.FirstOrDefault(a => a.Name == name);
                    if (animal != null) throw new ArgumentException();
                    string imageText = Path.GetExtension(iFile.FileName);
                    if (imageText != ".jpg" && imageText != ".gif" && imageText != ".png")
                    {
                        TempData["Message"] = "Please upload only .jpg / .gif / .png items";
                        return RedirectToAction("AddPage");
                    }
                    var saveImage = Path.Combine(_environment.WebRootPath, "Images", iFile.FileName);
                    var stream = new FileStream(saveImage, FileMode.Create);
                    await iFile.CopyToAsync(stream);
                    image.ImageName = iFile.FileName;
                    image.ImagePath = saveImage;
                    
                    Category cat = new Category();
                    Animal animal1 = new Animal();
                    try
                    {
                        cat = _context.Categories.First(x => x.CategoryName == category);
                        animal1 = new Animal { Name = name, Age = age, Category = cat, Description = description, Picture = new Image { ImagePath = "images/" + iFile.FileName, ImageName = name } };
                        cat.CategoryName = category;
                    }
                    catch
                    {
                        cat.CategoryName = category;
                        _context.Categories.Add(cat);
                    }
                    finally
                    {
                        animal1 = new Animal { Name = name, Age = age, Category = cat, Description = description, Picture = new Image { ImagePath = "images/" + iFile.FileName, ImageName = name } };
                        _context.Animals.Add(animal1);
                        await _context.Images.AddAsync(image);
                        await _context.SaveChangesAsync();
                        _context.SaveChanges();
                    }
                }
                catch
                {
                    TempData["Message"] = "This animal already exists";
                    return RedirectToAction("AddPage");
                }
                return RedirectToAction("CatalogPage");
            }

            else
            {
                TempData["Message"] = "Please try again and fill all the information";
                return RedirectToAction("AddPage");
            }
        }

        [HttpPost]
        public IActionResult ReceivePost(string comment, int animalId)
        {
            if (comment != null)
            {
                _context.Comments.Add(new Comment { CommentInfo = comment, AnimalId = animalId });
                _context.SaveChanges();
            }
            return RedirectToAction("AnimalPage", new { animalId = animalId });
        }

        public IActionResult DeleteAnimal(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return RedirectToAction("AdminPage");
        }
    }
}
