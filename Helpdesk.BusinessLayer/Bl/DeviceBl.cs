using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class DeviceBl : IDeviceBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public DeviceBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(DeviceDtoIn item)
        {
            DeviceEntity entity;

            entity = _mapper.Map<DeviceEntity>(item);
            await _repository.Device.AddAsync(entity);

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagerDtoOut> GetAsync(SearchDtoIn search)
        {
            PagerDtoOut response;
            PagerEntity pagerEntity;
            List<DeviceEntity> entities;

            pagerEntity = _mapper.Map<PagerEntity>(search);
            entities = await _repository.Device.GetAsync(pagerEntity);
            response = new PagerDtoOut
            {
                List = _mapper.Map<List<DeviceDto>>(entities),
                PageCurrent = pagerEntity.PageCurrent,
                RecordsPerPage = pagerEntity.RecordsPerPage,
                TotalRecords = pagerEntity.TotalRecords,
                TotalRecordsFiltered = pagerEntity.TotalRecordsFiltered
            };

            return response;
        }

        public async Task<DeviceDto> GetAsync(int id)
        {
            DeviceEntity entity;
            DeviceDto item;

            entity = await _repository.Device.GetAsync(id);
            item = _mapper.Map<DeviceDto>(entity);
            item.DeviceStateName = await _repository.DeviceState.GetDeviceStateNameAsync(item.DeviceStateId);

            return item;
        }

        public async Task UpdateAsync(DeviceDtoIn item, int id)
        {
            DeviceEntity entity;

            entity = await _repository.Device.GetAsync(id);
            entity.Name = item.Name;
            entity.SerialNumber = item.SerialNumber;
            entity.DateStart = item.DateStart;
            entity.DateEnd = item.DateEnd;
            entity.DeviceStateId = item.DeviceStateId;
            entity.Notes = item.Notes;

            await _repository.Device.UpdateAsync(entity);
        }

        private async Task SetStateName(List<DeviceDto> listDevices)
        {   
            List<DeviceStateEntity>  states;

            states = await _repository.DeviceState.GetAsync();

            foreach (var item in listDevices)
            {
                DeviceStateEntity stateEntity;

                stateEntity = states.Where(x=> x.Id == item.DeviceStateId).First();

                item.DeviceStateName = stateEntity.Name;
            }
        }

    }//end class
}