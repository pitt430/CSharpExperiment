using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace PatientData.Models
{
    public static class PatientDb
    {

        public static IMongoCollection<Patient> Open()
        {
            var client=new MongoClient("mongodb://localhost");
            var server = client.GetDatabase("PatientDb");
            return server.GetCollection<Patient>("Patients");
        } 
    }
}