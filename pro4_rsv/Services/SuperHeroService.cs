using pro4_rsv.Data;
using pro4_rsv.Models;

namespace pro4_rsv.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _datacontext;

        public SuperHeroService(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        // Get all heroes
        public List<SuperHero> GetSuperHero()
        {
            return _datacontext.SuperHeroes.ToList();
        }

        // Get hero by id
        public SuperHero? GetHeroById(int id)
        {
            return _datacontext.SuperHeroes.FirstOrDefault(h => h.Id == id);
        }

        // Add hero
        public void AddSuperHero(SuperHero hero)
        {
            _datacontext.SuperHeroes.Add(hero);
            _datacontext.SaveChanges();
        }

        // Update hero
        public void UpdateHero(int id, SuperHero hero)
        {
            var existingHero = _datacontext.SuperHeroes.FirstOrDefault(h => h.Id == id);

            if (existingHero != null)
            {
                existingHero.Name = hero.Name;
                existingHero.FirstName = hero.FirstName;
                existingHero.LastName = hero.LastName;
                existingHero.Place = hero.Place;

                _datacontext.SaveChanges();
            }
        }

        // Delete hero
        public void DeleteHero(int id)
        {
            var hero = _datacontext.SuperHeroes.FirstOrDefault(h => h.Id == id);

            if (hero != null)
            {
                _datacontext.SuperHeroes.Remove(hero);
                _datacontext.SaveChanges();
            }
        }
    }
}