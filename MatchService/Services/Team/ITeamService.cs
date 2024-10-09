using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Repository;

namespace MatchService.Services
{
    public interface ITeamService
    {
        public IQueryable<Team> GetAll(FindOptions? findOptions = null);
        public Task<Team> FindById(long TeamId, FindOptions? findOptions = null);
        public Task<bool> Add(Team entity);
        public bool Update(Team entity);
        public bool Delete(Team entity);
    }
}