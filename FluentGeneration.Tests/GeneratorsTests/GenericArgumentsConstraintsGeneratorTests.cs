using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class GenericArgumentsConstraintsGeneratorTests
    {
        [Test]
        public void MultipleArgumentConstraintTest()
        {
            var generator = new GenericArgumentsConstraintsGenerator();
            var constraints = new[]
            {
                new GenericArgumentConstraint
                {
                    GenericArgumentName = "T1",
                    Constraints = new[] {typeof(System.IComparable)},
                },
                new GenericArgumentConstraint
                {
                    GenericArgumentName = "T2",
                    Constraints = new[] {typeof(System.IComparable)},
                },
            };
            var result = generator.Generate(constraints);
            Assert.AreEqual(@"where T1 : System.IComparable
where T2 : System.IComparable", result);
        }

        [Test]
        public void SingleArgumentConstraintTest()
        {
            var generator = new GenericArgumentsConstraintsGenerator();
            var constraints = new[]
            {
                new GenericArgumentConstraint
                {
                    GenericArgumentName = "T", Constraints = new[] {typeof(System.IComparable)}
                }
            };
            var result = generator.Generate(constraints);
            Assert.AreEqual("where T : System.IComparable", result);
        }

        [Test]
        public void NoArgumentConstraintTest()
        {
            var generator = new GenericArgumentsConstraintsGenerator();
            var constraints = new[] {new GenericArgumentConstraint {GenericArgumentName = "T"}};
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(constraints));
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase("test", ExpectedResult = "test")]
        [TestCase("where T1 : IEnumerable<T2>", ExpectedResult = "where T1 : IEnumerable<T2>")]
        public string LiteralDataTest(string data)
        {
            var generator = new GenericArgumentsConstraintsGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new GenericArgumentsConstraintsGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new GenericArgumentsConstraintsGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}