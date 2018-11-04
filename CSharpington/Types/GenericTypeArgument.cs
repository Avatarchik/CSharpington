using Lasm.OdinSerializer;
using System;

namespace Lasm.CSharpington
{
    [Serializable]
    public class GenericTypeArgument
    {
        [OdinSerialize] public string name;
        [OdinSerialize] public Type @interface;
        [OdinSerialize] public Type baseType;
        [OdinSerialize] public GenericTypeArgument argument;
        [OdinSerialize] public TypeConstraint constraint;

        public void SetArgument()
        {
            if (argument != null)
            {
                argument.SetArgument();
            }
        }

        public string Generate()
        {
            var generate = string.Empty;

            generate += name;

            if (argument != null)
            {
                generate += "<";

                generate += argument.Generate();

                if (argument.argument != null)
                {
                    generate += ", ";
                }

                generate += ">";
            }

            return generate;
        }
    }
}