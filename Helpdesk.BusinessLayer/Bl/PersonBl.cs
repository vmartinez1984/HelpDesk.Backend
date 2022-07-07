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

        public Task<int> AddAsync(PersonDtoIn item)
        {
            throw new NotImplementedException();
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
            PersonPagerEntity personPagerEntity;

            personSearchEntity = new PersonSearchEntity
            {
                AgencyId = search.AgencyId,
                PageCurrent = search.PageCurrent,
                PersonLastName = search.PersonLastName,
                PersonName = search.PersonName,
                ProjectId = search.ProjectId,
                RecordsPerPage = search.RecordsPerPage,
                TotalRecords = search.TotalRecords
            };
            personPagerEntity = await _repository.Person.SearchAsync(personSearchEntity);

            response = new PersonPagerDtoOut
            {
                ListPersons = new List<PersonDtoOut>()
            };

            return response;
        }
    }
}