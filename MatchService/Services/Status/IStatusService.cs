using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Repository;

namespace MatchService.Services
{
    public interface IStatusService
    {
        public IQueryable<Status> GetAll(FindOptions? findOptions = null);
        public Task<Status> FindById(long StatusId, FindOptions? findOptions = null);
        public Task<bool> Add(Status entity);
        public bool Update(Status entity);
        public bool Delete(Status entity);
    }
}