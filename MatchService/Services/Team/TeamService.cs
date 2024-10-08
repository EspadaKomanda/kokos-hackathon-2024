using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Repository;

namespace MatchService.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _repository;
        public TeamService(IRepository<Team> repository)
        {
            _repository = repository;
        }
        public bool Add(Team entity)
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

        public bool Delete(Team entity)
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

        public IQueryable<Team> FindById(long TeamId, FindOptions? findOptions = null)
        {
            try
            {
                return _repository.Find(x => x.TeamId == TeamId, findOptions);
            }
            catch (Exception ex)
            {
                throw new FindException(ex.Message);
            }
        }

        public IQueryable<Team> GetAll(FindOptions? findOptions = null)
        {
            try
            {
                return _repository.GetAll(findOptions);
            }
            catch (Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        public bool Update(Team entity)
        {
            try
            {
                return _repository.Update(entity);
            }
            catch (Exception ex)
            {
                throw new UpdateException(ex.Message);
            }
        }
    }
}