using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCup2018.Models;
using WorldCup2018.Models.DataBase;

namespace WorldCup2018.Controllers
{
    [Route("matches")]
    public class MatchesController : Controller
    {
        private readonly WorldCup2018Context _context;

        public MatchesController(WorldCup2018Context context)
        {
            _context = context;
        }

        // GET all
        [HttpGet]
        public IEnumerable<Match> Get()
        {
            return _context.Match.ToList();
        }

        // GET matches by teams
        [HttpGet("{team}")]
        public IEnumerable<Match> Get(string team)
        {

            var matches = (from m in _context.Match.ToList()
                           where m.TeamOne.Name == team || m.TeamTwo.Name == team
                           select m).ToList();

            return matches;
        }

        // GET matches by phases
        [HttpGet("phases/{phase}")]
        public IEnumerable<Match> Get(int phase)
        {
            var matches = (from m in _context.Match.ToList()
                           where m.Phase.Id == phase
                           select m).ToList();

            return matches;
        }
    }
}