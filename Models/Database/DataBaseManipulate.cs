using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using System.Web;
using Newtonsoft.Json;
using WorldCup2018.Models.DataBase;
using WorldCup2018.Models.Converters;


namespace WorldCup2018.Models.DataBase
{
    public static class DataBaseManipulate
    {
        private static WorldCup2018Context _context;
        public static void Populate(WorldCup2018Context context)
        {
            _context = context;
            PopulateTeam();
            PopulateMatches();
            PopulatePhases();
            PopulatePlayers();
            PopulateStadium();
            PopulatePartners();
        }
        public static void PopulateTeam()
        {
            string obj = Utils.ReadFile("json/teams.json");
            List<Team> teams = GenericConverter.ConverteJSonParaObject<List<Team>>(obj);

            foreach (Team t in teams)
            {
                _context.Team.Add(t);
                _context.SaveChanges();
            }
        }

        public static void PopulatePartners()
        {
            string obj = Utils.ReadFile("json/partners.json");
            List<Partnes> part = GenericConverter.ConverteJSonParaObject<List<Partnes>>(obj);

            foreach (Partnes t in part)
            {
                _context.Partnes.Add(t);
                _context.SaveChanges();
            }
        }

        public static List<Team> PopulateTeamList()
        {
            string obj = Utils.ReadFile("json/teams.json");
            List<Team> teams = GenericConverter.ConverteJSonParaObject<List<Team>>(obj);

            return teams;
        }

        public static void PopulateMatches()
        {
            string obj = Utils.ReadFile("json/matches.json");
            List<Match> matches = GenericConverter.ConverteJSonParaObject<List<Match>>(obj);

            foreach (Match m in matches)
            {
                _context.Match.Add(m);
                _context.SaveChanges();
            }
        }

        public static List<Match> PopulateMatchesList()
        {
            string obj = Utils.ReadFile("json/matches.json");
            List<Match> matches = GenericConverter.ConverteJSonParaObject<List<Match>>(obj);

            return matches;
        }


        public static void PopulatePlayers()
        {
            /* 
            string obj = Utils.ReadFile("json/players.json");
            List<Player> players = GenericConverter.ConverteJSonParaObject<List<Player>>(obj);

            foreach (Player p in players)
            {
                _context.Player.Add(p);
                _context.SaveChanges();
            }
            */
        }

        public static void PopulateStadium()
        {
            string obj = Utils.ReadFile("json/stadiums.json");
            List<Stadium> stadiums = GenericConverter.ConverteJSonParaObject<List<Stadium>>(obj);

            foreach (Stadium s in stadiums)
            {
                _context.Stadium.Add(s);
                _context.SaveChanges();
            }
        }

        public static List<Stadium> PopulateStadiumList()
        {
            string obj = Utils.ReadFile("json/stadiums.json");
            List<Stadium> stadiums = GenericConverter.ConverteJSonParaObject<List<Stadium>>(obj);

            return stadiums;
        }

        public static void PopulatePhases()
        {
            string obj = Utils.ReadFile("json/phases.json");
            List<Phase> phases = GenericConverter.ConverteJSonParaObject<List<Phase>>(obj);

            foreach (Phase ph in phases)
            {
                _context.Phase.Add(ph);
                _context.SaveChanges();
            }
        }


        public static List<Phase> PopulatePhasesList()
        {
            string obj = Utils.ReadFile("json/phases.json");
            List<Phase> phases = GenericConverter.ConverteJSonParaObject<List<Phase>>(obj);

            return phases;
        }

        public static Team GetTeamList(int id)
        {
            var team = (from t in PopulateTeamList()
                        where t.Id == id
                        select t).FirstOrDefault();

            return team;
        }

        public static Team GetTeam(int id)
        {
            var team = (from t in _context.Team.ToList()
                        where t.Id == id
                        select t).FirstOrDefault();

            return team;
        }

        public static Phase GetPhase(int id)
        {
            var phase = (from ph in _context.Phase.ToList()
                         where ph.Id == id
                         select ph).FirstOrDefault();

            return phase;
        }


        public static Phase GetPhaseList(int id)
        {
            var phase = (from ph in PopulatePhasesList()
                         where ph.Id == id
                         select ph).FirstOrDefault();

            return phase;
        }

        public static Stadium GetStadium(int id)
        {
            var stadium = (from st in _context.Stadium.ToList()
                           where st.Id == id
                           select st).FirstOrDefault();

            return stadium;
        }

        public static Stadium GetStadiumList(int id)
        {
            var stadium = (from st in PopulateStadiumList()
                           where st.Id == id
                           select st).FirstOrDefault();

            return stadium;
        }
    }

}
