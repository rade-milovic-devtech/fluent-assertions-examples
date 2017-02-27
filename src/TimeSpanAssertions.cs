using System;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class TimeSpanAssertions
    {
        [Fact]
        public void Time_span_assertions()
        {
            var timeSpan = new TimeSpan(12, 59, 59);
            var negativeTimeSpan = new TimeSpan(-12, 59, 59);
            var equalTimeSpan = new TimeSpan(12, 00, 00);
            var someOtherTimeSpan = new TimeSpan(13, 59, 59);
            var thirdTimeSpan = new TimeSpan(11, 59, 59);

            timeSpan.Should().BePositive();
            negativeTimeSpan.Should().BeNegative();
            equalTimeSpan.Should().Be(12.Hours());
            timeSpan.Should().NotBe(1.Days());
            timeSpan.Should().BeLessThan(someOtherTimeSpan);
            timeSpan.Should().BeLessOrEqualTo(someOtherTimeSpan);
            timeSpan.Should().BeGreaterThan(thirdTimeSpan);
            timeSpan.Should().BeGreaterOrEqualTo(thirdTimeSpan);
            timeSpan.Should().BeCloseTo(new TimeSpan(13, 0, 0), 1000);
        }
    }
}