using BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace priceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        ICostumerProductBl costumerproductbl;
        public TrackController(ICostumerProductBl costumerproductbl)
        {
            this.costumerproductbl = costumerproductbl;
        }
        // GET: api/<TrackController>
        [HttpGet]
        public int Get()
        {
            //System.Timers.Timer aTimer = new System.Timers.Timer(60 * 1000); //one hour in milliseconds
            // aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Start();
            // void OnTimedEvent(object source, ElapsedEventArgs e)
            //{
                costumerproductbl.trackprice();
            //}

            //TimerCallback callback = (x) =>
            //{
            //    costumerproductbl.trackprice();
            //};
            //int intervalInMS = 2 * 60 * 60 * 1000;  // every 2 hours. 
            //Timer timer = new Timer(callback, state: null, dueTime: intervalInMS, period: intervalInMS);
            return 1;


        }

        // GET api/<TrackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TrackController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TrackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
