using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sap_soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public async Task<ViewModelResponse> ExistUser(string email)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://ec2-3-218-84-176.compute-1.amazonaws.com:5000/graphql")
            };


            var queryObject = new
            {
                query = @"query ExistUserQuery($email: String!) {
                    ExistUser(email: $email){ 
                        response, error, user{id,name,lastName,picture,email,userName,country}
                    }
                }",
                variables = new { email }
            };

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(queryObject), Encoding.UTF8, "application/json")
            };

            dynamic responseObj;

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                responseObj = JsonConvert.DeserializeObject<dynamic>(responseString);
            }

            var responseAns = responseObj.data.ExistUser.response; // response
            var error = responseObj.data.ExistUser.error; // response
            var user = responseObj.data.ExistUser.user; // response

            var id = user.id;
            var name = user.name;
            var lastname = user.lastName;
            var picture = user.picture;
            var emailI = user.email;
            var country = user.country;
            var username = user.userName;

            ViewModelResponse ans = new ViewModelResponse
            {
                Error = error,
                Response = responseAns,
                User = new ViewModelUser { Id = id, Name = name, LastName = lastname, Picture = picture, Email = emailI, Country = country, UserName = username }
            };

            return ans;
        }
    }

}
