using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Repository;

namespace MatchService.Services
{
    public interface IMatchService
    {
        public IQueryable<Match> GetAll(int page,FindOptions? findOptions = null);
        public Task<Match> FindById(long MatchId, FindOptions? findOptions = null);
        public IQueryable<Match> GetAll(FindOptions? findOptions = null);
        public Task<bool> Add(Match entity);
        public bool Update(Match entity);
        public bool Delete(Match entity);

    }
}