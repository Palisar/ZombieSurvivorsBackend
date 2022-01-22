﻿using Microsoft.VisualBasic;

namespace ZombieSurvivorsKata
{
    public class Survivor : Human
    {
        public Survivor(string name) : base(name)
        {
            State = State.Alive;
            ActionCount = 3;
            ActionsPerTurn = 3;
            InReserve = new List<Equipment>();
            ItemCapacity = 3;
        }

        public sealed override State State { get; set; }
        public int ActionsPerTurn { get; }
        public int ActionCount { get; set; }

        public Equipment? ActiveHand { get; set; }
        public Equipment? OffHand { get; set; }
        public List<Equipment> InReserve { get; set; }
        public int ItemCapacity { get; set; }
        public bool WoundedThisRound { get; set; }

        public void GotWounded()
        {
            if (this.Wounds < 2)
            {
                Wounds++;
                ItemCapacity--;
                WoundedThisRound = true;
            }
            if (this.Wounds == 2)
            {
                State = State.Dead;
            }
        }
        
        public void UseAction()
        {
            //TODO : Implement later on
            if (ActionCount > 0)
            {
                ActionCount--;
            }
        }

        public void EquipItem(int hand)
        {

        }
        public void PickUpItem(Equipment equipment)
        {
            if (ActiveHand is null)
            {
                if (OffHand == equipment)
                {
                    OffHand = null;
                }
                if (InReserve.Contains(equipment))
                {
                    InReserve.Remove(equipment);
                }
                ActiveHand = equipment;
            }
            else if (OffHand is null)
            {
                if (ActiveHand == equipment)
                {
                    ActiveHand = null;
                }
                if (InReserve.Contains(equipment))
                {
                    InReserve.Remove(equipment);
                }
                OffHand = equipment;
            }
            else if (InReserve.Count < ItemCapacity)
            {
                InReserve.Add(equipment);
            }
            else
            {
                Console.WriteLine($"You do not have room for the {equipment}");
            }
        }

        public void ReduceReserve(int index)
        {
            if (InReserve.Count > ItemCapacity)
            {
                InReserve.RemoveAt(index-1);
            }
        }

        public void RemoveItemFromReserve(int? index)
        {
            //while (true)
            //{
            //    Console.Write("You cannot carry as much now, you must remove an equipment:\nChoose");
            //    for (var i = 0; i < InReserve.Count; i++)
            //    {
            //        Console.WriteLine($"{i + 1}.{InReserve[i]}");
            //    }

            //    var key = Console.ReadKey(true).KeyChar;
            //    while (key != '1' || key != '2' || key != '3')
            //    {
            //        key = Console.ReadKey(true).KeyChar;
            //    }

            //    Console.WriteLine($"You are about to remove {InReserve[(int)key]}...\nAre you sure ?");
            //    var answer = Console.ReadKey(true).KeyChar;
            //    while (answer != 'y' || answer != 'n' || answer != 'Y' || answer != 'N')
            //    {
            //        answer = Console.ReadKey(true).KeyChar;
            //    }

            //    if (char.ToLower(answer) == 'n')
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        InReserve.RemoveAt((int)key);
            //    }
            //    break;
            //}

        }
    }
}
