using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class DateTimeAssertions
    {
        [Fact]
        public void Date_and_time_assertions()
        {
            var theDateTime = 1.March(2017).At(22,15);

            theDateTime.Should().BeAfter(1.February(2017));
            theDateTime.Should().BeBefore(2.March(2017));
            theDateTime.Should().BeOnOrAfter(1.March(2017));

            theDateTime.Should().Be(1.March(2017).At(22, 15));
            theDateTime.Should().NotBe(1.March(2017).At(22, 16));

            theDateTime.Should().HaveDay(1);
            theDateTime.Should().HaveMonth(3);
            theDateTime.Should().HaveYear(2017);
            theDateTime.Should().HaveHour(22);
            theDateTime.Should().HaveMinute(15);
            theDateTime.Should().HaveSecond(0);

            theDateTime.Should().BeSameDateAs(1.March(2017));
        }

        [Fact]
        public void Date_and_time_comparison_assertions()
        {
            var theDateTime = 3.March(2017).At(22, 15);
            var otherDateTime = 3.March(2017).At(22, 23);
            var deadLine = 5.March(2017).At(22, 15);
            var deliveryDate = 5.March(2017).At(22, 15);
            var appointement = 4.March(2017).At(22, 15);

            theDateTime.Should().BeLessThan(10.Minutes()).Before(otherDateTime);
            theDateTime.Should().BeWithin(2.Hours()).After(otherDateTime);
            theDateTime.Should().BeMoreThan(1.Days()).Before(deadLine);
            theDateTime.Should().BeAtLeast(2.Days()).Before(deliveryDate);
            theDateTime.Should().BeExactly(24.Hours()).Before(appointement);
            theDateTime.Should().BeCloseTo(3.March(2017).At(22, 15), 2000);
            theDateTime.Should().BeCloseTo(3.March(2017).At(22, 15));
        }
    }
}