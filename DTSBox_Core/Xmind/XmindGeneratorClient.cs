using DTSBox_Core.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DTSBox_Core.Xmind
{
    public class XMindGeneratorClient
    {
        private const string RequestUriFormatString = "http://rtosappintern:23131/api/GetXMind/V2?filename={0}";
        private const string RequestUriFormatStringDev = "http://localhost:55699/api/GetXMind/V2?filename={0}";

        public async Task<byte[]> RequestXMindStream(List<RequestSheet> requestXMind, string fileName)
        {
            string requesturl = RequestUriFormatString;

            var json = JsonConvert.SerializeObject(requestXMind);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsync(String.Format(requesturl, fileName), stringContent);
                    var bytes = await response.Content.ReadAsByteArrayAsync();
                    //var stream = new MemoryStream(bytes);
                    return bytes;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //Log.Error(e, "Fehler beim Bereitstellen der XMind. Bitte erneut versuchen.");
            }

            return null;
        }
    }
}
