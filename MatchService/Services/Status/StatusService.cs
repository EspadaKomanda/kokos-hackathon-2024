using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Repository;

namespace MatchService.Services
{
    public class StatusService : IStatusService
    {
        private readonly IRepository<Status> _repository;
        public StatusService(IRepository<Status> repository)
        {
            _repository = repository;
        }
        public bool Add(Status entity)
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

        public bool Delete(Status entity)
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

        public IQueryable<Status> FindById(long StatusId, FindOptions? findOptions = null)
        {
            try
            {
                return _repository.Find(x => x.StatusId == StatusId, findOptions);
            }
            catch (Exception ex)
            {
                throw new FindException(ex.Message);
            }
        }

        public IQueryable<Status> GetAll(FindOptions? findOptions = null)
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
        
        public bool Update(Status entity)
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