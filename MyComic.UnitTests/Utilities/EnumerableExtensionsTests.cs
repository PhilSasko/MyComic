using MyComic.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.UnitTests.Utilities
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [TestCase(5, 1, 1, 2)]
        [TestCase(5, 1, 2, 3)]
        [TestCase(5, 2, 1, 3)]
        [TestCase(5, 4, 1, 5)]
        [TestCase(5, 1, 4, 5)]
        [TestCase(100_000, 1, 1, 2)]
        [TestCase(100_000, 1, 2, 3)]
        [TestCase(100_000, 1, 99_999, 100_000)]
        [TestCase(5, 5, -1, 4)]
        [TestCase(5, 5, -2, 3)]
        [TestCase(5, 2, -1, 1)]
        [TestCase(5, 5, -4, 1)]
        [TestCase(100_000, 100_000, -1, 99_999)]
        [TestCase(100_000, 100_000, -99_999, 1)]
        public void TryOffsetBy_WhenElements_ReturnsCorrectOne(int numberOfElements, int startId, int idOffset, int expectedResultId)
        {
            IEnumerable<MockEntity> entities = GenerateAndGetEntities(numberOfElements);

            entities.TryOffsetBy(entity => entity.Id, startId: startId, idOffset: idOffset, out MockEntity secondEntity);

            Assert.That(secondEntity.Id, Is.EqualTo(expectedResultId));
        }

        private IEnumerable<MockEntity> GenerateAndGetEntities(int numberOfEntities)
        {
            for (int i = 1; i <= numberOfEntities; i++)
            {
                yield return new MockEntity()
                {
                    Id = i,
                    Description = $"Entity {i}"
                };
            }
        }
    }

    internal class MockEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
