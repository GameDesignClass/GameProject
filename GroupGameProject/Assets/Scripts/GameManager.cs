using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Image image;
    public int average;
    public int social;
    public int money;
    public int energy;

    // public int currentSceneIndex;
    // public int previousSceneIndex;
    // public int tempSceneIndex;

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
        //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if character not set to anything we set to first charcter in array
        if (characters.Length > 0 && currentCharacter == null)
        {
            currentCharacter = characters[0];
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
