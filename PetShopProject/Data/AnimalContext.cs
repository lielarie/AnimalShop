using AnimalShopProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnimalShopProject.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        public List<Animal> GetAnimalsById(int id) => Animals.Where(a => a.AnimalId == id).ToList();
        public List<Animal> GetAnimals() => Animals.ToList();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region AddingCategories 

            modelBuilder.Entity<Category>().HasData(

            new Category
            {
                CategoryId = 1,
                CategoryName = "Aquatics"
            },

            new Category
            {
                CategoryId = 2,
                CategoryName = "Mammals"
            },

            new Category
            {
                CategoryId = 3,
                CategoryName = "Reptiles"
            }
            );
            #endregion

            #region AddingAnimals

            modelBuilder.Entity<Animal>().HasData(

            #region AddingAquatics

            new Animal
            {
                AnimalId = 1,
                Name = "Shark",
                Age = 5,
                CategoryId = 1,
                PictureId = 8,
                Description = "Sharks are a superorder of fish, the Selachimorph.\n" +
                "They, like other Chondrichthyes, have skeletons made of cartilage instead of bone.\n" +
                "Cartilage is tough, rubbery material which is less rigid than bone.\n" +
                "Cartilaginous fish also include skates and rays. There are more than 350 different kinds of sharks,\n" +
                "such as the great white and whale sharks.\nFossils show that sharks have been\n" +
                "around for 420 million years, since the early Silurian."                
            },

            new Animal
            {
                AnimalId = 2,
                Name = "Fish",
                Age = 2,
                CategoryId = 1,
                PictureId = 4,
                Description = "Fish are gill-bearing aquatic craniate animals that lack limbs with digits.\n" +
                "They form a sister group to the tunicates, together forming the olfactores.\n" +
                "Included in this definition are the living hagfish, lampreys, and cartilaginous\n" +
                "and bony fish as well as various extinct related groups."
            },

            new Animal
            {
                AnimalId = 3,
                Name = "Dolphin",
                Age = 10,
                CategoryId = 1,
                PictureId = 3,
                Description = "Dolphins are part of the toothed whales. Generally, they are among the smaller whales.\n" +
                "Most live in salt water oceans, but some live in rivers – there are oceanic dolphins and river dolphins.\n" +
                "Dolphins are from 1.5 metres (4.9 ft) to 4 metres (13 ft) long, but the largest dolphin,\n" +
                "the killer whale (or orca), can be up to 8 metres (26 ft) long."
            },

            new Animal
            {
                AnimalId = 4,
                Name = "Whale",
                Age = 1,
                CategoryId = 1,
                PictureId = 12,
                Description = "Whales are a large marine mammal species which live in the ocean.\n" +
                "Like other mammals, they breathe oxygen from the air, have a small amount of hair, and are warm blooded."
            },
            #endregion

            #region AddingMamals
            new Animal
            {
                AnimalId = 5,
                Name = "Tiger",
                Age = 3,
                CategoryId = 2,
                PictureId = 10,
                Description = "Tigers are distinctive orange-and-black-striped cats that are easily recognizable and highly endangered,\n" +
                    "having been eradicated from 93% of their historic range.\n" +
                    "The nine subspecies of this animals are restricted to small pockets of Asia,\n" +
                    "and their population is estimated to be between 3,000 and 4,000 cats in the wild."
            },

            new Animal
            {
                AnimalId = 6,
                Name = "Lion",
                Age = 10,
                CategoryId = 2,
                PictureId = 5,
                Description = "The lion is a large mammal of the Felidae family.\n" +
                "Some large males weigh over 250 kg. Today, wild lions live in sub-Saharan Africa and in Asia.\n" +
                "Lions are adapted for life in grasslands and mixed areas with trees and grass.\n" +
                "The relatively small females are fast runners over short distances, and coordinate their hunting of herd animals."
            },

            new Animal
            {
                AnimalId = 7,
                Name = "Monkey",
                Age = 3,
                CategoryId = 2,
                PictureId = 7,
                Description = "Monkey is a common name that may refer to groups or species of mammals,\n" +
                "in part, the simians of infraorder Simiiformes.\n" +
                "The term is applied descriptively to groups of primates, such as families\n" +
                "of New World monkeys and Old World monkeys.\n" +
                "Many monkey species are tree-dwelling, although there are species that live primarily on the ground,\n" +
                "uch as baboons. Most species are also active during the day.\n" +
                "Monkeys are generally considered to be intelligent, especially the Old World monkeys of Catarrhini."
            },

            new Animal
            {
                AnimalId = 8,
                Name = "Bear",
                Age = 25,
                CategoryId = 2,
                PictureId = 1,
                Description = "Bears are carnivoran mammals of the family Ursidae. They are classified as caniforms, or doglike carnivorans.\n" +
                "Although only eight species of bears are extant, they are widespread, appearing in a wide\n" +
                "variety of habitats throughout the Northern Hemisphere and partially in the Southern Hemisphere.\n" +
                "Bears are found on the continents of North America, South America, Europe, and Asia."
            },
            #endregion

            #region AddingReptiles
            new Animal
            {
                AnimalId = 9,
                Name = "Turtle",
                Age = 80,
                CategoryId = 3,
                PictureId = 11,
                Description = "These shelled reptilians can be found nearly worldwide.\n" +
                    "Turtles and tortoises are easily identified by their bony or cartilaginous shells.\n" +
                    "This shell helps protect turtles and tortoises from predators,\n" +
                    "and is actually developed from their rib bones\n"
            },

            new Animal
            {
                AnimalId = 10,
                Name = "Snake",
                Age = 20,
                CategoryId = 3,
                PictureId = 9,
                Description = "Snakes are elongated, legless, carnivorous reptiles of the suborder Serpentes.\n" +
                "Like all other squamates, snakes are ectothermic, amniote vertebrates covered in overlapping scales.\n" +
                "Many species of snakes have skulls with several more joints than their lizard ancestors,\n" +
                "enabling them to swallow prey much larger than their heads with their highly mobile jaws."
            },

            new Animal
            {
                AnimalId = 11,
                Name = "Crocodile",
                Age = 40,
                CategoryId = 3,
                PictureId = 2,
                Description = "A crocodile is a large amphibious reptile. It lives mostly in large tropical rivers,\n" +
                "where it is an ambush predator. One species, the Australian saltie,\n" +
                "also travels in coastal salt water. In very dry climates, crocodiles\n" +
                "may aestivate and sleep out the dry season."
            },

            new Animal
            {
                AnimalId = 12,
                Name = "Lizard",
                Age = 120,
                CategoryId = 3,
                PictureId = 6,
                Description = "Lizards are a widespread group of squamate reptiles, with over 6,000 species,\n" +
                "ranging across all continents except Antarctica, as well as most oceanic island chains.\n" +
                "The group is paraphyletic as it excludes the snakes and Amphisbaenia; some lizards are more\n" +
                "closely related to these two excluded groups than they are to other lizards."
            }
            #endregion
                        
            );
            #endregion

            #region AddingComments

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1,
                    AnimalId = 1,
                    CommentInfo = "Shark do not have bones.",
                    
                },

                new Comment
                {
                    CommentId = 2,
                    AnimalId = 1,
                    CommentInfo = "Most sharks have good eyesight."
                },

                new Comment
                {
                    CommentId = 3,
                    AnimalId = 2,
                    CommentInfo = "The Croaker is the loudest fish."
                },

                new Comment
                {
                    CommentId = 4,
                    AnimalId = 2,
                    CommentInfo = "Did you know that fish can get sunburn?"
                },

                new Comment
                {
                    CommentId = 5,
                    AnimalId = 3,
                    CommentInfo = "Dolphins are carnivores."
                },
                
                new Comment
                {
                    CommentId = 6,
                    AnimalId = 3,
                    CommentInfo = "Dolphins are part of the family of whales"
                },
                
                new Comment
                {
                    CommentId = 7,
                    AnimalId = 3,
                    CommentInfo = "Dolphins are very social, living in groups that hunt and even play together."
                },
                
                new Comment
                {
                    CommentId = 8,
                    AnimalId = 4,
                    CommentInfo = "The blue whale is the largest animal in the world."
                },
                
                new Comment
                {
                    CommentId = 9,
                    AnimalId = 4,
                    CommentInfo = "Some species of whales are among the longest lived mammals."
                },

                new Comment
                {
                    CommentId = 10,
                    AnimalId = 4,
                    CommentInfo = "Whales are often caught in nets."
                },

                new Comment
                {
                    CommentId = 11,
                    AnimalId = 5,
                    CommentInfo = "Tigers are the largest amongst other wild cats."
                },
                
                new Comment
                {
                    CommentId = 12,
                    AnimalId = 5,
                    CommentInfo = "A punch from a tiger may kill you."
                },
                
                new Comment
                {
                    CommentId = 13,
                    AnimalId = 5,
                    CommentInfo = "Tiger cubs are born blind and only half of the cubs survive."
                },
                
                new Comment
                {
                    CommentId = 14,
                    AnimalId = 6,
                    CommentInfo = "Lions usually live in groups of 10 or 15 animals called prides."
                },
                
                new Comment
                {
                    CommentId = 15,
                    AnimalId = 6,
                    CommentInfo = "An adult male’s roar can be heard up to 8km away."
                },
                
                new Comment
                {
                    CommentId = 16,
                    AnimalId = 6,
                    CommentInfo = "A female lion needs 5kg of meat a day. A male needs 7kg or more a day."
                },
                
                new Comment
                {
                    CommentId = 17,
                    AnimalId = 6,
                    CommentInfo = "Lions run at a speed of up to 81kmph."
                },
                
                new Comment
                {
                    CommentId = 18,
                    AnimalId = 7,
                    CommentInfo = "There are currently 264 known monkey species."
                },
                
                new Comment
                {
                    CommentId = 19,
                    AnimalId = 7,
                    CommentInfo = "Some monkeys live on the ground, while others live in trees."
                },
                
                new Comment
                {
                    CommentId = 20,
                    AnimalId = 8,
                    CommentInfo = "At birth, bear cubs are blind and naked."
                },
                
                new Comment
                {
                    CommentId = 21,
                    AnimalId = 9,
                    CommentInfo = "These creatures date back to the time of the dinosaurs, over 200 million years ago!"
                },
                
                new Comment
                {
                    CommentId = 22,
                    AnimalId = 10,
                    CommentInfo = "There are over 3000 kinds of snakes in the world."
                },
                
                new Comment
                {
                    CommentId = 23,
                    AnimalId = 10,
                    CommentInfo = "Only 6 countries in the world don’t have snakes."
                },
                
                new Comment
                {
                    CommentId = 24,
                    AnimalId = 10,
                    CommentInfo = "Snakes first appeared 98 million years ago."
                },
                
                new Comment
                {
                    CommentId = 25,
                    AnimalId = 10,
                    CommentInfo = "725 snake species are venomous."
                },
                
                new Comment
                {
                    CommentId = 26,
                    AnimalId = 10,
                    CommentInfo = "Captive snakes can live up to 170 years, while wild snakes can reach 100 years"
                },
                
                new Comment
                {
                    CommentId = 27,
                    AnimalId = 11,
                    CommentInfo = "Crocodiles are the biggest reptiles on Earth."
                },
                
                new Comment
                {
                    CommentId = 28,
                    AnimalId = 11,
                    CommentInfo = "They can keep open their jaw underwater."
                },
                
                new Comment
                {
                    CommentId = 29,
                    AnimalId = 11,
                    CommentInfo = "Crocodiles can not sweat."
                },
                
                new Comment
                {
                    CommentId = 30,
                    AnimalId = 12,
                    CommentInfo = "Lizards can move their eyelids."
                },

                new Comment
                {
                    CommentId = 31,
                    AnimalId = 12,
                    CommentInfo = "There are more than 6,000 different lizard species."
                });
            #endregion

            #region AddingImages
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    ImageId = 1,
                    ImageName = "Bear",
                    ImagePath = "Images/Bear.jpg"
                },

                new Image
                {
                    ImageId = 2,
                    ImageName = "Crocodile",
                    ImagePath = "Images/Crocodile.jpg"
                },

                new Image
                {
                    ImageId = 3,
                    ImageName = "Dolphin",
                    ImagePath = "Images/Dolphin.jpg"
                },

                new Image
                {
                    ImageId = 4,
                    ImageName = "Fish",
                    ImagePath = "Images/Fish.jpg"
                },

                new Image
                {
                    ImageId = 5,
                    ImageName = "Lion",
                    ImagePath = "Images/Lion.jpg"
                },

                new Image
                {
                    ImageId = 6,
                    ImageName = "Lizard",
                    ImagePath = "Images/Lizard.jpg"
                },

                new Image
                {
                    ImageId = 7,
                    ImageName = "Monkey",
                    ImagePath = "Images/Monkey.jpg"
                },

                new Image
                {
                    ImageId = 8,
                    ImageName = "Shark",
                    ImagePath = "Images/Shark.jpg"
                },

                new Image
                {
                    ImageId = 9,
                    ImageName = "Snake",
                    ImagePath = "Images/Snake.jpg"
                },

                new Image
                {
                    ImageId = 10,
                    ImageName = "Tiger",
                    ImagePath = "Images/Tiger.jpg"
                },

                new Image
                {
                    ImageId = 11,
                    ImageName = "Turtle",
                    ImagePath = "Images/Turtle.jpg"
                },

                new Image
                {
                    ImageId = 12,
                    ImageName = "Whale",
                    ImagePath = "Images/Whale.jpg"
                }
                );
            #endregion
        }
    }
}