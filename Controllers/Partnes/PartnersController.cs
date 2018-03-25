using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCup2018.Models;
using WorldCup2018.Models.DataBase;

namespace WorldCup2018.Controllers
{
    [Route("partners")]
    public class PartnesController : Controller
    {
        private readonly WorldCup2018Context _context;

        public PartnesController(WorldCup2018Context context)
        {
            _context = context;
        }

        // GET all
        [HttpGet]
        public Dictionary<string, Partnes> Get()
        {
            List<Partnes> groupsPartners = (List<Partnes>)_context.Partnes.ToList();

            Dictionary<string, Partnes> dic = new Dictionary<string, Partnes>();

            for (int i = 0; i < groupsPartners.Count; i++)
            {
                dic.Add("local" + (i + 1), groupsPartners[i]);
            }

            return dic;
        }



        // GET matches by phases
        [HttpGet("{partnerId}")]
        public IEnumerable<Partnes> Get(int partnerId)
        {
            var partnes = (from p in _context.Partnes.ToList()
                           where p.Id == partnerId
                           select p).ToList();

            return partnes;
        }
    }
}