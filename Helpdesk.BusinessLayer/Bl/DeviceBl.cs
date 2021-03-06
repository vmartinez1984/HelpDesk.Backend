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

        public async Task<DeviceListDto> GetAsync(DeviceSearchDtoIn deviceSearch)
        {
            DeviceListDto deviceListDto;
            List<DeviceEntity> listDeviceEntities;
            DeviceSearchEntity deviceSearchEntity;

            deviceSearchEntity = _mapper.Map<DeviceSearchEntity>(deviceSearch);
            listDeviceEntities = await _repository.Device.GetAsync(deviceSearchEntity);
            deviceListDto = _mapper.Map<DeviceListDto>(deviceSearchEntity);
            deviceListDto.ListDevices = _mapper.Map<List<DeviceDto>>(listDeviceEntities);
            await SetStateName(deviceListDto.ListDevices);

            return deviceListDto;
        }

        public async Task<DeviceDto> GetAsync(int id)
        {
            DeviceEntity entity;
            DeviceDto item;

            entity = await _repository.Device.GetAsync(id);
            item = _mapper.Map<DeviceDto>(entity);

            return item;
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