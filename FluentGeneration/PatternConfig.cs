namespace FluentGeneration
{
    public static class PatternConfig
    {
        public static string FieldPattern { get; set; } = @"
{[IFieldAttribute<>]}
{[IFieldAccessSpecifier<>]} {[IFieldAccessModifier<>]} {[IFieldType<>]} {[IFieldName<>]} {= [IFieldValue<>]};";

        public static string PropertyPattern { get; set; } = @"
{[IPropertyAttribute<>]}
{[IPropertyAccessSpecifier<>]} {[IPropertyAccessModifier<>]} {[IPropertyType<>]} {[IPropertyName<>]} 
{
    { [IGetAccessSpecifier<>]} {[IGetBody<>]}
    { [ISetAccessSpecifier<>]} {[ISetBody<>]}
} {= [IPropertyValue<>];}";

        public static string MethodPattern { get; set; } = @"
{[IMethodAttribute<>]}
{[IMethodAccessSpecifier<>]} {[IMethodAccessModifier<>]} {[IMethodType<>]} {[IMethodName<>]}({[IMethodParameters<>]}){[IMethodBody<>]}";
    }
}
