using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class NullableTypes
    {
        [Fact]
        public void Nullable_types_assertions()
        {
            short? theShort = null;
            theShort.Should().NotHaveValue();
            theShort.Should().BeNull();

            int? theInt = 3;
            theInt.Should().HaveValue();
            theInt.Should().NotBeNull();
        }
    }
}