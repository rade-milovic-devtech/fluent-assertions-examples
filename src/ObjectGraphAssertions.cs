using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsExamples
{
    public class ObjectGraphAssertions
    {
        [Fact]
        public void Object_graph_assertions()
        {
            Order order = new Order();
            OrderDto orderDto = new OrderDto();

            orderDto.ShouldBeEquivalentTo(order, options => options.ExcludingMissingMembers());
            orderDto.ShouldBeEquivalentTo(order, options => options.ExcludingNestedObjects()
                .Excluding(od => od.ResponseId));
        }
    }

    public class Order
    {
        public IEnumerable<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Product {}

    public class OrderDto
    {
        public string ResponseId { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public CustomerDto Customer { get; set; }
    }

    public class CustomerDto
    {
        public string Name { get; set; }
    }

    public class ProductDto {}
}