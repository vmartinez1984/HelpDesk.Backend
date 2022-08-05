using Helpdesk.Core.Entities;
using Newtonsoft.Json;
using Helpdesk.Core.Interfaces.IServices;

namespace Helpdesk.Services.ZipCodes
{
    public class ZipCodeService : IZipCodeService
    {
        const string zipCodeApi = "https://vmartinez.herokuapp.com/api/codigosPostales/";

        public async Task<List<ZipCodeEntity>> GetAsync(string zipCode)
        {
            List<ZipCodeEntity> list;

            list = new List<ZipCodeEntity>();
            await Task.Run(async () =>
            {
                using (var webClient = new HttpClient())
                {
                    string jsonString;

                    jsonString = await webClient.GetStringAsync(zipCodeApi + zipCode);
                    list = JsonConvert.DeserializeObject<List<ZipCodeEntity>>(jsonString);
                }
            });

            return list;
        }
    }
}