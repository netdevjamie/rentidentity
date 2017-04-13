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


namespace RentIdentity.Web.ApiControllers
{
    public static class ApiControllerHelpers
    {
        public static void BuildApiEntities(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<RentalUnitRepository>("RentalUnits"); // RentalUnits
        }

    }

    [EnableCors(origins: "http://192.168.1.134", headers: "*", methods: "*")]
    public class RentalUnitController : ApiController
    {
        readonly RentalUnitRepository _repo;

        public RentalUnitController()
        {
            _repo = new RentalUnitRepository(new RentIdentityDb());
        }


        public RentalUnitController(RentalUnitRepository repo)
        {
            _repo = repo;
        }

        /// GET api/RentalUnits
        [System.Web.Http.Route("api/RentalUnits")]
        public HttpResponseMessage Get()
        {
            Request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            using (var unitOfWork = new UnitOfWork(new RentIdentityDb()))
            {
                var rentalUnits = unitOfWork.RentalUnits.GetAll();
                // Write the list to the response body.
                response = Request.CreateResponse(HttpStatusCode.OK, rentalUnits);
            }
            response.Headers.Add("Accept", "application/json");
            return response;
        }

        // GET api/RentalUnit/Id
        [System.Web.Http.Route("api/RentalUnit/{id}")]
        public HttpResponseMessage Get(int id)
        {
            Request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            using (var unitOfWork = new UnitOfWork(new RentIdentityDb()))
            {
                var rentalUnits = unitOfWork.RentalUnits.GetRentalUnitById(id);
                Request.Headers.Add("Accept", "application/json");
                // Write the list to the response body.
                response = Request.CreateResponse(HttpStatusCode.OK, rentalUnits);
            }
            response.Headers.Add("Accept", "application/json");
            return response;
        }

        // GET api/RentalUnits/isAvailable/<true/false>
        [System.Web.Http.Route("api/RentalUnits/IsAvailable/{isAvailable}")]
        public HttpResponseMessage Get(bool isAvailable)
        {
            Request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            using (var unitOfWork = new UnitOfWork(new RentIdentityDb()))
            {
                var rentalUnits = unitOfWork.RentalUnits.GetUnitsByAvailability(isAvailable);
                Request.Headers.Add("Accept", "application/json");
                // Write the list to the response body.
                response = Request.CreateResponse(HttpStatusCode.OK, rentalUnits);
            }
            response.Headers.Add("Accept", "application/json");
            return response;
        }


    }


}