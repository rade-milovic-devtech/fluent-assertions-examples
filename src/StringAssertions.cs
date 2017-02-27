using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class StringAssertions
    {
        [Fact]
        public void String_null_empty_and_whitespace_assertions()
        {
            string nullString = null;
            string emptyString = "";
            string whitespaceString = "   ";
            string theString = "something";

            emptyString.Should().NotBeNull();
            nullString.Should().BeNull();
            emptyString.Should().BeEmpty();
            whitespaceString.Should().NotBeEmpty();
            emptyString.Should().HaveLength(0);
            whitespaceString.Should().BeNullOrWhiteSpace();
            theString.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void String_equality_assertions()
        {
            string theString = "This is a String";

            theString.Should().Be("This is a String");
            theString.Should().NotBe("This is another String");
            theString.Should().BeEquivalentTo("THIS IS A STRING");
        }

        [Fact]
        public void String_containing_assertions()
        {
            string theString = "This is a String";

            theString.Should().Contain("is a");
            theString.Should().NotContain("bla");
            theString.Should().ContainEquivalentOf("IS A");
            theString.Should().NotContainEquivalentOf("bLa");
        }

        [Fact]
        public void String_starts_with_assertions()
        {
            string theString = "This is a String";

            theString.Should().StartWith("This");
            theString.Should().NotStartWith("Bla");
            theString.Should().StartWithEquivalent("ThIs");
            theString.Should().NotStartWithEquivalentOf("BLA");
        }

        [Fact]
        public void String_ends_with_assertions()
        {
            string theString = "This is a String";

            theString.Should().EndWith("a String");
            theString.Should().NotEndWith("bla");
            theString.Should().EndWithEquivalent("a stRinG");
            theString.Should().NotEndWithEquivalentOf("bLA");
        }

        [Fact]
        public void String_wildcards_assertions()
        {
            string emailAddress = "someone@somedomain.com";

            emailAddress.Should().Match("*@*.com");
            emailAddress.Should().MatchEquivalentOf("*@*.COM");
        }

        [Fact]
        public void String_regex_assertions()
        {
            string emailAddress = "someone@somedomain.com";

            emailAddress.Should().MatchRegex(".*domain.*");
            emailAddress.Should().NotMatchRegex(".*nonsence.*");
        }
    }
}