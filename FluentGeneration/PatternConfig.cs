namespace FluentGeneration
{
    public static class PatternConfig
    {
        public static string FieldPattern { get; set; } = @"
{[IFieldAttribute]
}{[IFieldAccessSpecifier]} {[IFieldAccessModifier]} {[IFieldType]} {[IFieldName]} {= [IFieldValue]};";

        public static string PropertyPattern { get; set; } = @"
{[IPropertyAttribute<>]
}{[IPropertyAccessSpecifier<>]} {[IPropertyAccessModifier<>]} {[IPropertyType<>]} {[IPropertyName<>]} { { [IGetAccessSpecifier<>]} {[IGetBody<>]} { [ISetAccessSpecifier<>]} {[ISetBody<>]} } {= [IPropertyValue<>];}";

        public static string MethodPattern { get; set; } = @"
{[IMethodAttribute<>]
}{[IMethodAccessSpecifier<>]} {[IMethodAccessModifier<>]} {[IMethodType<>]} {[IMethodName<>]}{<[IMethodGenericArguments<>]>}({[IMethodParameters<>]}){
    [IMethodGenericArgumentsConstraints<>]}{[IMethodBody<>]}";

        public static string ClassPattern { get; set; } = @"
{[IClassNamespace]}
{
{[IClassUsingDirectives]}
{[IClassAttribute]
}{[IClassAccessSpecifier]} {[IClassType] }class {[IClassName]}{<[IClassGenericArguments]>} {: [IClassInheritance]} {
    [IClassGenericArgumentsConstraints]}
{[IClassBody]}
}
";

        public static string InterfacePattern { get; set; } = @"
{[IInterfaceNamespace]}
{
{[IInterfaceUsingDirectives]}
{[IInterfaceAttribute]
}{[IInterfaceAccessSpecifier]} interface {[IInterfaceName]}{<[IInterfaceGenericArguments]>} {: [IInterfaceInheritance]} {
    [IInterfaceGenericArgumentsConstraints]}
{[IInterfaceBody]}
}
";

        public static string ClassBodyPattern { get; set; } = @"{
{[IField]}{[IProperty<>]}{[IMethod<>]}
}";

        public static string InterfaceBodyPattern { get; set; } = @"{
{[IProperty<>]}{[IMethod<>]}
}";

        public static string FileBodyPattern { get; set; } = @"{[IInterface]}{[IClass]}";
    }
}
