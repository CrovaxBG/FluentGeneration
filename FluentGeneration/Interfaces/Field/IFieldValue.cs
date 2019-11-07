using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldValue : IFluentLink<IField>
    {
        IField WithNoValue();
        IField WithValue(object value);
    }
}