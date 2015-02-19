using DivitfaceSDK.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivitfaceSDK
{
    public class Service
    {
        static string key { get; set; }

        RestClient restClient = new RestClient("https://divit-divit-face-v1.p.mashape.com"); 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_key">Your Mashape Key for DivitFace API</param>
        public Service(string _key)
        {
            key = _key;
        }

        public void Initialize()
        {
            restClient.AddDefaultHeader("X-Mashape-Key", key);

        }


        #region Face

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Your API userId, You can get userId with using GetUser method</param>
        /// <param name="imagePath"> Path of image to analysis operation</param>
        /// <returns></returns>
        public List<Face> AnalysisByPath(string userId, string imagePath)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/analyze/?userId={0}", userId),
                            Method.POST);
            restRequest.AddFile("image", imagePath);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Face>>(restRequest).Content;
            List<Face> faceList = JsonConvert.DeserializeObject<List<Face>>(response);
            return faceList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Your API userId, You can get userId with using GetUser method</param>
        /// <param name="imageURL">Publicly accessible URL of image</param>
        /// <returns></returns>
        public List<Face> AnalysisByURL(string userId, string imageURL)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/analyze?imageURL={0}&userId={1}", imageURL,userId),
                            Method.GET); 
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Face>>(restRequest).Content;
            List<Face> faceList = JsonConvert.DeserializeObject<List<Face>>(response);
            return faceList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Your API userId, You can get userId with using GetUser method</param>
        /// <param name="imagePath">Path of image to analysis operation</param>
        /// <returns></returns>
        public List<Face> DetectByPath(string userId, string imagePath)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/detect/?userId={0}", userId),
                            Method.POST);
            restRequest.AddFile("image", imagePath);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Face>>(restRequest).Content;
            List<Face> faceList = JsonConvert.DeserializeObject<List<Face>>(response);
            return faceList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Your API userId, You can get userId with using GetUser method</param>
        /// <param name="imageURL">Publicly accessible URL of image</param>
        /// <returns></returns>
        public List<Face> DetectByURL(string userId, string imageURL)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/detect?imageURL={0}&userId={1}", imageURL, userId),
                            Method.GET);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Face>>(restRequest).Content;
            List<Face> faceList = JsonConvert.DeserializeObject<List<Face>>(response);
            return faceList;
        }


        public List<IdentificationResult> Identification(string userId, string facesetId, int threshold, string imagePath)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/Identification?faceset_id={0}&threshold={1}&userId={2}", facesetId, threshold, userId),
                            Method.POST);
            restRequest.AddFile("image", imagePath);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<IdentificationResult>>(restRequest).Content;
            List<IdentificationResult> faceList = JsonConvert.DeserializeObject<List<IdentificationResult>>(response);
            return faceList;
        }

        public List<SearchResult> Search(string userId, string facesetId, string imagePath, double threshold)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/Search?faceset_id={0}&userId={1}", facesetId, userId),
                            Method.POST);
            restRequest.AddFile("image", imagePath);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<SearchResult>>(restRequest).Content;
            List<SearchResult> faceList = JsonConvert.DeserializeObject<List<SearchResult>>(response);
            return faceList.Where(s=>(s.value *100 > threshold)).ToList();
        }

        public VerificationResult Verification(double threshold, string imagePath1, string imagePath2)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Face/Verification?threshold={0}", threshold),
                            Method.POST);
            restRequest.AddFile("image", imagePath1);
            restRequest.AddFile("image2", imagePath2);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<VerificationResult>(restRequest).Content;
            VerificationResult faceList = JsonConvert.DeserializeObject<VerificationResult>(response);
            return faceList;
        }
        #endregion

        #region Person
        public string CreatePerson(string name, string lastname)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/CreatePerson?lastname={0}&name={1}", lastname, name),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }
        public string DeletePerson(string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/DeletePerson?personid={0}", personId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }
        public Person GetPerson(string userId ,string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/GetPerson?userId={0}&personId={1}", userId,  personId),
                Method.GET);
            var response = restClient.Execute<Person>(restRequest).Content;
            Person person = JsonConvert.DeserializeObject<Person>(response);
            return person;
        }
        public List<Person> GetAllPerson(string userId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/GetAllPerson?userId={0}", userId),
                Method.GET);
            var response = restClient.Execute<Person>(restRequest).Content;
            List<Person> person = JsonConvert.DeserializeObject<List<Person>>(response);
            return person;
        }

        public string InsertFaceToPerson(string faceId, string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/InsertFace?faceId={0}&personId={1}", faceId,personId ),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string InsertInformationToPerson(string information, string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/InsertInformation?info={0}&personId={1}", information, personId),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }
        public string DeleteFaceFromPerson(string faceId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/DeleteFace?faceId={0}", faceId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }
        public string DeleteInformationFromPerson(string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/DeleteInformation?infoId={0}", personId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        #endregion

        #region Group 
        public string CreateGroup(string userId, string groupName)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/CreateGroup?user_id={0}&groupName={1}", userId, groupName),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string DeleteGroup(string groupId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/DeleteGroup?groupid={0}", groupId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string DeleteInformationFromGroup(string groupId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/DeleteInformation?groupid={0}", groupId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string DeletePersonFromGroup(string groupId, string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/DeletePerson?groupId={0}&personId={1}", groupId, personId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }


        public Group GetGroup(string groupId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/GetGroup?groupId={0}", groupId),
                Method.GET);
            var response = restClient.Execute<Group>(restRequest).Content;
            Group  group = JsonConvert.DeserializeObject<Group>(response);
            return group;
        }

        public List<Group> GetGroupList(string userId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/GetAllGroup?userId={0}", userId),
                Method.GET);
            var response = restClient.Execute<List<Group>>(restRequest).Content;
            List<Group> groups = JsonConvert.DeserializeObject<List<Group>>(response);
            return groups;
        }

        public List<Person> GetPersonsOfGroup(string groupId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/GetPersons?groupID={0}", groupId),
                Method.GET);
            var response = restClient.Execute<Person>(restRequest).Content;
            List<Person> person = JsonConvert.DeserializeObject<List<Person>>(response);
            return person;
        }

        public string InsertInformationToGroup(string information, string groupId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/InsertInformation?info={0}&groupId={1}", information, groupId),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string InsertPersonToGroup(string personId, string groupId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Group/InsertPerson?groupId={0}&personId={1}", groupId, personId),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        #endregion

        #region FaceSet
        public string CreateFaceset(string userId, string FacesetName)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/CreateFaceSet?facesetName={0}&user_id={1}", FacesetName, userId),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public FaceSet GetFaceset(string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/GetFaceSet?facesetid={0}", facesetId),
                Method.GET);
            var response = restClient.Execute<FaceSet>(restRequest).Content;
            FaceSet faceset = JsonConvert.DeserializeObject<FaceSet>(response);
            return faceset;
        }


        public string DeleteFaceFromFaceset(string faceId, string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/DeleteFaceFromFaceset?facesetid={0}&faceId={1}", facesetId, faceId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string DeleteFaceset(string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/DeleteFaceSet?facesetid={0}", facesetId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public string DeleteInformationFromFaceset(string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/DeleteInformation?facesetid={0}", facesetId),
                Method.DELETE);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public List<Face> GetFacesOfFaceset(string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/GetFaces?facesetId={0}", facesetId),
                Method.GET);
            var response = restClient.Execute<Face>(restRequest).Content;
            List<Face> faceList = JsonConvert.DeserializeObject<List<Face>>(response);
            return faceList;
        }

        public string InsertFaceToFaceset(string faceId, string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/InsertFace?facesetid={0}&faceid={1}", facesetId, faceId),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }


        public string InsertInformationToFaceset(string information, string facesetId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Faceset/InsertInformation?facesetid={0}&info={1}", facesetId, information),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        #endregion

        #region User

        public UserCreatedMessage CreateUser(string name, string lastname, string email, string password)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/User/adduser?name={0}&lastname={1}&email={2}&password={3}", name, lastname, email, password),
                Method.POST);
            var response = restClient.Execute<UserCreatedMessage>(restRequest).Content;
            UserCreatedMessage message = JsonConvert.DeserializeObject<UserCreatedMessage>(response);
            return message;
        }

        public string InsertPersonToUser(string userId, string personId)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/Person/InsertPerson?userId={0}&personId={1}", userId, personId),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }

        public User GetUser(string email)
        {
            RestRequest restRequest = new RestRequest(string.Format("api/User/getuser?email={0}", email),
                Method.GET);
            var response = restClient.Execute<User>(restRequest).Content;
            User user = JsonConvert.DeserializeObject<User>(response);
            return user;
        }

        public string CheckUser(string email, string password)
        {
           RestRequest restRequest = new RestRequest(string.Format("api/User/checkuser?email={0}&password={1}", email, password),
                Method.POST);
            var response = restClient.Execute(restRequest).Content;
            return response;
        }
        #endregion
    }
}
