using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Repository;

namespace MatchService.Services
{
    public interface IPlayerService
    {
        public IQueryable<Player> GetAll(FindOptions? findOptions = null);
        public Task<Player> FindById(long PlayerId, FindOptions? findOptions = null);
        public Task<bool> Add(Player entity);
        public bool Update(Player entity);
        public bool Delete(Player entity);
    }
}