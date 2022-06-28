using Helpdesk.Core.Entities;
using System.Net;
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
            await Task.Run(() =>
            {
                using (var webClient = new WebClient())
                {
                    string jsonString;

                    jsonString = webClient.DownloadString(zipCodeApi + zipCode);
                    list = JsonConvert.DeserializeObject<List<ZipCodeEntity>>(jsonString);
                }
            });

            return list;
        }
    }
}