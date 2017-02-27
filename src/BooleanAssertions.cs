using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class BooleanAssertions
    {
        [Fact]
        public void Boolean_assertions()
        {
            bool theBoolean = false;

            theBoolean.Should().BeFalse();

            theBoolean = true;
            bool otherBoolean = true;

            theBoolean.Should().BeTrue();
            theBoolean.Should().Be(otherBoolean);
        }

        [Fact]
        public void Nullable_boolean_assertions()
        {
            bool? theBoolean = null;

            theBoolean.Should().NotBeFalse();
            theBoolean.Should().NotBeTrue();
        }
    }
}