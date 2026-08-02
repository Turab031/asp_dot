using pro4_rsv.Models;

namespace pro4_rsv.Services
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetSuperHero();

        SuperHero GetHeroById(int id);

        void AddSuperHero(SuperHero hero);

        void UpdateHero(int id, SuperHero hero);

        void DeleteHero(int id);
    }
}