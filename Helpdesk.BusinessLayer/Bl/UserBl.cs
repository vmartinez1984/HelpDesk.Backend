using AutoMapper;
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
            if (await _repository.User.ExistsAsync(item.Email))
            {
                throw new Exception("El correo ya existe");
            }

            UserEntity entity;

            entity = _mapper.Map<UserEntity>(item);
            entity.PersonId = await SetPersonAsycn(item);
            entity.Id = await _repository.User.AddAsync(entity);

            return entity.Id;
        }

        private async Task<int> SetPersonAsycn(UserDtoIn item)
        {
            PersonEntity entity;

            entity = new PersonEntity
            {
                AgencyId = item.AgencyId,
                DateRegistration = DateTime.Now,
                IsActive = true,
                LastName = item.LastName,
                Name = item.Name,
                Notes = item.Name,
                UserId = item.UserId
            };

            return await _repository.Person.AddAsync(entity);
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

        public async Task<List<UserDtoOut>> GetAsync(int? projectId, int? agencyId)
        {
            List<UserEntity> entities;
            List<UserDtoOut> list;

            entities = await _repository.User.GetAsync(projectId, agencyId);
            list = _mapper.Map<List<UserDtoOut>>(entities);
            await SetPersonsAsync(list);

            return list;
        }

        private async Task SetPersonsAsync(List<UserDtoOut> list)
        {
            foreach (var item in list)
            {
                PersonEntity person;

                person = await _repository.Person.GetAsync(item.PersonId);
                item.Name = person.Name;
                item.LastName = person.LastName;
            }
        }
        private async Task SetPersonAsync(UserDtoOut item)
        {
            PersonEntity person;

            person = await _repository.Person.GetAsync(item.PersonId);
            item.Name = person.Name;
            item.LastName = person.LastName;            
        }

        public async Task<UserDtoOut> Login(LoginDto login)
        {
            UserEntity entity;
            UserDtoOut item;

            entity = await _repository.User.GetAsync(login.User);
            if (entity.Password == login.Password)
            {
                item = _mapper.Map<UserDtoOut>(entity);
                await SetPersonAsync(item);
            }
            else
                item = null;

            return item;
        }

        public async Task UpdateAsync(UserDtoIn item, int id)
        {
            UserEntity entity;

            entity = await _repository.User.GetAsync(id);
            // entity.Name = item.Name;
            // entity.Password = item.Password;
            await _repository.User.UpdateAsync(entity);
        }

        public async Task<bool> Exists(string email)
        {
            return await _repository.User.ExistsAsync(email);
        }
    }//end class
}