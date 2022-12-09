using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Image image;
    public int playerAverage;
    public int playerSocial;
    public int playerMoney;
    public int playerEnergy;

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
        playerAverage = -1;
        playerSocial = -1;
        playerEnergy = -1;
        playerMoney = -1;

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
