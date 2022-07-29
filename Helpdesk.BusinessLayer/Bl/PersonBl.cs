using AutoMapper;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class PersonBl : IPersonBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public PersonBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PersonDtoIn item)
        {
            PersonEntity entity;

            entity = _mapper.Map<PersonEntity>(item);
            entity.Id = await _repository.Person.AddAsync(entity);

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDtoOut> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PersonDtoIn item, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonPagerDtoOut> GetAsync(PersonSearchDtonIn search)
        {
            PersonPagerDtoOut response;
            PersonSearchEntity personSearchEntity;
            List<PersonEntity> entities;

            personSearchEntity = _mapper.Map<PersonSearchEntity>(search);
            entities = await _repository.Person.GetAsync(personSearchEntity);
            response = new PersonPagerDtoOut
            {
                ListPersons = _mapper.Map<List<PersonDtoOut>>(entities),
                PersonSearch = new PersonSearchDto
                {
                    PageCurrent = personSearchEntity.PageCurrent,
                    RecordsPerPage = personSearchEntity.RecordsPerPage,
                    TotalRecords = personSearchEntity.TotalRecords,
                    TotalRecordsFiltered = personSearchEntity.TotalRecordsFiltered
                }
            };
            await SetAgencyNamesAsync(response);

            return response;
        }

        private async Task SetAgencyNamesAsync(PersonPagerDtoOut response)
        {
            foreach (var item in response.ListPersons)
            {
                var agency = await _repository.Agency.GetAsync(item.AgencyId);
                item.AgencyName = agency.Code + " " + agency.Name;
            }
        }
    }
}