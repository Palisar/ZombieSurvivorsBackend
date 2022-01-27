using ZombieSurvivorsKata;

Survivor sut = new("Wham");
Equipment Bat = new("Bat");
Equipment Chain = new("Chain");
Equipment Water = new("Water");
Equipment Fork = new("Fork");
Equipment Food = new("Food");
sut.PickUpItem(Bat);
sut.PickUpItem(Chain);
sut.PickUpItem(Water);
sut.PickUpItem(Fork);
sut.PickUpItem(Food);
sut.GotWounded();
