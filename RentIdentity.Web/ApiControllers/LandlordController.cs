using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.Cors;
using RentIdentity.Data.Entities;
using RentIdentity.DAL.Repositories;
using RentIdentity.DAL;
using RentIdentity.Data;
using System;

namespace RentIdentity.Web.ApiControllers
{

    [EnableCors(origins: "http://192.168.1.134", headers: "*", methods: "*")]
    public class LandlordController : ApiController
    {
        readonly LandlordRepository _repo;

        public LandlordController()
        {
            _repo = new LandlordRepository(new RentIdentityDb());
        }

        public LandlordController(LandlordRepository repo)
        {
            _repo = repo;
        }

        /// GET api/Landlords
        [System.Web.Http.Route("api/Landlords")]
        public HttpResponseMessage Get()
        {

            Request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            using (var unitOfWork = new UnitOfWork(new RentIdentityDb()))
            {
                var landlords = unitOfWork.Landlords.GetAll();
                // Write the list to the response body.
                response = Request.CreateResponse(HttpStatusCode.OK, landlords);
                
            }
            response.Headers.Add("Accept", "application/json");
            return response;
        }

        // GET api/Landlord/Id
        [System.Web.Http.Route("api/Landlords/{id}")]
        public HttpResponseMessage Get(int id) // Landlords
        {
            Request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            using (var unitOfWork = new UnitOfWork(new RentIdentityDb()))
            {
                IEnumerable<Landlord> landlords = unitOfWork.Landlords.GetLandlordsById(id);
                // Write the list to the response body.
                response =  Request.CreateResponse(HttpStatusCode.OK, landlords);
                
            }
            response.Headers.Add("Accept", "application/json");
            return response;

        }

        // POST api/Landlord/Id
        [System.Web.Http.Route("api/Landlords/Add")]
        public HttpResponseMessage PostAddLandlord([FromBody]Landlord landlord)
        {
            Request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            using (var unitOfWork = new UnitOfWork(new RentIdentityDb()))
            {
                unitOfWork.Landlords.Add(landlord);
                // Write the list to the response body.
                response = Request.CreateResponse(HttpStatusCode.Created, landlord);
                string uri = Url.Link("DefaultApi", new { id = landlord.Id });
                response.Headers.Location = new Uri(uri);

            }
            response.Headers.Add("Accept", "application/json");
            return response;

        }
    }  
}