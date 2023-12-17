namespace TrieDataStructure
{
    public static class TrieNodeOperation
    {
        public static void Insert(TrieNode root, string key)
        {
            TrieNode currentNode = root; // Initialize the currentNode pointer with the root node 

            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i] - 'a';

                if (currentNode.Children[index] == null) // Check if the node exist for the current character in the Trie. 
                {
                    TrieNode newNode = new()
                    {
                        Character = key[i]
                    };
                    currentNode.Children[index] = newNode; // Keep the reference for the newly created
                }

                currentNode = currentNode.Children[index]; // Now, move the current node pointer to the newly created node. 
            }

            currentNode.IsEnd = true;
        }

        public static bool IsPrefixExist(TrieNode root, string key)
        {
            TrieNode currentNode = root; // Initialize the currentNode pointer with the root node 
            int i = 0;
            foreach (char c in key) // Iterate across the length of the string 
            {
                int index = key[i++] - 'a';
                if (currentNode == null || currentNode.Children == null) // Check if the node exist for the current character in the Trie. 
                {
                    return false; // Given word as a prefix does not exist in Trie 
                }

                currentNode = currentNode.Children[index]; // Move the currentNode pointer to the already existing node for current character. 
            }

            return currentNode != null; // Prefix exist in the Trie 
        }

        public static bool SearchKey(TrieNode root, string key)
        {
            TrieNode currentNode = root; // Initialize the currentNode pointer with the root node
            int i = 0;
            foreach (char c in key) // Iterate across the length of the string 
            {
                int index = key[i++] - 'a';
                if (currentNode == null || currentNode.Children == null) // Check if the node exist for the current character in the Trie 
                {
                    return false; // Given word does not exist in Trie 
                }

                currentNode = currentNode.Children[index]; // Move the currentNode pointer to the already existing node for current character 
            }

            return currentNode?.IsEnd ?? false; // Return if the WordCount is greater than 0 
        }

        public static bool DeleteKey(TrieNode root, string word)
        {
            TrieNode currentNode = root;
            TrieNode lastBranchNode = null;
            char lastBranchChar = 'a';

            int j = 0;
            foreach (char c in word) // loop through each character in the word
            {
                int index = word[j++] - 'a';
                if (currentNode == null || currentNode.Children == null) // if the current node doesn't have a child with the current character, return False as the word is not present in Trie 
                {
                    return false;
                }
                else
                {
                    int count = 0;

                    for (int i = 0; i < 26; i++) // count the number of Children nodes of the current node 
                    {
                        if (currentNode.Children[i] != null)
                        {
                            count++;
                        }
                    }

                    if (count > 1) // if the count of Children is more than 1, store the node and the current character 
                    {
                        lastBranchNode = currentNode;
                        lastBranchChar = c;
                    }

                    currentNode = currentNode.Children[index];
                }
            }

            if (!currentNode.IsEnd) // Case 1: The deleted word is a prefix of other words in Trie 
            {
                currentNode.IsEnd = false;
                return true;
            }

            if (lastBranchNode != null) // Case 2: The deleted word shares a common prefix with other words in Trie 
            {
                lastBranchNode.Children[lastBranchChar - 'a'] = null;
                return true;
            }
            else // Case 3: The deleted word does not share any common prefix with other words in Trie 
            {
                root.Children[word[0] - 'a'] = null;
                return true;
            }
        }

        public static void DisplayMessage(string message, bool IsSuccessfull = true)
        {
            if (IsSuccessfull)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message); // The query string is not present in the Trie 
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message); // The query string is not present in the Trie 
                Console.ResetColor();
            }
        }
    }
}
