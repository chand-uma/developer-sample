using System;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    public interface IGreetingService
    {
        void Greet(string name);
    }

    public class GreetingService : IGreetingService
    {
        public void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }
    }
}