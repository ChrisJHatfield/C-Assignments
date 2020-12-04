using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.AllWomensLeagues = _context.Leagues.Where(w => w.Name.Contains("Women")).ToList();
            ViewBag.AllHockeyLeagues = _context.Leagues.Where(w => w.Sport.Contains("Hockey")).ToList();
            ViewBag.AllLeaguesNotFootball = _context.Leagues.Where(w => w.Sport != "Football").ToList();
            ViewBag.AllConferenceLeagues = _context.Leagues.Where(w => w.Name.Contains("Conference")).ToList();
            ViewBag.AllAtlanticLeagues = _context.Leagues.Where(w => w.Name.Contains("Atlantic")).ToList();
            ViewBag.DallasBasedTeams = _context.Teams.Where(w => w.Location.Contains("Dallas")).ToList();
            ViewBag.TeamsNamedRaptors = _context.Teams.Where(w => w.TeamName.Contains("Raptors")).ToList();
            ViewBag.TeamsWithCityInLocation = _context.Teams.Where(w => w.Location.Contains("City")).ToList();
            ViewBag.TeamsStartWithT = _context.Teams.Where(w => w.TeamName.Contains("T")).ToList();
            ViewBag.AlphabeticalByLocation = _context.Teams.Where( w => w.TeamName != "" ).OrderBy(w => w.Location).ToList();
            ViewBag.ReverseAlphabeticalByTeamName = _context.Teams.Where( w => w.TeamName != "").OrderByDescending(w => w.TeamName).ToList();
            ViewBag.PlayerLastNameCooper = _context.Players.Where( w => w.LastName.Contains("Cooper")).ToList();
            ViewBag.PlayerFirstNameJoshua = _context.Players.Where( w => w.FirstName.Contains("Joshua")).ToList();
            ViewBag.PlayerLastNameCooperNoJoshua = _context.Players.Where(w => w.LastName.Contains("Cooper") && w.FirstName != "Joshua").ToList();
            ViewBag.PlayersFirstNameAlexanderOrWyatt = _context.Players.Where( w => w.FirstName.Contains("Alexander") || w.FirstName.Contains("Wyatt")).OrderBy(w => w.FirstName).ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.AllTeamsAtlanticSoccer = _context.Teams
                .Include(t => t.CurrLeague)
                .Where(l => l.CurrLeague.Name == "Atlantic Soccer Conference").ToList();
            ViewBag.AllBostonPenguinsPlayers = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(t => t.CurrentTeam.TeamName == "Penguins").ToList();
            ViewBag.InternationCollegiatePlayers = _context.Players
                .Include(l => l.CurrentTeam)
                .Where(l => l.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference").ToList();
            ViewBag.AmericanConferenceFootballLopez = _context.Players
                .Include(l => l.CurrentTeam)
                .Where(l => l.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football")
                .Where(p => p.LastName == "Lopez").ToList();
            ViewBag.AllFootBallPlayers = _context.Players
                .Include(t => t.AllTeams)
                .Where(t => t.CurrentTeam.CurrLeague.Name.Contains("Football")).ToList();
            ViewBag.CurrentPlayerSophia = _context.Teams
                .Include(t => t.CurrentPlayers)
                .Where(p => p.CurrentPlayers.Any(p => p.FirstName == "Sophia")).ToList();
            ViewBag.LeaguePlayerSophia = _context.Leagues
                .Include(t => t.Teams)
                .Where(t => t.Teams.Any(p => p.CurrentPlayers.Any(p => p.FirstName == "Sophia"))).ToList();
            ViewBag.FloresNotWashingtonRoughRiders = _context.Players
                .Include(t => t.CurrentTeam)
                .Where(p => p.LastName == "Flores" && p.CurrentTeam.TeamName != "RoughRiders" && p.CurrentTeam.Location != "Washington").ToList();
            return View();
        }

        [HttpGet("level_3")]

        public IActionResult Level3()
        {

            ViewBag.SamuelEvansTeams = _context.Teams
                .Include(t => t.AllPlayers)
                .ThenInclude(p => p.PlayerOnTeam)
                .Where(p => p.CurrentPlayers.Any(p => p.FirstName == "Samuel" && p.LastName == "Evans"));
            ViewBag.ManitobaTigerCats = _context.Players
                .Include(t => t.AllTeams)
                .ThenInclude(t => t.TeamOfPlayer)
                .Where(t => t.CurrentTeam.TeamName == "Tiger-Cats" && t.CurrentTeam.Location == "Manitoba");
            ViewBag.FormerWichitaVikings = _context.Players
                .Include(t => t.AllTeams)
                .ThenInclude(t => t.TeamOfPlayer)
                .Where(t => t.CurrentTeam.TeamName == "Vikings" && t.CurrentTeam.Location == "Wichita");
            ViewBag.JacobGrayTeams = _context.Teams
                .Include(p => p.AllPlayers)
                .ThenInclude(p => p.TeamOfPlayer)
                .Where(p => p.TeamName != "Colts" && p.Location != "Oregon" && p.AllPlayers.Any(p => p.PlayerOnTeam.FirstName == "Jacob" && p.PlayerOnTeam.LastName == "Gray"));
            ViewBag.JoshuaOfAFABP = _context.Players
                .Include(l => l.CurrentTeam)
                .ThenInclude(l => l.CurrLeague)
                .Where(p => p.FirstName == "Joshua");
            ViewBag.TwelveOrMore = _context.Teams
                .Include(p => p.AllPlayers)
                .ThenInclude(p => p.TeamOfPlayer)
                .Where(p => p.AllPlayers.Count >= 12);
            ViewBag.PlayersSortedByTeam = _context.Players
                .Include(t => t.AllTeams)
                .ThenInclude(t => t.PlayerOnTeam)
                .Where(t => t.AllTeams.Count != 0).OrderBy(p => p.CurrentTeam);
                
            return View();
        }

    }
}