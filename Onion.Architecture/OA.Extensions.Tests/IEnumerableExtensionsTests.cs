using System;
using System.Collections.Generic;
using Xunit;

namespace OA.Extensions.Tests
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void HasItemsPositiveTest()
        {
            var items = new List<string> { "1", "2", "3" };
            var hasItems = items.HasItems();
            Assert.True(hasItems);
        }

        [Fact]
        public void HasItemsNegativeTest()
        {
            var items = new List<string>();
            var hasItems = items.HasItems();
            Assert.False(hasItems);
        }

        [Fact]
        public void NoItemsPositiveTest()
        {
            var items = new List<string>();
            var noItems = items.NoItems();
            Assert.True(noItems);
        }

        [Fact]
        public void NoItemsNegativeTest()
        {
            var items = new List<string>() { "1","2","3"};
            var noItems = items.NoItems();
            Assert.False(noItems);
        }

    }
}
