using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace adatGyujtoX.Data
{
    class RestService
    {
        //HttpClient client;

        public RestService()
        {
            
         

            //var client2 = new RestSharp.Portable.HttpClient.RestClient("http://qnr.cognative.hu/cogsurv/");
            //var request2 = new RestSharp.Portable.RestRequest("regist_ios.php");
            

            //var response = client.Execute<RestApiModell>(request);
            //var result = response.Result;

            var alff2 = "leo";
        }

        public string name { get; internal set; }
        public string name2 { get; internal set; }
        public string code { get; internal set; }
        public string pass { get; internal set; }
        public string emil { get; internal set; }

        public RestApiModell ReggiFutAsync()
        {
            using (var client = new RestClient(new Uri("http://qnr.cognative.hu/cogsurv/regist_ios2.php")))
            {
                var request = new RestRequest("name /{ name }", RestSharp.Portable.Method.POST);
                //var request = new RestSharp.Portable.RestRequest();
                request.AddParameter("user_name", name);
                request.AddParameter("user_surname", name2);
                request.AddParameter("user_kod", code);
                request.AddParameter("user_password", pass);
                request.AddParameter("user_email", emil);
                var result =  client.Execute<RestApiModell>(request);
                RestApiModell vissza = result.Result.Data;
                return vissza;
            }
        }
    }
}
