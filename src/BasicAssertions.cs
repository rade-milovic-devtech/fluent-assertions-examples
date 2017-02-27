using System;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class BasicAssertions
    {
        [Fact]
        public void Null_check_assertions()
        {
            object nullObject = null;
            object theObject = "whatever";

            nullObject.Should().BeNull("because the value is null");
            theObject.Should().NotBeNull();
        }

        [Fact]
        public void Type_check_assertions()
        {
            object theObject = "whatever";

            theObject.Should().BeOfType<string>("because a {0} is set", typeof(string));
            theObject.Should().BeOfType(typeof(string), "because a {0} is set", typeof(string));
        }

        [Fact]
        public void Assert_and_continue_with_additional_assertions()
        {
            Exception exception = new Exception("Some Message");

            exception.Should().BeOfType<Exception>().Which.Message.Should().Be("Some Message");
        }

        [Fact]
        public void Equality_assertions()
        {
            string message = "something";

            message.Should().Be("something");
            message.Should().NotBe("other");
        }

        [Fact]
        public void Reference_equality_assertions()
        {
            string message = "something";
            string otherMessage = message;
            string thirdMessage = "third";

            message.Should().BeSameAs(otherMessage);
            message.Should().NotBeSameAs(thirdMessage);
        }

        [Fact]
        public void Type_assignment_assertions()
        {
            ArgumentException exception = new ArgumentException();

            exception.Should().BeAssignableTo<Exception>();
        }

        [Fact]
        public void Boolean_expression_assertions()
        {
            object dummy = "some message";

            dummy.Should().Match(d => (d.ToString() == "some message"));
            dummy.Should().Match<string>(d => d == "some message");
            dummy.Should().Match((string d) => d == "some message");
        }

        [Fact]
        public void Downcasting_asserted_objects()
        {
            ArgumentException exception = new ArgumentException("some message");

            exception.As<Exception>().Message.Should().Be("some message");
        }
    }
}