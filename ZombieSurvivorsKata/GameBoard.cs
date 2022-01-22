﻿using System;
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
        public GameBoard()
        {
            Survivors = new List<Survivor>();
            SurvivorsSpawned = false;
        }

        public List<Survivor> Survivors { get; set; }
        public bool SurvivorsSpawned { get; set; }
        public bool GameOverFlag { get; set; }

        public Survivor AddSurvivor(string name)
        {
            var survivor = Survivors.Select(s => s.Name == name);
            if (survivor is null)
            {
                Survivors.Add(new Survivor(name));
            }

            SurvivorsSpawned = true;

            return Survivors.Last();
        }

        public void RemoveSurvivor(Survivor survivor)
        {
            Survivors.Remove(survivor);
            GameOverFlag = IsGameOver();
        }

        public bool IsGameOver()
        {
            return SurvivorsSpawned && Survivors.Count < 1;
        }


    }
}