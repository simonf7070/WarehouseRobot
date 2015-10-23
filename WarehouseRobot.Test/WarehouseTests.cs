using NUnit.Framework;

namespace WarehouseRobot.Test
{
    [TestFixture]
    public class WarehouseTests
    {
        [Test]
        public void CoordinatesAreValid()
        {
            var warehouse = new Warehouse(5, 5);
            Assert.That(warehouse.IsValidCoordinate(0, 0), Is.True);
        }

        [Test]
        public void CoordinatesAreInvalidWhenXIsOutsideWarehouse()
        {
            var warehouse = new Warehouse(5, 5);
            Assert.That(warehouse.IsValidCoordinate(6, 0), Is.False);
        }

        [Test]
        public void CoordinatesAreInvalidWhenYIsOutsideWarehouse()
        {
            var warehouse = new Warehouse(5, 5);
            Assert.That(warehouse.IsValidCoordinate(0, 6), Is.False);
        }

        [Test]
        public void CoordinatesAreInvalidWhenXandYAreOutsideWarehouse()
        {
            var warehouse = new Warehouse(5, 5);
            Assert.That(warehouse.IsValidCoordinate(6, 6), Is.False);
        }

        [Test]
        [ExpectedException]
        public void WarehouseCreatedWithInvalidXDimension()
        {
            var warehouse = new Warehouse(-1, 1);
        }

        [Test]
        [ExpectedException]
        public void WarehouseCreatedWithInvalidYDimension()
        {
            var warehouse = new Warehouse(1, -1);
        }
    }
}
