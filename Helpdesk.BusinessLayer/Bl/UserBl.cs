using AutoMapper;
using Helpdesk.Core.Dtos;
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
            if (await _repository.User.ExistsAsync(item.Email, 0))
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
                Notes = item.Notes,
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
            await SetDataUserDto(item);

            return item;
        }

        private async Task SetDataUserDto(UserDtoOut item)
        {
            await SetPersonAsync(item);
            await SetAgencyAsync(item);
            item.UserName = await _repository.User.GetNameAsync(item.UserId);
        }

        private async Task SetAgencyAsync(UserDtoOut item)
        {
            AgencyEntity agencyEntity;

            agencyEntity = await _repository.Agency.GetAsync(item.AgencyId);

            item.ProjectId = agencyEntity.ProjectId;
            item.AgencyName = $"{agencyEntity.Code} {agencyEntity.Name}";
        }

        public async Task<UserListDtoOut> GetAsync(UserSearchDtoIn userSearch)
        {
            UserSearchEntity userSearchEntity;
            UserListDtoOut userListDtoOut;
            List<UserEntity> listUserEntities;

            userSearchEntity = _mapper.Map<UserSearchEntity>(userSearch);
            //El total de registros se pasa por referencia en userSearchEntity
            listUserEntities = await _repository.User.GetAsync(userSearchEntity);
            userListDtoOut = _mapper.Map<UserListDtoOut>(userSearchEntity);
            userListDtoOut.ListUsers = _mapper.Map<List<UserDtoOut>>(listUserEntities);
            await SetPersonsAsync(userListDtoOut.ListUsers);

            return userListDtoOut;
        }

        private async Task SetPersonsAsync(List<UserDtoOut> list)
        {
            foreach (var item in list)
            {
                await SetDataUserDto(item);
            }
        }

        private async Task SetPersonAsync(UserDtoOut item)
        {
            PersonEntity person;

            person = await _repository.Person.GetAsync(item.PersonId);
            item.Name = person.Name;
            item.LastName = person.LastName;
            item.AgencyId = person.AgencyId;
            item.Notes = person.Notes;
        }

        public async Task<UserDtoOut> Login(LoginDto login)
        {
            UserEntity entity;
            UserDtoOut item;

            entity = await _repository.User.GetAsync(login.User);
            if (entity is null)
                item = null;
            else if (entity.Password == login.Password)
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

        public async Task<bool> Exists(string email, int userId)
        {
            return await _repository.User.ExistsAsync(email, userId);
        }

        public async Task<bool> Exists(string email)
        {
            return await _repository.User.ExistsAsync(email);
        }

        public async Task UpdateAsync(UserDtoOut item)
        {
            UserEntity userEntity;

            userEntity = await _repository.User.GetAsync(item.Id);
            userEntity.Password = item.Password;
            userEntity.RoleId = item.RoleId;
            userEntity.Email = item.Email;

            await _repository.User.UpdateAsync(userEntity);

            PersonEntity personEntity;

            personEntity = await _repository.Person.GetAsync(userEntity.PersonId);
            personEntity.Name = item.Name;
            personEntity.LastName = item.LastName;
            personEntity.AgencyId = item.AgencyId;
            personEntity.Notes = item.Notes;

            await _repository.Person.UpdateAsync(personEntity);
        }

        public async Task<PagerDtoOut> GetAsync(SearchDtoIn search)
        {
            PagerDtoOut response;
            PagerEntity pagerEntity;
            List<UserEntity> entities;

            pagerEntity = _mapper.Map<PagerEntity>(search);
            entities = await _repository.User.GetAsync(pagerEntity);
            response = new PagerDtoOut
            {
                List = _mapper.Map<List<UserDto>>(entities),
                PageCurrent = pagerEntity.PageCurrent,
                RecordsPerPage = pagerEntity.RecordsPerPage,
                TotalRecords = pagerEntity.TotalRecords,
                TotalRecordsFiltered = pagerEntity.TotalRecordsFiltered
            };

            return response;
        }

    }//end class
}