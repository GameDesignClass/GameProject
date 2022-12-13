using UnityEngine;

public class WordleGameManager : MonoBehaviour
{
    public static WordleGameManager Instance;
    [SerializeField] string winningWord;
    string currentWord = "";
    bool isGameEnded = false;
    int tries = 6;
    WordsManager wordsManager;
    GameUIManager gameUIManager;
    ContainersManager containersManager;

    private void Start()
    {
        Instance = this;
        wordsManager = FindObjectOfType<WordsManager>();
        gameUIManager = FindObjectOfType<GameUIManager>();
        containersManager = FindObjectOfType<ContainersManager>();

        StartGame();
    }

    void StartGame()
    {
        isGameEnded = false;
        winningWord = wordsManager.GetRandomWord();
        containersManager.ClearContainers();
        tries = 6;
        currentWord = "";
        isGameEnded = false;
    }

    public void ResetGame()
    {
        if(isGameEnded)
        {
            StartGame();    
        }
    }

    void MoveToNextTry()
    {
        for(int i=0; i<5; i++)
        {
            if(IsLetterInRightPlace(i))
            {
                containersManager.SetLetterContainerColor(i, ColorDataStore.GetLetterInRightPlaceColor());
            }
            else if(IsLetterInWord(i))
                containersManager.SetLetterContainerColor(i, ColorDataStore.GetLetterInWordColor());
        }
        containersManager.MoveToNextContainer();
        currentWord = "";
        tries--;
        if(tries == 0)
        {
            GameLost();
        }
    }

    void GameWon()
    {
        isGameEnded = true;
        gameUIManager.ShowGameWonUIobject();
        containersManager.SetLetterContainersInRightPlaceColor();
    }

    void GameLost()
    {
        isGameEnded = true;
        gameUIManager.ShowGameLostUIobject(winningWord);
    }

    public void DeleteLetter()
    {
        if(isGameEnded) 
            return;

        if(currentWord.Length>0)
        {
            currentWord = currentWord.Remove(currentWord.Length - 1);
            containersManager.DeleteLastLetterContainer();
        }
    }
    public void AddLetter(string letter)
    {
        if(isGameEnded) 
            return;

        if(currentWord.Length<5)
        {
            letter = letter.ToLower();
            currentWord += letter;
            containersManager.AddContainerLetter(letter);
        }
    }
    public void SubmitWord()
    {
        if(isGameEnded) 
            return;

        if(currentWord.Length<5)
        {
            gameUIManager.ShowNotEnoughLettersUIobject();
            return;
        }

        if(!wordsManager.CheckIsWordValid(currentWord))
        {
            gameUIManager.ShowNotInListUIobject();
            return;
        }

        if(currentWord == winningWord)
            GameWon();
        else
            MoveToNextTry();
    }

    public bool IsLetterInRightPlace(int index)
    {
        return currentWord[index] == winningWord[index];
    }
    public bool IsLetterInWord(int index)
    {
        return winningWord.Contains(currentWord[index].ToString());
    }
}
