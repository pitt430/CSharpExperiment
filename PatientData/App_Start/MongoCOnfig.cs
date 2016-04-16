using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using PatientData.Models;

namespace PatientData.App_Start
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();
            if (!patients.AsQueryable().Any(p => p.Name == "Scott"))
            {
                var data = new List<Patient>()
                {
                    new Patient
                    {
                        Name = "Scott",
                        Ailments = new List<Ailment>() {new Ailment() {Name = "Crazy"}},
                        Medications = new List<Medication>() {new Medication() {Name = "test", Doses = 12}}
                    },
                    new Patient
                    {
                        Name = "Joy",
                        Ailments = new List<Ailment>() {new Ailment() {Name = "Crazy2"}},
                        Medications = new List<Medication>() {new Medication() {Name = "test2", Doses = 13}}
                    },
                    new Patient
                    {
                        Name = "Sarah",
                        Ailments = new List<Ailment>() {new Ailment() {Name = "Crazy3"}},
                        Medications = new List<Medication>() {new Medication() {Name = "test3", Doses = 14}}
                    }
                };
                patients.InsertMany(data);
            }
        }

    }
}