using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCup2018.Models;
using WorldCup2018.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public dynamic Get()
        {
            var matches = (from m in _context.Match
                .Include(m => m.Phase)
                .Include(m2 => m2.Stadium)
                .Include(m3 => m3.TeamOne)
                .Include(m4 => m4.TeamTwo).ToList()
            select new
            {
                id = m.Id,
                phase = m.Phase.Name,
                teamOne = m.TeamOne,
                teamTwo = m.TeamTwo,
                date = m.Date.ToString(@"dd\/MM\/yyyy HH:mm")
            }).ToList();
            
            return matches;
        }

        // GET matches by teams
        [HttpGet("{team}")]
        public dynamic Get(string team)
        {
            var matches = (from m in _context.Match
                .Include(m => m.Phase)
                .Include(m2 => m2.Stadium)
                .Include(m3 => m3.TeamOne)
                .Include(m4 => m4.TeamTwo).ToList()
            where (m.TeamOne != null && m.TeamOne.Name == team) 
                    || (m.TeamTwo != null && m.TeamTwo.Name == team)
            select new
            {
                id = m.Id,
                phase = m.Phase.Name,
                teamOne = m.TeamOne,
                teamTwo = m.TeamTwo,
                date = m.Date.ToString(@"dd\/MM\/yyyy HH:mm")
            }).ToList();
            
            return matches;
        }

        // GET all phases
        [HttpGet("phases")]
        public IEnumerable<Phase> GetPhases()
        {
            return _context.Phase.ToList();
        }

        // GET matches by phases
        [HttpGet("phases/{phase}")]
        public dynamic Get(int phase)
        {
            var matches = (from m in _context.Match
                .Include(m => m.Phase)
                .Include(m2 => m2.Stadium)
                .Include(m3 => m3.TeamOne)
                .Include(m4 => m4.TeamTwo).ToList()
            where m.Phase.Id == phase
            select new
            {
                id = m.Id,
                phase = m.Phase.Name,
                teamOne = m.TeamOne,
                teamTwo = m.TeamTwo,
                date = m.Date.ToString(@"dd\/MM\/yyyy HH:mm")
            }).ToList();
            
            return matches;
        }
    }
}