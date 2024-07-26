using System.Text.RegularExpressions;

namespace InstagramBloksParser
{
    public class BloksParser
    {

        private static readonly string RegexGroup1 = @"""[^""]*""";
        private static readonly string RegexGroup2 = @"\(([^()]*)\)";
        private static readonly string RegexGroup3 = @"[^(^),\s*]+";
        private static readonly string RegexPattern = @$"(?:{RegexGroup1}|{RegexGroup2}|{RegexGroup3})";

        public static BloksNode Parse(string input)
        {
            var matches = Regex.Matches(input, RegexPattern);
            Stack<BloksNode> stack = new Stack<BloksNode>();
            BloksNode? root = null;

            foreach (Match match in matches)
            {
                string value = match.Value;

                if (Regex.IsMatch(value, RegexGroup1) || Regex.IsMatch(value, RegexGroup2) || value == ")")
                {
                    if (stack.Count > 0)
                    {
                        BloksNode parent = stack.Peek();
                        parent.AddChild(new BloksNode(value));
                    }
                }
                else
                {
                    var newNode = new BloksNode(value);
                    if (stack.Count > 0)
                    {
                        BloksNode parent = stack.Peek();
                        parent.AddChild(newNode);
                    }
                    if (root == null)
                    {
                        root = newNode;
                    }
                    stack.Push(newNode);
                }

                if (value == ")")
                {
                    stack.Pop();
                }
            }

            return root;
        }
    }
}
