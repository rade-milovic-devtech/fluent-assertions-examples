using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class ExceptionsAssertions
    {
        [Fact]
        public void Exception_occuring_assertions()
        {
            SomeType someObject = new SomeType();

            someObject.Invoking(subject => subject.SomeMethodThatThrows("Something"))
                .ShouldThrow<ArgumentException>()
                .WithMessage("Invalid message\r\nParameter name: message");

            Action throwAction = () => someObject.SomeMethodThatThrows("Hello");

            throwAction.ShouldThrow<ArgumentException>()
                .WithInnerException<ArgumentOutOfRangeException>()
                .WithInnerMessage("whatever\r\nParameter name: message");

            throwAction.ShouldThrow<ArgumentException>().Which.ParamName.Should().Be("message");
            throwAction.ShouldThrow<ArgumentException>().Where(exception => exception.Message == "Invalid message\r\nParameter name: message");
            throwAction.ShouldThrow<ArgumentException>().WithMessage("*val*");
        }

        [Fact]
        public void Exception_not_occuring_assertions()
        {
            SomeType someObject = new SomeType();

            Action action = () => someObject.SomeMethod();
            Action actionThatThrows = () => someObject.SomeMethodThatThrows(null);

            action.ShouldNotThrow();
            actionThatThrows.ShouldNotThrow<InvalidCastException>();
        }

        [Fact]
        public void Exceptions_in_enumerations_assertions()
        {
            SomeType someObject = new SomeType();

            Func<IEnumerable<string>> functionThatThrows = () => someObject.SomeEnumerableThrowingMethod();

            functionThatThrows.Enumerating().ShouldThrow<Exception>();
        }

        [Fact]
        public void Exceptions_in_async_code_assertions()
        {
            SomeType someObject = new SomeType();

            Func<Task> asyncFunctionThatThrows = async () => { await someObject.SomeAsyncMethodThatThrows(null); };
            Func<Task> asyncFunctionThatDoesNotThrows = async () => { await someObject.SomeAsyncMethod(); };

            asyncFunctionThatThrows.ShouldThrow<ArgumentException>();
            asyncFunctionThatDoesNotThrows.ShouldNotThrow();
        }
    }

    public class SomeType
    {
        public void SomeMethodThatThrows(string message)
        {
            throw new ArgumentException("Invalid message", nameof(message),
                new ArgumentOutOfRangeException(nameof(message), "whatever"));
        }

        public Task SomeAsyncMethodThatThrows(string message)
        {
            throw new ArgumentException("Invalid message", nameof(message),
                new ArgumentOutOfRangeException(nameof(message), "whatever"));
        }

        public void SomeMethod() {}

        public Task<int> SomeAsyncMethod() => Task.FromResult(1);

        public IEnumerable<string> SomeEnumerableThrowingMethod()
        {
            yield return "One";
            yield return "Two";

            throw new Exception();
        }
    }
}