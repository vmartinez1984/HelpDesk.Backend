using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class FormAgencyBl : IFormAgencyBl
    {
        private IRepository _repository;
        private IMapper _mapper;
        private IRepositoryMongoDb _repositoryMongoDb;

        public FormAgencyBl(IRepository repository, IRepositoryMongoDb repositoryMongoDb, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryMongoDb = repositoryMongoDb;
        }

        public async Task<int> AddAsync(FormAgencyDtoIn item)
        {
            FormAgencyEntity formAgencyEntity;
            int id;

            formAgencyEntity = await AddFormAgencyAsync(item);
            id = await AddResponsiveAsync(item, formAgencyEntity);
            await SetDeviceToAgency(item);

            return id;
        }

        private async Task SetDeviceToAgency(FormAgencyDtoIn item)
        {
            const int Asignado = 2;

            foreach (var deviceId in item.ListDeviceIds)
            {
                DeviceEntity deviceEntity;

                deviceEntity = await _repository.Device.GetAsync(deviceId);
                deviceEntity.DeviceStateId = Asignado;
                
                await _repository.Device.UpdateAsync(deviceEntity);
            }
        }

        private async Task<int> AddResponsiveAsync(FormAgencyDtoIn item, FormAgencyEntity formAgencyEntity)
        {
            ResponsiveEntity entity;

            entity = new ResponsiveEntity
            {
                AgencyId = item.AgencyId,
                DateRegistration = DateTime.Now,
                DocumentId = formAgencyEntity.Id,
                IsActive = true
            };
            await _repository.Resposive.AddAsync(entity);

            return entity.Id;
        }

        private async Task<FormAgencyEntity> AddFormAgencyAsync(FormAgencyDtoIn item)
        {
            FormAgencyEntity formAgencyEntity;

            formAgencyEntity = _mapper.Map<FormAgencyEntity>(item);
            await SetListDeviceAsync(formAgencyEntity, item);
            await _repositoryMongoDb.FormAgency.AddAsync(formAgencyEntity);

            return formAgencyEntity;
        }

        private async Task SetListDeviceAsync(FormAgencyEntity entity, FormAgencyDtoIn item)
        {
            entity.ListDevices = new List<DeviceEntity>();
            foreach (var deviceId in item.ListDeviceIds)
            {
                DeviceEntity deviceEntity;

                deviceEntity = await _repository.Device.GetAsync(deviceId);

                entity.ListDevices.Add(deviceEntity);
            }
        }

        public Task<List<FormAgencyDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FormAgencyDto> GetAsync(string id)
        {
            FormAgencyDto item;
            FormAgencyEntity entity;

            entity = await _repositoryMongoDb.FormAgency.GetAsync(id);
            item = _mapper.Map<FormAgencyDto>(entity);
            await SetProjectName(item);
            await SetAgencyData(item);
            await SetDeviceStateAsync(item.ListDevices);

            return item; 
        }

        private async Task SetDeviceStateAsync(List<DeviceDto> listDevices)
        {
            List<DeviceStateEntity>  listDeviceStates;

            listDeviceStates = await _repository.DeviceState.GetAsync();
            foreach (var item in listDevices)
            {
                DeviceStateEntity deviceState;

                deviceState = listDeviceStates.Where(x=> x.Id == item.DeviceStateId).FirstOrDefault();
                item.DeviceStateName = deviceState.Name;
            }
        }

        private async Task SetAgencyData(FormAgencyDto item)
        {
            AgencyEntity agency;
            AgencyTypeEntity agencyType;

            agency = await _repository.Agency.GetAsync(item.AgencyId);
            item.AgencyName  = agency.Name;
            item.AgencyCode = agency.Code;
            item.AgencyAddress = $"{agency.Address} {agency.Settlement} {agency.State} {agency.ZipCode}";            
            agencyType = await _repository.AgencyType.GetAsync(agency.AgencyTypeId);
            item.AgencyTypeName = agencyType.Name;
        }

        private async Task SetProjectName(FormAgencyDto item)
        {
            ProjectEntity entity;

            entity = await _repository.Project.GetAsync(item.ProjectId);
            
            item.ProjectName = entity.Name;
        }
    }//end class
}