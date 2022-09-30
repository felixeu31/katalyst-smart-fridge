using NSubstitute;
using SmartFridge.Model;

namespace SmartFridge.Tests
{
    public class FrigeShould
    {
        private IFridgeDisplayer _fridgeDisplayerMock;

        [SetUp]
        public void Setup()
        {
            _fridgeDisplayerMock = Substitute.For<IFridgeDisplayer>();
        }

        [Test]
        public void CurrentDate_WhenSetupDate_FridgeDateIsUpdated()
        {
            var fridge = new Fridge(_fridgeDisplayerMock);

            fridge.SetCurrentDate("16/09/2022");

            var fridgeCurrentDate = fridge.CurrentDate();

            fridgeCurrentDate.Date.Should().Be(new DateTime(2022, 9, 16).Date);
        }

        [Test]
        public void CurrentDate_WhenSimulateDayOver_OneDayIsAdded()
        {
            var fridge = new Fridge(_fridgeDisplayerMock);

            fridge.SetCurrentDate("16/09/2022");
            fridge.SimulateDayOver();

            var fridgeCurrentDate = fridge.CurrentDate();

            fridgeCurrentDate.Date.Should().Be(new DateTime(2022, 9, 17).Date);
        }

        [Test]
        public void Door_WhenOpenFridge_FridgeIsOpen()
        {
            var fridge = new Fridge(_fridgeDisplayerMock);

            fridge.OpenDoor();

            fridge.IsOpen().Should().BeTrue();
        }

        [Test]
        public void Door_WhenCloseFridge_FridgeIsClose()
        {
            var fridge = new Fridge(_fridgeDisplayerMock);

            fridge.OpenDoor();
            fridge.CloseDoor();

            fridge.IsOpen().Should().BeFalse();
        }

        [Test]
        public void Items_AddItems()
        {
            var fridge = new Fridge(_fridgeDisplayerMock);
            fridge.SetCurrentDate("16/09/2022");

            fridge.OpenDoor();
            fridge.AddItem(name: "Peppers", expiry: "17/09/2022", condition: "sealed");
            fridge.AddItem(name: "Tomatoes", expiry: "17/09/2022", condition: "sealed");
            fridge.CloseDoor();

            fridge.Items().Should().HaveCount(2);
        }

        [Test]
        public void Items_RemoveItems()
        {
            var fridge = new Fridge(_fridgeDisplayerMock);
            fridge.SetCurrentDate("16/09/2022");

            fridge.OpenDoor();
            fridge.AddItem(name: "Peppers", expiry: "17/09/2022", condition: "sealed");
            fridge.AddItem(name: "Tomatoes", expiry: "17/09/2022", condition: "sealed");
            fridge.CloseDoor();

            fridge.OpenDoor();
            fridge.RemoveItem(name: "Peppers");
            fridge.CloseDoor();

            fridge.Items().Should().HaveCount(1);
        }

        // Open door degrade items
        // Several door openings get items to expire
        // Display expired items

        // Optional:
        // Exceptions thrown: remove item not found, add item when door is closed
    }
}