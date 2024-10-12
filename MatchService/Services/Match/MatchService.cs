using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using MatchService.Exceptions;
using MatchService.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MatchService.Services
{
    public class MatchService : IMatchService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<MatchService> _logger;
        private readonly IRepository<Match> _repository;
        public MatchService(IRepository<Match> repository, IDistributedCache cache, ILogger<MatchService> logger)
       {
            _repository = repository;
            _cache = cache;
            _logger = logger;
        }
        public async Task<bool> Add(Match entity)
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
        //TODO: Add Caching
        public async Task<Match> FindById(long MatchId, FindOptions? findOptions = null)
        {
            try
            {
                return await _repository.FindOne(x => x.MatchId == MatchId, findOptions);
            }
            catch (Exception ex)
            {
                throw new FindException(ex.Message);
            }
            
        }
        //FIXME: Add taking by pages(10 matches per page)
        //TODO: Add Caching
        public IQueryable<Match> GetAll(int page,FindOptions? findOptions = null)
        {
            try
            {
                
                var result = _repository.GetAll(findOptions).Skip((page - 1) * 10).Take(10);
                return result;
            }
            catch (Exception ex)
            {
                throw new GetException(ex.Message);
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