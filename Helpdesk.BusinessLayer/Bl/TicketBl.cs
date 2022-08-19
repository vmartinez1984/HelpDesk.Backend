using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;
using MongoDB.Bson;
using Tickets.Core.Dtos;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class TicketBl : ITicketBl
    {
        private IRepository _repository;
        private IRepositoryTickets _repositoryTickets;
        private IMapper _mapper;        

        public TicketBl(
            IRepository repository
            , IRepositoryTickets repositoryTickets
            , IMapper mapper        
        )
        {
            _repository = repository;
            _repositoryTickets = repositoryTickets;
            _mapper = mapper;            
        }

        public async Task<string> AddAsync(TicketDtoIn item)
        {
            TicketEntity entity;

            entity = _mapper.Map<TicketEntity>(item);
            await SetAgencyAsync(entity);
            await SetPersonAsync(entity);
            await SetUserAsync(entity);
            await SetCategory(entity, item.CategoryId);
            await SetSubcategory(entity, item.SubcategoryId);
            await SetLogs(entity, item);
            await _repositoryTickets.Ticket.AddAsync(entity);

            return entity.Id;
        }

        private async Task SetLogs(TicketEntity entity, TicketDtoIn item)
        {
            entity.ListLog = new List<LogEntity>();
            entity.ListLog.Add(new LogEntity
            {
                Content = item.Description,
                DateRegistration = DateTime.Now,
                State = "Descripción",
                UserName = await _repository.User.GetNameAsync(item.UserId),
                Id = ObjectId.GenerateNewId().ToString()
            });
            if (string.IsNullOrEmpty(item.Solution))
            {
                //Aun no ha sido solucionafo 
            }
            else
            {
                entity.ListLog.Add(new LogEntity
                {
                    Content = item.Solution,
                    State = "Solucionado",
                    DateRegistration = DateTime.Now,
                    UserName = await _repository.User.GetNameAsync(item.UserId),
                    Id = ObjectId.GenerateNewId().ToString()
                });
            }
        }

        private async Task SetSubcategory(TicketEntity entity, string subcategoryId)
        {
            SubcategoryEntity subcategoryEntity;

            subcategoryEntity = await _repositoryTickets.Subcategory.GetAsync(subcategoryId);

            entity.Subcategory = subcategoryEntity.Name;
        }

        private async Task SetCategory(TicketEntity entity, string categoryId)
        {
            CategoryEntity categoryEntity;

            categoryEntity = await _repositoryTickets.Category.GetAsync(categoryId);

            entity.Category = categoryEntity.Name;
        }

        private async Task SetUserAsync(TicketEntity entity)
        {
            // UserDtoOut userDtoOut;

            // userDtoOut = await _userBl.GetAsync(entity.UserId);

            entity.UserName = await _repository.User.GetNameAsync(entity.UserId);
        }

        private async Task SetPersonAsync(TicketEntity entity)
        {
            PersonEntity personEntity;

            personEntity = await _repository.Person.GetAsync(entity.PersonId);

            entity.PersonName = $"{personEntity.Name} {personEntity.LastName}";
        }

        private async Task SetAgencyAsync(TicketEntity entity)
        {
            AgencyEntity agencyEntity;

            agencyEntity = await _repository.Agency.GetAsync(entity.AgencyId);

            entity.AgencyName = agencyEntity.Name;
        }

        public Task<List<TicketDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagerDtoOut> GetAsync(SearchDtoIn search)
        {
            PagerDtoOut response;
            Tickets.Core.Entities.PagerEntity pagerEntity;
            List<TicketEntity> entities;
            
            pagerEntity = new Tickets.Core.Entities.PagerEntity
            {
                PageCurrent = search.PageCurrent,
                RecordsPerPage = search.RecordsPerPage,
                Search = search.Search,
                SortColumn = search.SortColumn,
                SortColumnDir = search.SortColumnDir
            };
            entities = await _repositoryTickets.Ticket.GetAsync(pagerEntity);
            response = new PagerDtoOut
            {
                List = _mapper.Map<List<TicketDto>>(entities),
                PageCurrent = pagerEntity.PageCurrent,
                RecordsPerPage = pagerEntity.RecordsPerPage,
                TotalRecords = pagerEntity.TotalRecords,
                TotalRecordsFiltered = pagerEntity.TotalRecordsFiltered
            };

            return response;
        }
        
    }//end class
}