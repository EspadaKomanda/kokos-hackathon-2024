using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Repository;

namespace MatchService.Services
{
    public interface ITeamRoleService
    {
        public IQueryable<TeamRole> GetAll(FindOptions? findOptions = null);
        public Task<TeamRole> FindById(long TeamRoleId, FindOptions? findOptions = null);
        public Task<bool> Add(TeamRole entity);
        public bool Update(TeamRole entity);
        public bool Delete(TeamRole entity);
    }
}