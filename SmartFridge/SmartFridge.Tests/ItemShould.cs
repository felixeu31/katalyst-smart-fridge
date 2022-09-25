using SmartFridge.Model;

namespace SmartFridge.Tests
{
    public class ItemShould
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateSuccessfully()
        {
            var item = Item.CreateNew("Peppers", "20/09/2022", "sealed");

            item.Should().NotBeNull();
        }

        [Test]
        public void Degrade_WhenSealed()
        {
            var item = Item.CreateNew("Peppers", "20/09/2022", "sealed");

            var originalDate = item.Expiry();

            item.Degrade();

            var degradedDate = item.Expiry();

            var totalHoursBetweenDates = (originalDate - degradedDate).TotalHours;

            totalHoursBetweenDates.Should().Be(1);
        }

        [Test]
        public void Degrade_WhenOpened()
        {
            var item = Item.CreateNew("Peppers", "20/09/2022", "opened");

            var originalDate = item.Expiry();

            item.Degrade();

            var degradedDate = item.Expiry();

            var totalHoursBetweenDates = (originalDate - degradedDate).TotalHours;

            totalHoursBetweenDates.Should().Be(5);
        }

    }
}