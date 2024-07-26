namespace InstagramBloksParser
{
    public class BloksNode
    {
        public string Key { get; set; }
        public List<BloksNode> Children { get; set; } = new List<BloksNode>();

        public BloksNode(string key)
        {
            Key = key;
        }

        public void AddChild(BloksNode child)
        {
            Children.Add(child);
        }

        public override string ToString()
        {
            return $"{Key}: [{string.Join(", ", Children)}]";
        }
    }
}
