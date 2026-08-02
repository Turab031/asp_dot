using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro4_rsv.Models;

namespace pro4_rsv.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superhero = new List<SuperHero>
        {
            new SuperHero{Id=1,Name="spiderman",FirstName="peter",LastName="parker",Place="new york"},

            new SuperHero{Id=2,Name="batman",FirstName="bruce",LastName="wayne",Place="gothana"},
            new SuperHero{Id=3,Name="ironman",FirstName="tont",LastName="jr",Place="new york"},
        };

        public List<SuperHero> GetSuperHero()
        {
            return superhero;
        }

        public SuperHero GetHeroById(int id)
        {
            return superhero.FirstOrDefault(h => h.Id == id);
        }

        public void AddSuperHero(SuperHero hero)
        {
            superhero.Add(hero);
        }

        public void UpdateHero(int id, SuperHero hero)
        {
            var existingHero = superhero.FirstOrDefault(h => h.Id == id);

            if (existingHero != null)
            {
                existingHero.Name = hero.Name;
                existingHero.FirstName = hero.FirstName;
                existingHero.LastName = hero.LastName;
                existingHero.Place = hero.Place;
            }
        }

        public void DeleteHero(int id)
        {
            var hero = superhero.FirstOrDefault(h => h.Id == id);

            if (hero != null)
            {
                superhero.Remove(hero);
            }
        }
    }
}