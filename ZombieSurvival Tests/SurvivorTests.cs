
using System.Collections.Generic;

namespace ZombieSurvival_Tests
{
    public class SurvivorTests
    {
        private readonly Survivor sut;
        private readonly List<Equipment> equipment = new List<Equipment>();

        public SurvivorTests()
        {
            sut = new Survivor("Paul");
            equipment.Add(new Equipment("Bat"));
            equipment.Add(new Equipment("Pan"));
            equipment.Add(new Equipment("Water"));
            equipment.Add(new Equipment("Bags"));
            equipment.Add(new Equipment("Beans"));
            equipment.Add(new Equipment("Katana"));
        }
        [Fact]
        public void WhenSurvivorIsWounded_Then_WoundIncreaseBy1()
        {
            sut.GotWounded();
            sut.Wounds.Should().Be(1);
        }

        [Fact]
        public void WhenSurvivorWoundsAreGreaterThan2_Then_SurvivorStateBecomesDead()
        {
            sut.GotWounded();
            sut.GotWounded();
            sut.State.Should().Be(State.Dead);
        }

        [Fact]
        public void WhenSurviorIsWounded3Times_Then_WoundsCountIsStill2()
        {
            sut.GotWounded();
            sut.GotWounded();
            sut.GotWounded();
            sut.Wounds.Should().Be(2);
        }

        [Fact]
        public void WhenSurvivorUsesAction_Then_ActionCountDecreases()
        {
            sut.UseAction();
            sut.ActionCount.Should().Be(2);
        }

        [Fact]
        public void WhenSurvivorUsesAction3TImes_Then_ActionCountStopsAt0()
        {
            sut.UseAction();
            sut.UseAction();
            sut.UseAction();
            sut.UseAction();
            sut.ActionCount.Should().Be(0);
        }

        [Fact]
        public void SurvivorPicksUpItem_Then_ItemIsInHand()
        {
            sut.PickUpItem(equipment[0]);

            sut.ActiveHand.Should().BeEquivalentTo(equipment[0]);
        }

        [Fact]
        public void SurvivorCannotPickUpSameItemTwice()
        {
            sut.PickUpItem(equipment[0]);
            sut.PickUpItem(equipment[0]);

            sut.ActiveHand.Should().BeNull();
        }

        [Fact]
        public void SurvivorPicksUpItemWithItemInMainHand_Then_ItemIsInOffHand()
        {
            sut.PickUpItem(equipment[0]);
            sut.PickUpItem(equipment[1]);

            sut.OffHand.Should().BeEquivalentTo(equipment[1]);
        }

        [Fact]
        public void SurvivorCannotPickUpMoreThan5Items()
        {
            for (int i = 0; i < equipment.Count; i++)
            {
                sut.PickUpItem(equipment[i]);
            }

            sut.InReserve[2].Should().Be(equipment[4]);
        }

        [Fact]
        public void WoundedSurvivorLoosesItemSlot()
        {
            for(int i = 0; i < equipment.Count; i++)
            {
                sut.PickUpItem(equipment[i]);
            }
            sut.GotWounded();
            sut.ItemCapacity.Should().Be(2);
        }

        [Fact]
        public void SurvivorGotWounded_Then_LooseItemsWhenWounded()
        {
            for (int i = 0; i < equipment.Count; i++)
            {
                sut.PickUpItem(equipment[i]);
            }

            sut.GotWounded();
            if (sut.WoundedThisRound)
            {
                sut.InReserve.RemoveAt(2);
            }

            sut.InReserve.Count.Should().Be(2);
            sut.InReserve[1].Should().Be(equipment[3]);
        }
    }
}
