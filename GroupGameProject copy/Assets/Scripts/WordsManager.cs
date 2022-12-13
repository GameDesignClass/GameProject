using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    public static WordsManager Instance;
    [SerializeField] TextAsset validWordsTextAsset;
    [SerializeField] TextAsset correctGuessWordsTextAsset;
    List<string> validWords;
    List<string> correctGuessWords;

    void Awake()
    {
        Instance = this;
        LoadFiles();
    }

    void LoadFiles()
    {
        validWords = TXTFileReader.GetStrings(validWordsTextAsset);
        correctGuessWords = TXTFileReader.GetStrings(correctGuessWordsTextAsset);
    }

    public bool CheckIsWordValid(string word)
    {
        return validWords.Contains(word) || correctGuessWords.Contains(word);
    }

    public string GetRandomWord()
    {
        return correctGuessWords[Random.Range(0, correctGuessWords.Count)];
    }
}
