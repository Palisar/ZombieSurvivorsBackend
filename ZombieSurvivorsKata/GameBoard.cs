using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace ZombieSurvivorsKata
{
    public class GameBoard
    {
        private readonly GameLog _log;

        public GameBoard(GameLog log)
        {
            _log = log;
            Survivors = new List<Survivor>();
            SurvivorsSpawned = false;
            GameOverFlag = false;
            Level = Level.Blue;
        }
        public Level Level { get; set; }
        public List<Survivor> Survivors { get; set; }
        public bool SurvivorsSpawned { get; set; }
        public bool GameOverFlag { get; set; }

        public Survivor AddSurvivor(string name)
        {
            var survivor = Survivors.FirstOrDefault(s => s.Name == name);
            if (survivor is null)
            {
                Survivors.Add(new Survivor(name, _log));
                if (!SurvivorsSpawned)
                    _log.Message($"Game has begun at {DateTime.Now}!");

                _log.Message($"{name} has joined the game.");
            }

            SurvivorsSpawned = true;
            
            return Survivors.Last();
        }

        public void RemoveSurvivor(Survivor survivor)
        {
            Survivors.Remove(survivor);
            GameOverFlag = IsGameOver();
            if (GameOverFlag)
            {
                _log.Message("Everyone has died.....\n\nGame Over");
            }
        }

        public bool IsGameOver()
        {
            return SurvivorsSpawned && Survivors.Count < 1;
        }

        public void CheckSurvivorsLevel()
        {
            foreach (var survivor in Survivors)
            {
                if (survivor.Level > Level)
                {
                    Level = survivor.Level;
                    _log.Message($"Game has now advanced to level {Level}!");
                }
            }
        }

    }
}
