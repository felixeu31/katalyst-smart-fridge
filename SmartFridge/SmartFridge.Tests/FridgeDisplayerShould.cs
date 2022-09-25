using SmartFridge.Model;

namespace SmartFridge.Tests
{
    public class FridgeDisplayerShould
    {
        private Mock<IPrinter> _printerMock;

        [SetUp]
        public void Setup()
        {
            _printerMock = new Mock<IPrinter>();
        }

        [Test]
        public void DisplayEmptyFridge()
        {
            var displayer = new FridgeDisplayer(_printerMock.Object);

            displayer.ShowDisplay(new List<Item>(), DateTime.Now);

            _printerMock.Verify(display => display.Print("Fridge is empty"));
        }

        [Test]
        public void DisplayOneNotExpiredItem()
        {
            var displayer = new FridgeDisplayer(_printerMock.Object);

            var items = new List<Item>()
            {
                Item.CreateNew("Peppers", "29/09/2022", "opened")
            };

            displayer.ShowDisplay(items, new DateTime(2022, 9, 28));

            _printerMock.Verify(display => display.Print("Peppers: 1 days remaining"));
        }


        [Test]
        public void DisplayOneExpiredItem()
        {
            var displayer = new FridgeDisplayer(_printerMock.Object);

            var items = new List<Item>()
            {
                Item.CreateNew("Peppers", "29/09/2022", "opened")
            };

            displayer.ShowDisplay(items, new DateTime(2022, 9, 30));

            _printerMock.Verify(display => display.Print("EXPIRED: Peppers"));
        }
    }
}
