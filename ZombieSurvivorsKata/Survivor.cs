using Microsoft.VisualBasic;
using ZombieSurvivorsKata.Interfaces;
using ZombieSurvivorsKata.Skills;

namespace ZombieSurvivorsKata
{
    public class Survivor : Human
    {
        private readonly IGamelog _log;

        public Survivor(string name, IGamelog log) : base(name)
        {
            _log = log;
            State = State.Alive;
            ActionCount = 3;
            ActionsPerTurn = 3;
            InReserve = new List<Equipment>();
            ItemCapacity = 3;
            ExperiencePoints = 0;
            Level = Level.Blue;
        }
        
        public sealed override State State { get; set; }
        public int ActionsPerTurn { get; }
        public int ActionCount { get; set; }

        public SkillTree PotentialSkills { get; private set; }
        public Equipment? ActiveHand { get; private set; }
        public Equipment? OffHand { get; private set; }
        public List<Equipment> InReserve { get; private set; }
        public int ItemCapacity { get; private set; }
        public bool WoundedThisRound { get; private set; }
        public int ExperiencePoints { get; private set; }
        
        public Level Level { get; set; }

        public void GotWounded()
        {
            _log.Message($"{Name} has been wounded!");
            if (this.Wounds < this.WoundsToDeath)
            {
                Wounds++;
                ItemCapacity--;
                WoundedThisRound = true;
            }
            if (this.Wounds == this.WoundsToDeath)
            {
                State = State.Dead;
                _log.Message($"{Name} has died...");
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
            _log.Message($"{this.Name} has picked up a {equipment}");

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
                _log.Message($"You do not have room for the {equipment}");
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


        public void GainExperience()
        {
            ExperiencePoints++;
            CheckLevel();
        }

        public void CheckLevel()
        {
            var values = Enum.GetValues(typeof(Level));
            foreach (var level in values)
            {
                if (ExperiencePoints == (int)level)
                {
                    _log.Message($"{Name} is now level {level}!");
                    Level = (Level)level;
                }
            }
        }

        private void PopulatePotentialSkills()
        {

        }
    }
}
