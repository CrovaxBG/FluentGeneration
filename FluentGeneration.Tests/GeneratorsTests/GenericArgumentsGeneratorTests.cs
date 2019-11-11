using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class GenericArgumentsGeneratorTests
    {
        [Test]
        public void EmptyDataTest()
        {
            var generator = new GenericArgumentsGenerator();
            var result = generator.Generate(new IGenericArgument[0]);

            Assert.AreEqual("", result);
        }

        [Test]
        public void MultipleArgumentsTest()
        {
            var generator = new GenericArgumentsGenerator();

            var genericArguments = new[]
            {
                new GenericArgument { Type = GenericArgumentType.Standard, Name = "T1" },
                new GenericArgument { Type = GenericArgumentType.Covariant, Name = "T2" },
                new GenericArgument { Type = GenericArgumentType.Contravariant, Name = "T3" },
            };
            var result = generator.Generate(genericArguments);

            Assert.AreEqual("T1, out T2, in T3", result);
        }

        [Test]
        public void MultipleStandardArgumentsTest()
        {
            var generator = new GenericArgumentsGenerator();

            var genericArguments = new[]
            {
                new GenericArgument { Type = GenericArgumentType.Standard, Name = "T1" },
                new GenericArgument { Type = GenericArgumentType.Standard, Name = "T2" },
            };
            var result = generator.Generate(genericArguments);

            Assert.AreEqual("T1, T2", result);
        }

        [Test]
        public void CovariantArgumentTest()
        {
            var generator = new GenericArgumentsGenerator();

            var genericArguments = new[] {new GenericArgument {Type = GenericArgumentType.Covariant, Name = "T"}};
            var result = generator.Generate(genericArguments);

            Assert.AreEqual("out T", result);
        }
        [Test]
        public void ContravariantArgumentTest()
        {
            var generator = new GenericArgumentsGenerator();

            var genericArguments = new[] {new GenericArgument {Type = GenericArgumentType.Contravariant, Name = "T"}};
            var result = generator.Generate(genericArguments);

            Assert.AreEqual("in T", result);
        }
        [Test]
        public void StandardArgumentTest()
        {
            var generator = new GenericArgumentsGenerator();

            var genericArguments = new[] {new GenericArgument {Type = GenericArgumentType.Standard, Name = "T"}};
            var result = generator.Generate(genericArguments);

            Assert.AreEqual("T", result);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new GenericArgumentsGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new GenericArgumentsGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate("Invalid"));
        }
    }
}