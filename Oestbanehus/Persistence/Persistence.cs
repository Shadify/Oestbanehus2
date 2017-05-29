using Newtonsoft.Json.Linq;
using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Oestbanehus.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Oestbanehus.Persistence
{
    class Persistence
    {
        //ALL BUILDINGS
        public static async Task<ObservableCollection<Building>> getBuildingsAsync()
        {
            ObservableCollection<Building> allBuildings = new ObservableCollection<Building>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Buildings").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allBuildings = (ObservableCollection<Building>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<Building>));

                        var a = allBuildings;
                    }
                    return allBuildings;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        //ALL APARTMENTS
        public static async Task<ObservableCollection<Apartment>> getApartmentsAsync()
        {
            ObservableCollection<Apartment> allApartments = new ObservableCollection<Apartment>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Apartments").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allApartments = (ObservableCollection<Apartment>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<Apartment>));
                    }
                    return allApartments;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }



        //ALL APARTMENTS IN ONE BUILDING
        public static async Task<ObservableCollection<Apartment>> getApartmentsInBuilding(int buildingId)
        {
            ObservableCollection<Apartment> allApartments = new ObservableCollection<Apartment>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Apartments/{buildingId}/buildingAps").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allApartments = (ObservableCollection<Apartment>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<Apartment>));
                    }
                    return allApartments;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        //APTS WITH ALL DATA
        public static async Task<ApartmentDetails> getApartmentDetails(int aptId)
        {
            ObservableCollection<ApartmentDetails> allApartments = new ObservableCollection<ApartmentDetails>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Apartments/{aptId}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allApartments = (ObservableCollection<ApartmentDetails>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<ApartmentDetails>));
                    }
                    return allApartments[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }





        //GET CITY BY ZIP CODE
        public static async Task<City> GetCityByZip(int zipcode)
        {
            City cityObject = new City();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Cities/{zipcode}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        cityObject = JsonConvert.DeserializeObject(BuildingsData, typeof(City)) as City;
                    }
                    return cityObject;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //CONDITIONS OF ONE APARTMENT
        public static async Task<ObservableCollection<ConditionsOfItem>> getConditionsOfApartment(int aptId)
        {
            ObservableCollection<ConditionsOfItem> allConditions = new ObservableCollection<ConditionsOfItem>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/ConditionsOfItems/apartment/{aptId}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string ConditionsData = response.Content.ReadAsStringAsync().Result;

                        allConditions = (ObservableCollection<ConditionsOfItem>)JsonConvert.DeserializeObject(ConditionsData, typeof(ObservableCollection<ConditionsOfItem>));
                    }
                    return allConditions;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //REQUESTS OF ONE APARTMENT
        public static async Task<ObservableCollection<Request>> getRequestsOfApartment(int aptId)
        {
            ObservableCollection<Request> allRequests = new ObservableCollection<Request>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Requests/apartment/{aptId}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string RequestsData = response.Content.ReadAsStringAsync().Result;

                        allRequests = (ObservableCollection<Request>)JsonConvert.DeserializeObject(RequestsData, typeof(ObservableCollection<Request>));
                    }
                    return allRequests;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //GET ALL RESIDENTS
        public static async Task<ObservableCollection<Person>> getAllResidents()
        {
            ObservableCollection<Person> allResidents = new ObservableCollection<Person>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/People").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string ResidentsData = response.Content.ReadAsStringAsync().Result;

                        allResidents = (ObservableCollection<Person>)JsonConvert.DeserializeObject(ResidentsData, typeof(ObservableCollection<Person>));
                    }
                    return allResidents;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //GET DETAILED RESIDENT
        public static async Task<PersonWithDetails> getPersonWithDetails(int id)
        {
            ObservableCollection<PersonWithDetails> pwd = new ObservableCollection<PersonWithDetails>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/People/{id}/details").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        pwd = (ObservableCollection<PersonWithDetails>)JsonConvert.DeserializeObject(Data, typeof(ObservableCollection<PersonWithDetails>));
                    }
                    return pwd[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        
        //BUILDINGS WITH CONDITIONS
        public static async Task<ObservableCollection<BuildingConditions>> getBuildingsWithConditions()
        {
            ObservableCollection<BuildingConditions> bwc = new ObservableCollection<BuildingConditions>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Buildings/conditions").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        bwc = (ObservableCollection<BuildingConditions>)JsonConvert.DeserializeObject(Data, typeof(ObservableCollection<BuildingConditions>));
                    }
                    return bwc;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        //BUILDINGS WITH REQUESTS
        public static async Task<ObservableCollection<BuildingRequests>> getBuildingsWithRequests()
        {
            ObservableCollection<BuildingRequests> bwc = new ObservableCollection<BuildingRequests>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Requests/Buildings").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        bwc = (ObservableCollection<BuildingRequests>)JsonConvert.DeserializeObject(Data, typeof(ObservableCollection<BuildingRequests>));
                    }
                    return bwc;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //CREATE USER
        public static async Task<int> addPerson(Person person)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                try
                {
                    
                    var response = client.PostAsync($"api/People/add", content).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        return 0;
                    }
                    return 0;
                    
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        //LOGIN 
        public static async Task<Person> Login(Person person)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            Person per = new Person();

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                try
                {

                    var response = client.PostAsync($"api/People/login", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        per = (Person)JsonConvert.DeserializeObject(Data, typeof(Person));
                        return per;
                    }
                    return per;

                }
                catch (Exception ex)
                {
                    return per;
                }
            }
        }

        public static async Task<ConditionsOfItem> getConditionDetails(int id)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            ConditionsOfItem per = new ConditionsOfItem();

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {

                    var response = client.GetAsync($"api/ConditionsOfItems/{id}/comments").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        per = (ConditionsOfItem)JsonConvert.DeserializeObject(Data, typeof(ConditionsOfItem));
                        return per;
                    }
                    return per;

                }
                catch (Exception ex)
                {
                    var a = ex;
                    return per;
                }
            }
        }

        //Get condition types
        public static async Task<ObservableCollection<ConditionType>> getConditionTypesAsync()
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            ObservableCollection<ConditionType> per = new ObservableCollection<ConditionType>();

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/ConditionTypes").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        per = (ObservableCollection<ConditionType>)JsonConvert.DeserializeObject(Data, typeof(ConditionType));
                        return per;
                    }
                    return per;

                }
                catch (Exception ex)
                {
                    var a = ex;
                    return per;
                }
            }
        }

        public static async Task<Request> getRequestDetails(int id)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            Request per = new Request();

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {

                    var response = client.GetAsync($"api/Requests/{id}/details").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        per = (Request)JsonConvert.DeserializeObject(Data, typeof(Request));
                        return per;
                    }
                    return per;

                }
                catch (Exception ex)
                {
                    var a = ex;
                    return per;
                }
            }
        }

        //ADD COMMENT
        public static async Task<int> addComment(Comment comment)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
                try
                {

                    var response = client.PostAsync($"api/Comments", content).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        return 0;
                    }
                    return 0;

                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        //ADD CONDITION
        public static async Task<int> addCondition(ConditionsOfItem condition)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(condition), Encoding.UTF8, "application/json");
                try
                {

                    var response = client.PostAsync($"api/ConditionsOfItems", content).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        return 0;
                    }
                    return 0;

                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        //ADD REQUEST
        public static async Task<int> addRequest(Request req)
        {
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                try
                {

                    var response = client.PostAsync($"api/Requests", content).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        return 0;
                    }
                    return 0;

                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }
    }
}
