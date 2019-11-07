using FluentGeneration.Generators;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClass : IGeneratedObject, IFluentLink<IFile>, IEndable<IFile>,
        IBeginable<IClassAccessSpecifier>
    {

    }

    public interface IFile : IGeneratedObject
    {

    }

    public class File : IFile, IBuildable
    {
        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public string Build()
        {
            //Data = Generator.Generate();
            return Data;
        }
    }
}
