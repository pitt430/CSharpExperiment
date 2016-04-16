using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;

namespace PatientData.Controllers
{
    [EnableCors("*","*","GET")]
    [Authorize]
    public class PatientsController : ApiController
    {
        private IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }
        public IEnumerable<Patient> Get()
        {
            return _patients.Find(_=>true).ToList();
        }

        public HttpResponseMessage Get(string id )
        {
            var patient = _patients.Find(a => a.Id == id);
            if (patient == null)
            {
               return  Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldn't find the patient");
            }
            else
            {
               return  Request.CreateResponse(patient.SingleOrDefault());
            }

        }

        [Route("GetAR/{id}")]
        public IHttpActionResult GetByActionResult(string id)
        {
            var patient = _patients.Find(a => a.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patient.SingleOrDefault());
            }

        }

        [Route("api/patients/{id}/medications")]
        public HttpResponseMessage GetMedications(string id)
        {
            var patient = _patients.Find(a => a.Id == id);
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldn't find the patient");
            }
            else
            {
                return Request.CreateResponse(patient.SingleOrDefault().Medications);
            }

        }
    }
}
