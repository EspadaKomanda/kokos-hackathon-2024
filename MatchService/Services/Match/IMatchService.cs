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
        public IQueryable<Match> GetAll(FindOptions? findOptions = null);
        public IQueryable<Match> Find(string MEFName, FindOptions? findOptions = null);
        public bool Add(Match entity);
        public bool Update(Match entity);
        public bool Delete(Match entity);

    }
}