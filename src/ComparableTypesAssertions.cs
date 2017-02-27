using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class ComparableTypesAssertions
    {
        [Fact]
        public void Numberic_comparison_assertions()
        {
            float first = -3.1F;
            int second = 5;
            int third = 7;

            second.Should().BeGreaterOrEqualTo(5);
            second.Should().BeGreaterOrEqualTo(3);
            third.Should().BeGreaterThan(4);
            second.Should().BeLessOrEqualTo(5);
            first.Should().BeLessThan(6);
            first.Should().BeNegative();
            third.Should().BePositive();
            second.Should().Be(5);
            first.Should().NotBe(10);
            third.Should().BeInRange(1, 10);
        }

        [Fact]
        public void Float_and_double_equality_assertions()
        {
            float value = 3.1415927F;

            value.Should().BeApproximately(3.14F, 0.01F);
        }

        [Fact]
        public void Match_one_of_provided_values_assertion()
        {
            int value = 3;

            value.Should().BeOneOf(3, 6);
        }
    }
}