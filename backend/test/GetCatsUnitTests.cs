using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading;
using System.Collections.Generic;
using backend.Models;
using System.Linq;

namespace test
{
    [TestClass]
    public class GetCatsUnitTests
    {

        private HttpClient GetClient<T>(T data)
        {
            var handler = new Mock<HttpMessageHandler>();

            handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
                ).ReturnsAsync((HttpRequestMessage request, CancellationToken token) =>
                {
                    HttpResponseMessage response = new HttpResponseMessage();

                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data));
                    return response;
                });

            return new HttpClient(handler.Object);
        }

        [TestMethod]
        public async Task GetOneOwnerWithACat()
        {
            backend.Models.Pet pet = new backend.Models.Pet()
            {
                name = "Taffy",
                type = "Cat"
            };
            backend.Models.Owner owner = new backend.Models.Owner()
            {
                age = 50,
                name = "Michael",
                gender = "Male",
                pets = new System.Collections.Generic.List<backend.Models.Pet>() { pet }
            };
            List<Owner> oneOwnerWithACat = new List<Owner>() { owner };

            var client = GetClient<List<Owner>>(oneOwnerWithACat);

            backend.SensorService service = new backend.SensorService(client);
            var owners = await service.GetCats();

            Assert.AreEqual(1, owners.Count());
            Assert.IsFalse(owners.ToList()[0].pets.Any(p => p.type != "Cat"));
        }

        [TestMethod]
        public async Task GetMultipleOwnersWithACat()
        {
            Pet pet = new Pet()
            {
                name = "Taffy",
                type = "Cat"
            };
            Owner owner = new Owner()
            {
                age = 50,
                name = "Michael",
                gender = "Male",
                pets = new System.Collections.Generic.List<backend.Models.Pet>() { pet }
            };
            Owner owner2 = new Owner()
            {
                age = 50,
                name = "Vivien Pine",
                gender = "Female",
                pets = owner.pets
            };
            List<Owner> oneOwnerWithACat = new List<Owner>() { owner, owner2 };

            var client = GetClient<List<Owner>>(oneOwnerWithACat);

            backend.SensorService service = new backend.SensorService(client);
            var owners = await service.GetCats();

            Assert.AreEqual(2, owners.Count());
            Assert.IsFalse(owners.ToList()[0].pets.Any(p => p.type != "Cat"));
        }

        [TestMethod]
        public async Task GetOwnerWithNullPets()
        {
            Owner owner = new Owner()
            {
                age = 50,
                name = "Michael",
                gender = "Male",
                pets = null
            };
            List<Owner> oneOwnerWithACat = new List<Owner>() { owner };

            var client = GetClient<List<Owner>>(oneOwnerWithACat);

            backend.SensorService service = new backend.SensorService(client);
            var owners = await service.GetCats();

            Assert.AreEqual(0, owners.Count());

        }

        [TestMethod]
        public async Task GetOwnerWithoutACat()
        {
            Pet pet = new Pet()
            {
                name = "Pluto",
                type = "Dog"
            };
            Owner owner = new Owner()
            {
                age = 50,
                name = "Michael",
                gender = "Male",
                pets = new System.Collections.Generic.List<backend.Models.Pet>() { pet }
            };
            List<Owner> oneOwnerWithACat = new List<Owner>() { owner };

            var client = GetClient<List<Owner>>(oneOwnerWithACat);

            backend.SensorService service = new backend.SensorService(client);
            var owners = await service.GetCats();

            Assert.AreEqual(0, owners.Count());

        }

        [TestMethod]
        public void AddTwoIntegers()
        {

            var client = GetClient<int>(1);

            backend.SensorService service = new backend.SensorService(client);
            
            var result = service.AddUsingC(23, 78);

            Assert.AreEqual(23 + 78, result);
        }
    }
}
