using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.Notifications;

namespace Helpdesk.BusinessLayer.Bl
{
    public class ResponsiveBl : IResponsiveBl
    {
        private IRepository _repository;
        private IMapper _mapper;
        private EmailNotification _emailNotification;

        //private IRepositoryMongoDb _repositoryMongoDb;

        public ResponsiveBl(
            IRepository repository
            //, IRepositoryMongoDb repositoryMongoDb
            , IMapper mapper
            , EmailNotification emailNotification
        )
        {
            _repository = repository;
            _mapper = mapper;
            //_repositoryMongoDb = repositoryMongoDb;
            _emailNotification = emailNotification;
        }

        public async Task<bool> ExistsWithoutSendAsync()
        {
            bool existsWithoutSend;

            existsWithoutSend = await _repository.Resposive.ExistsWithoutSendAsync();

            return existsWithoutSend;
        }

        public async Task<ResponsiveDto> GetWithoutSendAsync()
        {
            ResponsiveEntity entities;
            ResponsiveDto item;

            entities = await _repository.Resposive.GetWithoutSendAsync();
            item = _mapper.Map<ResponsiveDto>(entities);

            return item;
        }

        public void SendResponsive(string documentId)
        {
            ResponsiveEntity entity;
            
            entity = _repository.Resposive.GetAsync(documentId).Result;

            _emailNotification.Send(entity.Email, documentId);
        }

        public void SendResponsive(string email, string documentId)
        {
            ResponsiveEntity entity;            

            entity = _repository.Resposive.GetAsync(documentId).Result;            

            _emailNotification.Send(email, documentId);
        }

        public void UpdateDateSend(int id)
        {
            ResponsiveEntity entity;

            entity = _repository.Resposive.GetAsync(id).Result;
            entity.DateSend = DateTime.Now;

            _repository.Resposive.UpdateAsync(entity);
        }
    }
}