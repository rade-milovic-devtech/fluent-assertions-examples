using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class CollectionsAssertions
    {
        [Fact]
        public void Collections_equality_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

            collection.Should().Equal(new List<int> { 1, 2, 5, 8 });
            collection.Should().Equal(1, 2, 5, 8);
            collection.Should().BeEquivalentTo(8, 2, 1, 5);
            collection.Should().NotBeEquivalentTo(new[] { 8, 2, 3, 5 });
        }

        [Fact]
        public void Collections_count_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

            collection.Should().HaveCount(count => count > 3).And.OnlyHaveUniqueItems();
            collection.Should().HaveSameCount(new[] {6, 2, 0, 5});
        }

        [Fact]
        public void Collections_start_and_end_with_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

            collection.Should().StartWith(1);
            collection.Should().EndWith(8);
        }

        [Fact]
        public void Collections_subset_of_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

            collection.Should().BeSubsetOf(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, });
        }

        [Fact]
        public void Collections_containing_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };
            IEnumerable<int> singleItemCollection = new[] { 5 };

            singleItemCollection.Should().ContainSingle();
            singleItemCollection.Should().ContainSingle(x => x > 3);
            collection.Should().Contain(8).And.HaveElementAt(2, 5).And.NotBeSubsetOf(new[] { 11, 56 });
            collection.Should().Contain(x => x > 3);
            collection.Should().Contain(collection, "", 5, 6);
            collection.Should().OnlyContain(x => x < 10);
            collection.Should().ContainItemsAssignableTo<int>();
            collection.Should().ContainInOrder(new[] { 1, 5, 8 });
            collection.Should().NotContain(82);
            collection.Should().NotContainNulls();
            collection.Should().NotContain(x => x > 10);
        }

        [Fact]
        public void Collections_preceding_and_succeeding_elements_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

            collection.Should().HaveElementPreceding(5, 2);
            collection.Should().HaveElementSucceeding(5, 8);
        }

        [Fact]
        public void Collections_empty_and_null_assertions()
        {
            IEnumerable<int> nullCollection = null;
            IEnumerable<int> emptyCollection = new int[0];
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

            emptyCollection.Should().BeEmpty();
            nullCollection.Should().BeNullOrEmpty();
            collection.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Collections_intersection_assertions()
        {
            IEnumerable<int> collection = new[] { 1, 2, 5, 8 };
            IEnumerable<int> otherCollection = new[] { 1, 2, 5, 8, 1 };
            IEnumerable<int> anotherCollection = new[] { 10, 20, 50, 80, 10 };

            collection.Should().IntersectWith(otherCollection);
            collection.Should().NotIntersectWith(anotherCollection);
        }

        [Fact]
        public void Collections_ordering_assertions()
        {
            IEnumerable<int> ascendingCollection = new[] { 1, 2, 5, 8 };
            IEnumerable<int> descendingCollection = new[] { 8, 5, 2, 1 };

            ascendingCollection.Should().BeInAscendingOrder();
            ascendingCollection.Should().NotBeDescendingInOrder();
            descendingCollection.Should().BeInDescendingOrder();
            descendingCollection.Should().NotBeAscendingInOrder();
        }

        [Fact]
        public void Collections_with_complex_types_assertions()
        {
            var activeCustomers = new[] { new { Name = "Alice", Age = 27 }, new { Name = "Bob", Age = 42 } };
            var persistedCustomers = new[] { new { Name = "Alice", Age = 27 }, new { Name = "Bob", Age = 42 } };

            activeCustomers.Should().BeInAscendingOrder(customer => customer.Name);
            persistedCustomers.Select(customer => customer.Name).Should().Equal(activeCustomers.Select(customer => customer.Name));
            persistedCustomers.Should().Equal(activeCustomers,(persistedCustomer, activeCustomer) => persistedCustomer.Name == activeCustomer.Name);
        }
    }
}