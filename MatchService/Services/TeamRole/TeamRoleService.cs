using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Repository;

namespace MatchService.Services
{
    public class TeamRoleService
    {
        private readonly IRepository<TeamRole> _repository;
        public TeamRoleService(IRepository<TeamRole> repository)
        {
            _repository = repository;
        }
        public bool Add(TeamRole entity)
        {
            try
            {
                return _repository.Add(entity);
            }
            catch(Exception ex)
            {
                throw new AddException(ex.Message);
            }
        }

        public bool Delete(TeamRole entity)
        {
            try
            {
                return _repository.Delete(entity);
            }
            catch(Exception ex)
            {
                throw new DeleteException(ex.Message);
            }
        }

        public IQueryable<TeamRole> FindById(long TeamRoleId, FindOptions? findOptions = null)
        {
            try
            {
                return _repository.Find(x => x.TeamRoleId == TeamRoleId, findOptions);
            }
            catch(Exception ex)
            {
                throw new FindException(ex.Message);
            }
        }

        public IQueryable<TeamRole> GetAll(FindOptions? findOptions = null)
        {
            try
            {
                return _repository.GetAll(findOptions);
            }
            catch(Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        public bool Update(TeamRole entity)
        {
            try
            {
                return _repository.Update(entity);
            }
            catch(Exception ex)
            {
                throw new UpdateException(ex.Message);
            }
        }

    }
}