using SmartFridge.Model;

namespace SmartFridge.Tests
{
    public class ItemConditionTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Equal()
        {
            var itemCondition1 = ItemCondition.Sealed;
            var itemCondition2 = ItemCondition.Sealed;

            (itemCondition1 == itemCondition2).Should().BeTrue();
        }



        [Test]
        public void NotEqual()
        {
            var itemCondition1 = ItemCondition.Sealed;
            var itemCondition2 = ItemCondition.Opened;

            (itemCondition1 == itemCondition2).Should().BeFalse();
        }

        [Test]
        public void Equalatable()
        {
            var itemCondition1 = ItemCondition.Sealed;
            var itemCondition2 = ItemCondition.Sealed;

            itemCondition1.Should().Be(itemCondition2);
        }

        [Test]
        public void DistinctEqualatable()
        {
            var itemCondition1 = ItemCondition.Sealed;
            var itemCondition2 = ItemCondition.Opened;

            itemCondition1.Should().NotBe(itemCondition2);
        }
    }
}