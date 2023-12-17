using TrieDataStructure;

TrieNode root = new();

Console.WriteLine("*********************************** Insertion ***********************************");
string[] inputStrings = ["and", "ant", "do", "geek", "dad", "ball"];

foreach (string str in inputStrings)
{
    TrieNode.Insert(root, str);
    TrieNode.DisplayMessage($"Inserted String: '{str}'", IsSuccessfull: true);
}

Console.WriteLine("\n*********************************** String Search ***********************************");
string[] searchQueryStrings = ["do", "geek", "bat"];

foreach (string str in searchQueryStrings)
{
    Console.WriteLine("Query String: " + str);
    if (TrieNode.SearchKey(root, str))
    {
        TrieNode.DisplayMessage($"The query string '{str}' is present in the Trie", IsSuccessfull: true);
    }
    else
    {
        TrieNode.DisplayMessage($"The query string '{str}' is not present in the Trie", IsSuccessfull: false);
    }
}

Console.WriteLine("\n*********************************** PreFix Search ***********************************");
string[] searchQueryPreFixStrings = ["d", "ge", "bat"];

foreach (string str in searchQueryPreFixStrings)
{
    Console.WriteLine("Query String Prefix: " + str);
    if (TrieNode.IsPrefixExist(root, str))
    {
        TrieNode.DisplayMessage($"The PreFix string '{str}' is present in the Trie", IsSuccessfull: true);
    }
    else
    {
        TrieNode.DisplayMessage($"The PreFix string '{str}' is not present in the Trie", IsSuccessfull: false);
    }
}

Console.WriteLine("\n*********************************** Deletion ***********************************");
string[] deleteQueryStrings = ["geek", "tea"];

foreach (string str in deleteQueryStrings)
{
    Console.WriteLine("Query String: " + str);
    if (TrieNode.DeleteKey(root, str))
    {
        TrieNode.DisplayMessage($"String '{str}' deleted successfully", IsSuccessfull: true);
    }
    else
    {
        TrieNode.DisplayMessage($"String '{str}' is not present in the Trie", IsSuccessfull: false);
    }
}

Console.ReadKey();
