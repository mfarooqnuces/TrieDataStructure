namespace TrieDataStructure
{
    public class TrieNode
    {
        public TrieNode[] Children;
        public char Character;
        public bool IsEnd;

        public TrieNode()
        {
            Children = new TrieNode[26];
            Character = default;
            IsEnd = false;
        }
    }
}
