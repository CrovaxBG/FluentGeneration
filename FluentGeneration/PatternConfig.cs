namespace FluentGeneration
{
    public static class PatternConfig
    {
        public static string FieldPattern { get; set; } = @"
{[IFieldAttribute<>]}
{[IFieldAccessSpecifier<>]} {[IFieldAccessModifier<>]} {[IFieldType<>]} {[IFieldName<>]} {= [IFieldValue<>]};";
    }
}
