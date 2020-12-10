using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using globusHackthonBackendOpenSky.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace globusHackthonBackendOpenSky.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AircraftController : ControllerBase
    {
        // GET
        [HttpGet("{callsign}")]
        public IEnumerable<AircraftModel> Get(string callsign)
        {
            var data = Task.Run(async () => await new DbController().Get(callsign)).Result;
            return data;
        }
        
        // GET ALL
        [HttpGet]
        public IEnumerable<AircraftModel> GetAll()
        {
            var data = Task.Run(async () => await new DbController().GetAll()).Result;
            return data;
        }
        
        //Update
        [HttpPut("{CallSign}")]
        public void Update(string callsign,AircraftModel aircraftModel)
        {
            Console.WriteLine(callsign);
            Console.WriteLine(aircraftModel.CallSign);
            new DbController().Update(callsign,aircraftModel);
        }
        
        //Create
        [HttpPost()]
        public void Create(AircraftModel aircraftModel)
        {
            Console.WriteLine(aircraftModel.CallSign);
            new DbController().Create(aircraftModel);
        }
    }
}