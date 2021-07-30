using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDTPDashboardDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IDTPServerController : ControllerBase
    {
        private static readonly string[] IDTPServers = new[]
        {
            "Database Server", "API Server 1", "API Server 2", "API Server 3", "Portal Server 1", "Portal Server 2"
        };

        private static readonly string[] IDTPRacks = new[]
        {
            "Rack 1", "Rack 2", "Rack 3"
        };


        private readonly ILogger<IDTPServerController> _logger;

        public IDTPServerController(ILogger<IDTPServerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<ServerHealthDetails> Post()
        {
            var rng = new Random();
            List<ServerHealthDetails> servers = new();

            for(int i=0;i<IDTPRacks.Count();i++)
            {
                  for(int j=0;j<IDTPServers.Count();j++)
                    {
                      servers.Add( new ServerHealthDetails
                        {
                            Date = DateTime.Now,
                            TemperatureC = 0,
                            ServerHeartbeat = true,                            
                            ServerName = IDTPServers[j],  
                            RackName = IDTPRacks[i],
                            ServerRackId=j,  
                            RackId = i,                            
                        });
                    }
            } 

            int index = rng.Next(servers.Count);           
            servers.ToArray()[index].ServerHeartbeat=false;
            
            return servers;
           
        }
    }
}
