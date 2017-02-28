using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Collections;
using FluentAssertions.Execution;
using Xunit;

namespace FluentAssertionsExamples
{
    public class CustomAssertions
    {
        [Fact]
        public void Custom_assertion_pass()
        {
            var fruitBasket = new[] { "Banana", "Apple", "Kiwi" };

            fruitBasket.Should().ContainBananas();
        }

        [Fact]
        public void Custom_assertion_failure()
        {
            var fruitBasket = new[] { "Apple", "Kiwi" };

            fruitBasket.Should().ContainBananas();
        }
    }

    public class FruitBasketAssertions : GenericCollectionAssertions<string>
    {
        public void ContainBananas(string reason = "bananas are not present", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.Any(item => string.Equals(item, "banana", StringComparison.InvariantCultureIgnoreCase)))
                .BecauseOf(reason, reasonArgs)
                .FailWith("Expected fruit basket to contain bananas");
        }

        public FruitBasketAssertions(IEnumerable<string> actualValue) : base(actualValue) {}
    }

    public static class FruitBasketExtensions
    {
            public static FruitBasketAssertions Should(this IEnumerable<string> fruitBasket)
        {
            return new FruitBasketAssertions(fruitBasket);
        }
    }
}