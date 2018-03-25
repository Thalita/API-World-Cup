using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCup2018.Models;

namespace WorldCup2018.Controllers
{
    [Route("teams")]
    public class TeamsController : Controller
    {
        private readonly WorldCup2018Context _context;

        public TeamsController(WorldCup2018Context context)
        {
            _context = context;
        }

        // GET all
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return _context.Team.ToList();
        }

        // GET team info by team name
        [HttpGet("{teamName}")]
        public Team Get(string teamName)
        {
            var team = (from t in _context.Team.ToList()
                        where t.Name.ToLower() == teamName.ToLower()
                        select t).FirstOrDefault();

            return team;
        }

        // GET teams players
        [HttpGet("{team}/players")]
        public IEnumerable<Player> GetPlayersByTeam(string team)
        {
            var players = (from p in _context.Player.ToList()
                           where p.Team.Name.ToLower() == team.ToLower()
                           select p).ToList();

            return players;
        }

        [HttpGet("group/{groupName}")]
        public Dictionary<string, Team> GetTeamsByGroup(string groupName)
        {

            List<Team> groupsTeams = (List<Team>)(from g in _context.Team.ToList()
                                                  where g.Group.ToLower() == groupName.ToLower()
                                                  select g).ToList();

            Dictionary<string, Team> dic = new Dictionary<string, Team>();

            for (int i = 0; i < groupsTeams.Count; i++)
            {
                dic.Add("team" + (i+ 1), groupsTeams[i]);
            }
            return dic;
        }
    }
}