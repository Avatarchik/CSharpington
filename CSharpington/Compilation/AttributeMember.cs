
namespace Lasm.CSharpington
{
    public class AttributeMember
    {
        public string result;

        public AttributeMember(string member, string input)
        {
            result = CreateStringMember(member, input);
        }

        private string CreateStringMember(string member, string input)
        {
            var memberString = string.Empty;

            memberString += member;
            memberString += " = ";
            memberString += @"""";
            memberString += input;
            memberString += @"""";

            return memberString;
        }
    }
}
