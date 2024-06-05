using Infrastructure.Data;
using Infrastructure.Entities;
using Newtonsoft.Json;
using NovaPoshtaAPIBleBla.Models.Area;
using NovaPoshtaAPIBleBla.Models.City;
using NovaPoshtaAPIBleBla.Models.PostOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
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
        private readonly string key = "1c104ca0cc43861c044c67c00e0f8072";

        public NovaPostService()
        {
            _httpClient = new HttpClient();
            _url = "https://api.novaposhta.ua/v2.0/json/";
            _dataContext = new NovaPoshDbContext();
            //_dataContext.Database.Migrate();
        }

        public void GetAreas()
        {
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

        public void getPostOffices()
        {
            PostOfficeRequestDTO request = new PostOfficeRequestDTO
            {
                ApiKey = key,
                ModelName = "AddressGeneral",
                CalledMethod = "getWarehouses",
                MethodProperties = new PostOfficeRequestPropertyDTO()
            };
            while (true)
            {
                string json = JsonConvert.SerializeObject(request);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<PostOfficeResponseDTO>(responseContent);
                    if (result.Data.Any())
                    {
                        foreach(var postOffice in result.Data)
                        {
                            var entity = _dataContext.tblPostOffices.SingleOrDefault(x => x.Ref == postOffice.Ref);
                            if(entity is null)
                            {
                                entity = new Entities.PostOfficeEntity
                                {
                                    Ref = postOffice.Ref,
                                    Description = postOffice.Description,
                                    CityDescription = postOffice.CityDescription,
                                    CategoryOfWarehouse = postOffice.CategoryOfWarehouse
                                };
                                _dataContext.tblPostOffices.Add(entity);
                                Console.WriteLine($"PostOffice description : {entity.Description}");
                            }
                        }
                        request.MethodProperties.Page++;
                    }
                    else
                    {
                        _dataContext.SaveChanges();
                        return;
                    }
                }
            }
        }



        public void ShowArea()
        {
            foreach( var entity in _dataContext.tblAreas)
            {
                Console.WriteLine(entity.Name, "    ", entity.Ref);
            }
        }

        public void ShowSettlements()
        {
            foreach (var entity in _dataContext.tblCities)
            {
                Console.WriteLine(entity.Description , "    ", entity.Ref);
            }
        }

        public void ShowPostOffices()
        {
            foreach (var entity in _dataContext.tblPostOffices)
            {
                Console.WriteLine(entity.Description, "    ", entity.CategoryOfWarehouse);
            }
        }

    }
}
