// First Nuget: Newton, RestSharp

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace NsdWebApiUnitTestingTraining {
    [TestClass]
    public class UnitTests {
        RestClient client = new RestClient("https://jsonplaceholder.typicode.com"); // Sample REST
        //RestClient client = new RestClient("http://192.168.1.94:8088");

        [TestMethod]
        public void TestGet() {
            var request = new RestRequest("posts/1", Method.GET);
            JObject obj = JObject.Parse(client.Execute(request).Content);
            string result = obj["userId"].ToString();
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void TestPost() {
            var request = new RestRequest("posts", Method.POST);
            var data = new { title = "foo", body = "bar", userId = 1 };
            request.AddJsonBody(data);
            JObject obj = JObject.Parse(client.Execute(request).Content);
            string result = obj["id"].ToString();
            Assert.AreEqual("101", result);
        }
    }
}

