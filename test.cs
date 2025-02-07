// 520. Detect Capital
// Solved
// Easy
// Topics
// Companies
// We define the usage of capitals in a word to be right when one of the following cases holds:

// All letters in this word are capitals, like "USA".
// All letters in this word are not capitals, like "leetcode".
// Only the first letter in this word is capital, like "Google".
// Given a string word, return true if the usage of capitals in it is right.

 

// Example 1:

// Input: word = "USA"
// Output: true
// Example 2:

// Input: word = "FlaG"
// Output: false
 

// Constraints:

// 1 <= word.length <= 100
// word consists of lowercase and uppercase English letters.
public class Solution {
   public bool DetectCapitalUse(string word) {
       
        if (word == word.ToUpper()) {
            return true;
        }
        

        if (word == word.ToLower()) {
            return true;
        }
        
       
        if (word.Length >= 1 && char.IsUpper(word[0])) {
            string restoDaPalavra = word.Substring(1);
            if (restoDaPalavra == restoDaPalavra.ToLower()) {
                return true;
            }
        }
        
        //
        return false;
    }
}


// 521. Longest Uncommon Subsequence I
// Solved
// Easy
// Topics
// Companies
// Hint
// Given two strings a and b, return the length of the longest uncommon subsequence between a and b. If no such uncommon subsequence exists, return -1.

// An uncommon subsequence between two strings is a string that is a 
// subsequence
//  of exactly one of them.

 

// Example 1:

// Input: a = "aba", b = "cdc"
// Output: 3
// Explanation: One longest uncommon subsequence is "aba" because "aba" is a subsequence of "aba" but not "cdc".
// Note that "cdc" is also a longest uncommon subsequence.
// Example 2:

// Input: a = "aaa", b = "bbb"
// Output: 3
// Explanation: The longest uncommon subsequences are "aaa" and "bbb".
// Example 3:

// Input: a = "aaa", b = "aaa"
// Output: -1
// Explanation: Every subsequence of string a is also a subsequence of string b. Similarly, every subsequence of string b is also a subsequence of string a. So the answer would be -1.
public class Solution {
    public int FindLUSlength(string a, string b) {
        // Se as strings forem iguais, não há subsequência incomum
        if (a == b) {
            return -1;
        }
        
        // Caso contrário, a maior string é a subsequência incomum mais longa
        return Math.Max(a.Length, b.Length);
    }
}




// 522. Longest Uncommon Subsequence II
// Solved
// Medium
// Topics
// Companies
// Given an array of strings strs, return the length of the longest uncommon subsequence between them. If the longest uncommon subsequence does not exist, return -1.

// An uncommon subsequence between an array of strings is a string that is a subsequence of one string but not the others.

// A subsequence of a string s is a string that can be obtained after deleting any number of characters from s.

// For example, "abc" is a subsequence of "aebdc" because you can delete the underlined characters in "aebdc" to get "abc". Other subsequences of "aebdc" include "aebdc", "aeb", and "" (empty string).
 

// Example 1:

// Input: strs = ["aba","cdc","eae"]
// Output: 3
// Example 2:

// Input: strs = ["aaa","aaa","aa"]
// Output: -1
 

// Constraints:

// 2 <= strs.length <= 50
// 1 <= strs[i].length <= 10
// strs[i] consists of lowercase English letters.
using System;
using System.Linq;

public class Solution {
    public int FindLUSlength(string[] strs) {
        int maxLength = -1;

        // Para cada string no array
        for (int i = 0; i < strs.Length; i++) {
            bool isUncommon = true;

            // Verifica se a string atual é subsequência de qualquer outra string
            for (int j = 0; j < strs.Length; j++) {
                if (i != j && IsSubsequence(strs[i], strs[j])) {
                    isUncommon = false;
                    break;
                }
            }

            // Se for uma subsequência incomum, atualiza o comprimento máximo
            if (isUncommon) {
                maxLength = Math.Max(maxLength, strs[i].Length);
            }
        }

        return maxLength;
    }

    // Função para verificar se s é subsequência de t
    private bool IsSubsequence(string s, string t) {
        int i = 0, j = 0;
        while (i < s.Length && j < t.Length) {
            if (s[i] == t[j]) {
                i++;
            }
            j++;
        }
        return i == s.Length;
    }
}


// 523. Continuous Subarray Sum
// Solved
// Medium
// Topics
// Companies
// Given an integer array nums and an integer k, return true if nums has a good subarray or false otherwise.

// A good subarray is a subarray where:

// its length is at least two, and
// the sum of the elements of the subarray is a multiple of k.
// Note that:

// A subarray is a contiguous part of the array.
// An integer x is a multiple of k if there exists an integer n such that x = n * k. 0 is always a multiple of k.
 

// Example 1:

// Input: nums = [23,2,4,6,7], k = 6
// Output: true
// Explanation: [2, 4] is a continuous subarray of size 2 whose elements sum up to 6.
// Example 2:

// Input: nums = [23,2,6,4,7], k = 6
// Output: true
// Explanation: [23, 2, 6, 4, 7] is an continuous subarray of size 5 whose elements sum up to 42.
// 42 is a multiple of 6 because 42 = 7 * 6 and 7 is an integer.
// Example 3:

// Input: nums = [23,2,6,4,7], k = 13
// Output: false
 

// Constraints:

// 1 <= nums.length <= 105
// 0 <= nums[i] <= 109
// 0 <= sum(nums[i]) <= 231 - 1
// 1 <= k <= 231 - 1
using System;
using System.Collections.Generic;

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        if (nums == null || nums.Length < 2) {
            return false;
        }

        if (k == 0) {
            for (int i = 0; i < nums.Length - 1; i++) {
                if (nums[i] == 0 && nums[i + 1] == 0) {
                    return true;
                }
            }
            return false;
        }

   
        Dictionary<int, int> remainderMap = new Dictionary<int, int>();
        remainderMap.Add(0, -1); 
        int currentSum = 0;

        for (int i = 0; i < nums.Length; i++) {
            currentSum += nums[i];
            int remainder = currentSum % k;

            if (remainderMap.ContainsKey(remainder)) {
          
                if (i - remainderMap[remainder] >= 2) {
                    return true;
                }
            } else {
                // If the remainder is new, add it to the dictionary.
                remainderMap.Add(remainder, i);
            }
        }

        return false;
    }
}


// 524. Longest Word in Dictionary through Deleting
// Solved
// Medium
// Topics
// Companies
// Given a string s and a string array dictionary, return the longest string in the dictionary that can be formed by deleting some of the given string characters. If there is more than one possible result, return the longest word with the smallest lexicographical order. If there is no possible result, return the empty string.

 

// Example 1:

// Input: s = "abpcplea", dictionary = ["ale","apple","monkey","plea"]
// Output: "apple"
// Example 2:

// Input: s = "abpcplea", dictionary = ["a","b","c"]
// Output: "a"
 

// Constraints:

// 1 <= s.length <= 1000
// 1 <= dictionary.length <= 1000
// 1 <= dictionary[i].length <= 1000
// s and dictionary[i] consist of lowercase English letters.
using System;
using System.Collections.Generic; // Important: Include this for IList

public class Solution {
    public string FindLongestWord(string s, IList<string> dictionary) { // Changed to IList<string>
        string longestWord = "";

        foreach (string word in dictionary) { // Iteration works the same with IList
            if (IsSubsequence(s, word)) {
                if (word.Length > longestWord.Length || (word.Length == longestWord.Length && word.CompareTo(longestWord) < 0)) {
                    longestWord = word;
                }
            }
        }

        return longestWord;
    }

    private bool IsSubsequence(string s, string word) {
        int sIndex = 0;
        int wordIndex = 0;

        while (sIndex < s.Length && wordIndex < word.Length) {
            if (s[sIndex] == word[wordIndex]) {
                wordIndex++;
            }
            sIndex++;
        }

        return wordIndex == word.Length;
    }
}


// 525. Contiguous Array
// Solved
// Medium
// Topics
// Companies
// Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.

 

// Example 1:

// Input: nums = [0,1]
// Output: 2
// Explanation: [0, 1] is the longest contiguous subarray with an equal number of 0 and 1.
// Example 2:

// Input: nums = [0,1,0]
// Output: 2
// Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
 

// Constraints:

// 1 <= nums.length <= 105
// nums[i] is either 0 or 1.
using System;
using System.Collections.Generic;

public class Solution {
    public int FindMaxLength(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }

        int maxLength = 0;
        Dictionary<int, int> sumMap = new Dictionary<int, int>();
        sumMap[0] = -1; 
        int currentSum = 0;

        for (int i = 0; i < nums.Length; i++) {
            currentSum += (nums[i] == 0 ? -1 : 1); 

            if (sumMap.ContainsKey(currentSum)) {
                maxLength = Math.Max(maxLength, i - sumMap[currentSum]);
            } else {
                sumMap[currentSum] = i;
            }
        }

        return maxLength;
    }
}


// 526. Beautiful Arrangement
// Solved
// Medium
// Topics
// Companies
// Suppose you have n integers labeled 1 through n. A permutation of those n integers perm (1-indexed) is considered a beautiful arrangement if for every i (1 <= i <= n), either of the following is true:

// perm[i] is divisible by i.
// i is divisible by perm[i].
// Given an integer n, return the number of the beautiful arrangements that you can construct.

 

// Example 1:

// Input: n = 2
// Output: 2
// Explanation: 
// The first beautiful arrangement is [1,2]:
//     - perm[1] = 1 is divisible by i = 1
//     - perm[2] = 2 is divisible by i = 2
// The second beautiful arrangement is [2,1]:
//     - perm[1] = 2 is divisible by i = 1
//     - i = 2 is divisible by perm[2] = 1
// Example 2:

// Input: n = 1
// Output: 1
 

// Constraints:

// 1 <= n <= 15
public class Solution {
    private int count;

    public int CountArrangement(int n) {
        count = 0;
        int[] perm = new int[n + 1];
        bool[] used = new bool[n + 1];
        GeneratePermutations(n, 1, perm, used);
        return count;
    }

    private void GeneratePermutations(int n, int index, int[] perm, bool[] used) {
        if (index > n) {
            count++;
            return;
        }

        for (int i = 1; i <= n; i++) {
            if (!used[i] && (i % index == 0 || index % i == 0)) {
                perm[index] = i;
                used[i] = true;
                GeneratePermutations(n, index + 1, perm, used);
                used[i] = false;
            }
        }
    }
}