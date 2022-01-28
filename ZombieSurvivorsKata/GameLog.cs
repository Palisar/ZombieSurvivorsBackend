using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ZombieSurvivorsKata.Interfaces;

namespace ZombieSurvivorsKata
{
    public class GameLog : IGamelog
    {
        public void Message(string message)
        {
            Debug.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
