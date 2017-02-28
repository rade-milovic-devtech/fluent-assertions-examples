using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class DictionariesAssertions
    {
        [Fact]
        public void Dictionaries_empty_and_null_assertions()
        {
            Dictionary<int, string> dictionary = null;

            dictionary.Should().BeNull();

            dictionary = new Dictionary<int, string>();

            dictionary.Should().NotBeNull();
            dictionary.Should().BeEmpty();

            dictionary.Add(1, "first element");

            dictionary.Should().NotBeEmpty();
        }

        [Fact]
        public void Dictionaries_equality_assertions()
        {
            var dictionary1 = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" }
            };
            var dictionary2 = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" }
            };
            var dictionary3 = new Dictionary<int, string>
            {
                { 3, "Three" },
            };

            dictionary1.Should().Equal(dictionary2);
            dictionary1.Should().NotEqual(dictionary3);
        }

        [Fact]
        public void Dictionaries_containing_assertions()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>
            {
                { 1, "One" }
            };

            dictionary.Should().ContainKey(1);
            dictionary.Should().NotContainKey(9);
            dictionary.Should().ContainValue("One");
            dictionary.Should().NotContainValue("Nine");

            KeyValuePair<int, string> item = new KeyValuePair<int, string>(1, "One");

            dictionary.Should().Contain(item);
            dictionary.Should().Contain(1, "One");
            dictionary.Should().NotContain(9, "Nine");
        }

        [Fact]
        public void Dictionaries_additional_assertions_chaining()
        {
            Tuple<string, int> value = new Tuple<string, int>("Alice", 12);
            Dictionary<int, Tuple<string, int>> dictionary = new Dictionary<int, Tuple<string, int>>
            {
                { 1, value }
            };

            dictionary.Should().ContainValue(value).Which.Item2.Should().BeGreaterThan(10);
        }
    }
}