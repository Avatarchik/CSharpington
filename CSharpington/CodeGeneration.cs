using System;

namespace Lasm.CSharpington
{
    public static class CodeGeneration
    {
        public static string Indent(int depth)
        {
            var indent = string.Empty;

            for (int i = 0; i < depth; i++)
            {
                indent += "    ";
            }

            return indent;
        }

        public static string BodyOpen(int depth)
        {
            var body = string.Empty;

            body += Indent(depth) + "{";
            
            return body;
        }

        public static string BodyClosed(int depth)
        {
            var body = string.Empty;

            body +=  Indent(depth) + "}";

            return body;
        }

        public static string MethodHeader(int depth, AccessModifier scope, MethodModifier modifier, Type returnType, string name)
        {
            var header = string.Empty;

            header += Indent(depth) + scope.ToString().ToLower() + " " + modifier.ToString().ToLower() +" " + returnType + " " + name + "(" + ")" ;

            return header;
        }

        public static string ConstructorHeader(int depth, string classType)
        {
            var header = string.Empty;

            header += Indent(depth) + "public " + classType + "(" + ")";

            return header;
        }

        public static string ClassHeader(int depth, AccessModifier scope, string classType)
        {
            var header = string.Empty;

            header += Indent(depth) + scope.ToString() + " class " + classType;

            return header;
        }
    }
}
