using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class UserBl : IUserBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public UserBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(UserDtoIn item)
        {
            UserEntity entity;

            entity = _mapper.Map<UserEntity>(item);
            entity.Id = await _repository.User.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.User.DeleteAsync(id, 0);
        }

        public async Task<UserDtoOut> GetAsync(int id)
        {
            UserEntity entity;
            UserDtoOut item;

            entity = await _repository.User.GetAsync(id);
            item = _mapper.Map<UserDtoOut>(entity);

            return item;
        }

        public async Task<List<UserDtoOut>> GetAsync()
        {
            List<UserEntity> entities;
            List<UserDtoOut> list;

            entities = await _repository.User.GetAsync();
            list = _mapper.Map<List<UserDtoOut>>(entities);

            return list;
        }

        public async Task UpdateAsync(UserDtoIn item, int id)
        {
            UserEntity entity;

            entity = await _repository.User.GetAsync(id);
            // entity.Name = item.Name;
            // entity.Password = item.Password;
            await _repository.User.UpdateAsync(entity);
        }
        
    }//end class
}