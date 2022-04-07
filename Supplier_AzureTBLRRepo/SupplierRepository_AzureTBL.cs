using Newtonsoft.Json;
using RestSharp;
using Supplier_AzureTBLRModel.Entities;
using Supplier_AzureTBLRModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_AzureTBLRRepo
{
    public class SupplierRepository_AzureTBL
    {
        public async Task<Supplier> AddSupplier(SupplierAddVM model)
        {


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://addsupplierfuncazuretbl20220224162141.azurewebsites.net/");
                var response = await client.PostAsync("api/AddSupplier", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var st = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    if (responseModel.Success)
                    {
                        return
                        //(Supplier)responseModel.Data;
                        JsonConvert.DeserializeObject<Supplier>(responseModel.Data.ToString());
                    }
                    throw new Exception((string)responseModel.Data);
                }

                throw new Exception($"Exception from function. Status Code:{response.StatusCode}. Content : {response.Content}");
            }


            //var client = new RestClient("http://localhost:7071/api/AddSupplier");

            //var request = new RestRequest();
            //request.AddHeader("Content-Type", "application/json");
            //var body = JsonConvert.SerializeObject(model);
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //var response = await client.PostAsync(request);


        }

        public async Task<List<Supplier>> GetSupplierList()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://getsupplierfuncazuretbl20220224161809.azurewebsites.net/");
                var response = await client.GetAsync("api/GetSupplierList?");
                if (response.IsSuccessStatusCode)
                {
                    var st = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    if (responseModel.Success)
                    {
                        return
                        //(Supplier)responseModel.Data;
                        JsonConvert.DeserializeObject<List<Supplier>>(responseModel.Data.ToString());
                    }
                    throw new Exception((string)responseModel.Data);
                }

                throw new Exception($"Exception from function. Status Code:{response.StatusCode}. Content : {response.Content}");
            }
        }
        public async Task<Supplier> GetSupplier(string id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://getsupplierbyidfuncazuretbl20220224162225.azurewebsites.net/");

                var response = await client.GetAsync("api/GetSupplier?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var st = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    if (responseModel.Success)
                    {
                        return
                        //(Supplier)responseModel.Data;
                        JsonConvert.DeserializeObject<Supplier>(responseModel.Data.ToString());
                    }
                    throw new Exception((string)responseModel.Data);
                }

                throw new Exception($"Exception from function. Status Code:{response.StatusCode}. Content : {response.Content}");
            }
        }

        public async Task DeleteSupplier(string id) 
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://deletesupplierfuncazuretbl20220224171123.azurewebsites.net/");

                var response = await client.GetAsync("api/DeleteSupplier?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var st = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    if (responseModel.Success)
                    {
                        return;
                    }
                    throw new Exception((string)responseModel.Data);
                }

                throw new Exception($"Exception from function. Status Code:{response.StatusCode}. Content : {response.Content}");
            }
        }


        public async Task<Supplier> EditSupplier(SupplierEditVM model)
        {


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://updatesupplierfuncazuretbl20220224175016.azurewebsites.net/");
                var response = await client.PostAsync("api/EditSupplier?", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var st = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    if (responseModel.Success)
                    {
                        return
                        //(Supplier)responseModel.Data;
                        JsonConvert.DeserializeObject<Supplier>(responseModel.Data.ToString());
                    }
                    throw new Exception((string)responseModel.Data);
                }

                throw new Exception($"Exception from function. Status Code:{response.StatusCode}. Content : {response.Content}");
            }
        }

    }
}
