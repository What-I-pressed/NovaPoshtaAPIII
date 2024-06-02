using Infrastructure.Data;
using Infrastructure.Entities;
using Newtonsoft.Json;
using NovaPoshtaAPIBleBla.Models.Area;
using NovaPoshtaAPIBleBla.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NovaPoshtaAPIBleBla
{
    public class NovaPostService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly NovaPoshDbContext _dataContext;

        public NovaPostService()
        {
            _httpClient = new HttpClient();
            _url = "https://api.novaposhta.ua/v2.0/json/";
            _dataContext = new NovaPoshDbContext();
            //_dataContext.Database.Migrate();
        }

        public void GetAreas()
        {
            string key = "917287e88b0a212026f65478f71ffcdb";

            AreaRequestDTO areaRequestDTO = new AreaRequestDTO
            {
                ApiKey = key,
                ModelName = "Address",
                CalledMethod = "getSettlementAreas",
                MethodProperties = new AreaRequesPropertyDTO
                {
                    Ref = "",
                    Page = 1
                }
            };

            string json = JsonConvert.SerializeObject(areaRequestDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<AreaResponseDTO>(responseData);
                if (result.Data.Any())
                {
                    foreach (var area in result.Data)
                    {
                        var entity = _dataContext.tblAreas.SingleOrDefault(x => x.Ref == area.Ref);
                        if (entity is null)
                        {
                            entity = new AreaEntity
                            {
                                Name = area.Description,
                                Ref = area.Ref
                            };
                            _dataContext.tblAreas.Add(entity);
                            _dataContext.SaveChanges();
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine($"Помилка запиту: {response.StatusCode}");
            }
        }

        public void GetSettlements()
        {
            string key = "917287e88b0a212026f65478f71ffcdb";
            int page = 1;
            while (true)
            {
                SettlementRequestDTO areaRequestDTO = new SettlementRequestDTO
                {
                    ApiKey = key,
                    ModelName = "AddressGeneral",
                    CalledMethod = "getSettlements",
                    MethodProperties = new SettlementRequestPropertyDTO
                    {
                        Page = page
                    }
                };

                string json = JsonConvert.SerializeObject(areaRequestDTO);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<SettlementResponseDTO>(responseData);
                    if (result.Data.Any())
                    {   
                        foreach (var settlement in result.Data)
                        {
                            var entity = _dataContext.tblCities.SingleOrDefault(x => x.Ref == settlement.Ref);
                            if (entity is null)
                            {
                                Console.WriteLine("{0} {1}", page, settlement.Description);
                                entity = new CityEntity
                                {
                                    Description = settlement.Description,
                                    Ref = settlement.Ref,
                                    AreaId = _dataContext.tblAreas.Where(x => x.Ref == settlement.Area).Select(x => x.Id).SingleOrDefault()

                                };
                                _dataContext.tblCities.Add(entity);
                            }
                        }
                        _dataContext.SaveChanges();
                        page++;
                    }
                    else
                        return;
                }
                else
                {
                    Console.WriteLine($"Помилка запиту: {response.StatusCode}");
                }
            }

        }
    }
}
