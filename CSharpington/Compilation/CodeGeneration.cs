using System;
using System.Collections.Generic;
using Lasm.UnityUtilities;
using System.Reflection;

namespace Lasm.CSharpington
{
    public static class CodeGeneration
    {
        public static List<Type> ToLowerReturnTypes = new List<Type>()
        {
            typeof(void),
            typeof(byte),
            typeof(double),
            typeof(float),
            typeof(string),
            typeof(object)
        };

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

            body += Indent(depth) + "}";

            return body;
        }

        public static string MethodHeader(int depth, AccessModifier scope, MethodModifier modifier, Type returnType, string name)
        {
            var header = string.Empty;
            string _modifier = modifier.ToString();
            string _scope = scope.ToString();
            string _returnType = returnType.Name.ToString();

            _scope = _scope.AddLowerUpperNeighboringSpaces();
            _scope = _scope.ToLower();

            _modifier = _modifier.ToLower();

            if (modifier == MethodModifier.None)
            {
                _modifier = string.Empty;
            }

            if (returnType.DeclaringType != returnType || returnType.DeclaringType != typeof(object))
            {
                if (ToLowerReturnTypes.Contains(returnType))
                {
                    _returnType = _returnType.ToLower();
                }
            }

            header += Indent(depth) + _scope + " " + _modifier + " " + _returnType + " " + name + "(" + ")";

            return header;
        }

        public static string ConstructorHeader(int depth, string classType)
        {
            var header = string.Empty;

            header += Indent(depth) + "public " + classType + "(" + ")";

            return header;
        }

        /// <summary>
        /// Create a class header line. Does not include brackets.
        /// </summary>
        public static string ClassHeader(int depth, AccessModifier scope, ClassModifier modifier, string @class, List<string> argumentNames)
        {
            // Set non string types to strings
            var header = string.Empty;
            string _modifier = modifier.ToString();
            string _scope = scope.ToString();

            // Add white spaces to types such as ProtectedInternal to Protected Internal and set all of it lowercase to match C# construct
            _scope = _scope.AddLowerUpperNeighboringSpaces();
            _scope = _scope.ToLower();

            // Do the same as with scope, except we may get addition white spaces for some reason. Remove them here.
            if (modifier != ClassModifier.None)
            {
                _modifier = _modifier.AddLowerUpperNeighboringSpaces();
                if (char.IsWhiteSpace(_modifier[_modifier.Length - 1])) _modifier.Remove(_modifier.Length - 1, 1);
                _modifier = _modifier.ToString().ToLower();
            } else
            {
                _modifier = string.Empty;
            }

            // Remove initial white spaces, we will do this ourselves where necessary
            if (char.IsWhiteSpace(@class[0])) @class.Remove(0, 1);

            header += Indent(depth) + _scope.ToLower() + " class " + _modifier + @class;
            
            // We dynamically create the Generics Arguments by manually creating all but the names, which are fed through this method.
            if (argumentNames != null)
            {
                if (argumentNames.Count > 0)
                {
                    header += "<";

                    for (int i = 0; i < argumentNames.Count; i++)
                    {
                        header += argumentNames[i];

                        if (i < argumentNames.Count - 1)
                        {
                            header += ", ";
                        }
                    }

                    header += ">";
                }
            }

            return header;
        }

        public static string FullGenericTypeName(this Type type)
        {
            var typeName = string.Empty;

            typeName += type.Name;

            if (type.GenericTypeArguments != null)
            {
                typeName += "<";

                for (int i = 0; i < type.GenericTypeArguments.Length; i++)
                {
                    typeName += type.GenericTypeArguments[i].FullGenericTypeName();
                    if (i != type.GenericTypeArguments.Length - 1)
                    {
                        typeName += ", ";
                    }
                }

                typeName += ">";
            }

            return typeName;
        }

        public static string GenericTypeConstraints(List<GenericTypeArgument> arguments)
        {
            var typeConstraints = string.Empty;

            for (int i = 0; i < arguments.Count; i++) {
                if (arguments.Count > 1)
                {
                    if (arguments[i].constraint != TypeConstraint.None)
                    {
                        typeConstraints += "\n";
                        typeConstraints += " where " + arguments[i].name;
                        
                        switch (arguments[i].constraint)
                        {
                            case TypeConstraint.Argument:
                                typeConstraints += " : " + arguments[i].argument.name;
                                break;
                            case TypeConstraint.BaseType:
                                typeConstraints += " : " + arguments[i].baseType.Name;
                                if (arguments[i].baseType.GenericTypeArguments.Length > 0) {
                                    arguments[i].baseType.FullGenericTypeName();
                                }
                                break;
                            case TypeConstraint.Class:
                                typeConstraints += " : " + "class";
                                break;
                            case TypeConstraint.Interface:
                                typeConstraints += " : " + arguments[i].baseType.Name;
                                if (arguments[i].baseType.GenericTypeArguments.Length > 0)
                                {
                                    arguments[i].baseType.FullGenericTypeName();
                                }
                                break;
                            case TypeConstraint.New:
                                typeConstraints += " : " + "new()";
                                break;
                            case TypeConstraint.Struct:
                                typeConstraints += " : " + "struct";
                                break;
                            case TypeConstraint.Unmanaged:
                                typeConstraints += " : " + "unmanaged";
                                break;
                        }
                    }
                }
                else
                {

                }
            }

            return typeConstraints;
        }

        public static string Attribute(int indent, System.Attribute attribute, string stringAttribute)
        {
            var attributeString = string.Empty;
            var _attribute = attribute.ToString();

            attributeString += Indent(indent);
            attributeString += "[";
            attributeString += _attribute;
            attributeString += "(";
            attributeString += @"""";
            attributeString += stringAttribute;
            attributeString += @"""";
            attributeString += ")";
            attributeString += "]";

            return attributeString;
        }

        public static string Reference(int indent, string @namespace)
        {
            var reference = string.Empty;

            reference += "using ";
            reference += @namespace;
            reference += ";";

            return reference;
        }

    }
}
