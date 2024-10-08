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
        public IQueryable<Team> GetAll(Team? findOptions = null);
        public IQueryable<Team> FindById(long TeamId, FindOptions? findOptions = null);
        public bool Add(Team entity);
        public bool Update(Team entity);
        public bool Delete(Team entity);
    }
}