using SmartFridge.Model;

namespace SmartFridge.Tests
{
    public class SmartFrigeTests
    {
        private Mock<IPrinter> _displayPrinter;

        [SetUp]
        public void Setup()
        {
            _displayPrinter = new Mock<IPrinter>();
        }

        [Test]
        public void WhenSetupDate_FridgeDateIsUpdated()
        {
            var fridge = new Fridge(_displayPrinter.Object);

            fridge.SetCurrentDate("16/09/2022");

            var fridgeCurrentDate = fridge.CurrentDate();

            fridgeCurrentDate.Date.Should().Be(new DateTime(2022, 9, 16).Date);
        }

        [Test]
        public void WhenSimulateDayOver_OneDayIsAdded()
        {
            var fridge = new Fridge(_displayPrinter.Object);

            fridge.SetCurrentDate("16/09/2022");
            fridge.SimulateDayOver();

            var fridgeCurrentDate = fridge.CurrentDate();

            fridgeCurrentDate.Date.Should().Be(new DateTime(2022, 9, 17).Date);
        }

        [Test]
        public void WhenOpenFridge_FridgeIsOpen()
        {
            var fridge = new Fridge(_displayPrinter.Object);

            fridge.OpenDoor();

            fridge.IsOpen().Should().BeTrue();
        }

        [Test]
        public void WhenCloseFridge_FridgeIsClose()
        {
            var fridge = new Fridge(_displayPrinter.Object);

            fridge.OpenDoor();
            fridge.CloseDoor();

            fridge.IsOpen().Should().BeFalse();
        }

        [Test]
        public void WhenEmptyFridge_ShowDisplay_EmptyMessageDisplayed()
        {
            var fridge = new Fridge(_displayPrinter.Object);

            fridge.ShowDisplay();

            _displayPrinter.Verify(display => display.Print("Fridge is empty"));
        }


        [Test]
        public void WhenAddItem_DisplayShowsItem()
        {
            var fridge = new Fridge(_displayPrinter.Object);

            fridge.SetCurrentDate("16/09/2022");

            fridge.OpenDoor();

            fridge.AddItem(name: "Peppers", expiry: "17/09/2022", condition: "sealed");

            fridge.ShowDisplay();

            _displayPrinter.Verify(display => display.Print("Peppers: 1 days remaining"));
        }

        //If door is closed can not add item

        //Display expired items

        //Open door decrease expiry
    }
}