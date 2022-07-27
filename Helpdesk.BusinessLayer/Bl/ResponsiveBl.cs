using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class ResponsiveBl
    {
        private IRepository _repository;
        private IMapper _mapper;
        //private IRepositoryMongoDb _repositoryMongoDb;

        public ResponsiveBl(
            IRepository repository
            //, IRepositoryMongoDb repositoryMongoDb
            , IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
            //_repositoryMongoDb = repositoryMongoDb;
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

        public async Task SendResponsive(string documentId)
        {
            
        }
    }
}