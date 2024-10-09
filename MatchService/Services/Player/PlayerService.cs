using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Repository;

namespace MatchService.Services
{
    public class PlayerService : IPlayerService
    {
        // TODO: Add caching
        private readonly IRepository<Player> _repository;
        public PlayerService(IRepository<Player> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Player entity)
        {
            try
            {
                return await _repository.Add(entity);
            }
            catch (Exception ex)
            {
                throw new AddException(ex.Message);
            }
        }

        public bool Delete(Player entity)
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
        //TODO: Add Caching
        public async Task<Player> FindById(long PlayerId, FindOptions? findOptions = null)
        {
            try
            {
                return await _repository.FindOne(x => x.PlayerId == PlayerId, findOptions);
            }
            catch (Exception ex)
            {
                throw new FindException(ex.Message);
            }
        }
        //TODO: Add Caching
        public IQueryable<Player> GetAll(FindOptions? findOptions = null)
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

        public bool Update(Player entity)
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