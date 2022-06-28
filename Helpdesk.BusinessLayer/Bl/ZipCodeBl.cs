using AutoMapper;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.Core.Interfaces.IServices;

namespace Helpdesk.BusinessLayer.Bl
{
    public class ZipCodeBl : IZipCodeBl
    {
        private IZipCodeService _zipCodeService;
        private IMapper _mapper;

        public ZipCodeBl(IRepository repository, IMapper mapper,IZipCodeService zipCodeService)
        {
            _zipCodeService = zipCodeService;
            _mapper = mapper;
        }

        public async Task<List<ZipCodeDto>> GetAsync(string zipCode)
        {
            List<ZipCodeDto> list;
            List<ZipCodeEntity> entities;

            entities = await _zipCodeService.GetAsync(zipCode);
            list = _mapper.Map<List<ZipCodeDto>>(entities);

            return list;
        }
    }//end class
}