using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Repository;

namespace MatchService.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepository<Match> _repository;
        public MatchService(IRepository<Match> repository)
       {
            _repository = repository;
        }
        public bool Add(Match entity)
        {
            try
            {
                return _repository.Add(entity);
            }
            catch (Exception ex)
            {
                throw new AddException(ex.Message);
            }
        }


        public bool Delete(Match entity)
        {
            try
            {
                return _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new DeleteException(ex.Message);
            }
        }

        public IQueryable<Match> FindById(long MatchId, FindOptions? findOptions = null)
        {
            try
            {
                return _repository.Find(x => x.MatchId == MatchId, findOptions);
            }
            catch (Exception ex)
            {
                throw new FindException(ex.Message);
            }
            
        }

        public IQueryable<Match> GetAll(FindOptions? findOptions = null)
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

        public bool Update(Match entity)
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