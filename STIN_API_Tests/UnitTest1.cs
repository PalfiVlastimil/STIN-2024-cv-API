using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using STIN_cv_API.Controllers;
using STIN_cv_API.Services;

namespace STIN_API_Tests
{
    [TestClass]
    public class UnitTest1
    {
        PaymentController payment = new PaymentController();
        [TestMethod]
        public void TestHelloWorld()
        {
            var responds = payment.Hello() as ObjectResult;
            Assert.AreEqual(responds.Value, "Hello World");

        }
        [TestMethod]
        public void TestTime()
        {
            var response = payment.Time() as ObjectResult;
            Assert.AreEqual(DateTime.Now.ToString(), response.Value);
        }

        [TestMethod]
        public void TestTransformFromJsonToXML()
        {
            string wrongJson = "{\"Amount\":1000,\"Currency\":\"CZK\",\"Date\":\"2021-11-10\",\"PaymentType\":\"CASH\"";
            Assert.ThrowsException<JsonSerializationException>(() => PaymentTransformations.TransformPaymentFromString(wrongJson));
        }


        [TestMethod]
        public void TestProcessPayment1()
        {
            string json = File.ReadAllText("../../../TestData/test1.json"); //Univerzální øešení
            //string json = File.ReadAllText("D:/TUL/4_semestr/STIN/cviceni/projekt/stin-cv/Test/TestData/test1.json"); //Laptop
            //string json = File.ReadAllText("E:/+TUL/4_semestr/STIN/cviceni/stin-cv/Test/TestData/test1.json"); //Home
            var response = payment.ProcessPayment(json) as ObjectResult;
            Assert.AreEqual("999/EUR", response.Value);
        }
        [TestMethod]
        public void TestProcessPayment2()
        {
            string json = File.ReadAllText("../../../TestData/test2.json");
            var response = payment.ProcessPayment(json) as ObjectResult;
            string xmlOutput = "<Payment><Amount>1000</Amount><Currency>CZK</Currency><Date>2021-11-10</Date><PaymentType>CASH</PaymentType></Payment>";
            Assert.AreEqual(xmlOutput, response.Value);
            //does this work
        }

        [TestMethod]
        public void TestProcessPayment3()
        {
            string json = File.ReadAllText("../../../TestData/test3.json");
            var response = payment.ProcessPayment(json) as ObjectResult;
            Assert.AreEqual(500, response.StatusCode);
        }
    }
}