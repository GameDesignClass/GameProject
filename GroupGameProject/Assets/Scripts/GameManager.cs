using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Image image;
    public string playerName;
    public int playerAverage;
    public int playerSocial;
    public int playerMoney;
    public int playerEnergy;
    public string playerMajor;

    public int DEFAULT_ACTIONS_LEFT = 2;
    public int actionsLeft;
    public int MAX_DAYS = 4;
    public int dayCounter = 1;
    public int MAX_SEMESTERS = 2;
    public int semesterCounter = 1;
    

    public GameObject[] textBoxes;

    // public int currentSceneIndex;
    // public int previousSceneIndex;
    // public int tempSceneIndex;
//hi
    public Character[] characters;

    public Character currentCharacter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }

    private void Start(){
        playerName="";
        playerMajor="";
        playerAverage = -1;
        playerSocial = -1;
        playerEnergy = -1;
        playerMoney = -1;
        actionsLeft = DEFAULT_ACTIONS_LEFT;

        //if character not set to anything we set to first charcter in array
        if (characters.Length > 0 && currentCharacter == null)
        {
            currentCharacter = characters[0];
        }

        textBoxes = GameObject.FindGameObjectsWithTag("pop up box");
        foreach (GameObject child in textBoxes)
        {
            child.SetActive(false);
            //Debug.Log(child + " in button GameManager");
        }
        
    }

    public void SetCharacter(Character character)
    {
        currentCharacter = character;
    }

    public Character GetCharacter()
    {
        return currentCharacter;
    }

    public Sprite GetCharacterImage()
    {
        image = GetComponent<Image>();
        return image.sprite;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public string GetName()
    {
        return playerName;
    }

    public void SetMajor(string major)
    {
        playerMajor = major;
    }

    public string GetMajor()
    {
        return playerMajor;
    }

    public void SetAverage(int average)
    {
        playerAverage = average;
    }
    public int GetAverage()
    {
        return playerAverage;
    }

    public void SetMoney(int money)
    {
        playerMoney = money;
    }

    public int GetMoney()
    {
        return playerMoney;
    }

    public void SetSocial(int social)
    {
        playerSocial = social;
    }

    public int GetSocial()
    {
        return playerSocial;
    }

    public void SetEnergy(int energy)
    {
        playerEnergy = energy;
    }

    public int GetEnergy()
    {
        return playerEnergy;
    }

    public void SetActionsLeft(int actions)
    {
        actionsLeft = actions;
    }

    public int GetActionsLeft()
    {
        return actionsLeft;
    }

    public void UpdateActions(int actions)
    {
        actionsLeft += actions;
    }

    public void ResetActions()
    {
       actionsLeft = DEFAULT_ACTIONS_LEFT;
       dayCounter++;
    }

    public int GetDayCounter()
    {
        return dayCounter;
    }

    public void ResetDays()
    {
       if (dayCounter == MAX_DAYS+1)
       {
           dayCounter = 1;
       }
       
    }

    public int GetSemesterCounter()
    {
        return semesterCounter;
    }

    public void NextSemester()
    {
       if (dayCounter == MAX_DAYS)
       {
           semesterCounter++;
       }
    }

    public void EndGame()
    {
        if (semesterCounter == MAX_SEMESTERS+1)
        {
            SceneManager.LoadScene("EndGame");
        }
    }






    // public void SetCurrentScene()
    // {
    //     GameManager.instance.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    // }

    // public int GetCurrentScene()
    // {
    //     return GameManager.instance.currentSceneIndex;
    // }

    // public void SetPreviousScene(int currentScene)
    // {
    //     GameManager.instance.previousSceneIndex = currentScene;
    // }

    // public int GetPreviousScene()
    // {
    //     return GameManager.instance.previousSceneIndex;
    // }
}
