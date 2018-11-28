using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace EveOnlineApp
{
    public class APIHelper
    {
        public async static Task<List<EveObjModel>> GetData(string region)
        {
            List<EveObjModel> importedList = new List<EveObjModel>();

            var http = new HttpClient();
            var url = String.Format($"https://esi.evetech.net/latest/markets/{region}/orders/?datasource=tranquility&order_type=all&page=1");
            var response = await http.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            importedList = (List<EveObjModel>)JsonConvert.DeserializeObject<List<EveObjModel>>(jsonString);

            return importedList;
        }
    }
}
