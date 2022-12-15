using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonFunc : MonoBehaviour
{
    private int playerActionsLeft;
    GameObject[] textBoxes;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Dropdown dropDown;

    void Start()
    {
        playerActionsLeft = GameManager.instance.GetActionsLeft();

        textBoxes = GameObject.FindGameObjectsWithTag("pop up box");

        foreach (GameObject textBox in textBoxes)
        {
            textBox.SetActive(false);
        }
    }

   public void StartGame()
   {
       SceneManager.LoadScene("Customize");
    //    GameManager.instance.tempSceneIndex =  GameManager.instance.currentSceneIndex;
    //    GameManager.instance.currentSceneIndex = SceneManager.LoadScene("Customize").buildIndex();
    //    GameManager.instance.previousSceneIndex = GameManager.instance.tempSceneIndex;
   }

   public void TitleScreen()
   {
       SceneManager.LoadScene("Title Screen");
    //    GameManager.instance.tempSceneIndex =  GameManager.instance.currentSceneIndex;
    //    GameManager.instance.currentSceneIndex = SceneManager.LoadScene("Title Screen").buildIndex();
    //    GameManager.instance.previousSceneIndex = GameManager.instance.tempSceneIndex;
   }

   public void Settings()
   {
       SceneManager.LoadScene("Settings");
   }

   public void FinishCustomize()
   {
       SceneManager.LoadScene("Instructions");
       string s = inputField.text;
       string z = dropDown.options[dropDown.value].text;
       GameManager.instance.SetName(s);
       GameManager.instance.SetMajor(z);
   }

   public void NextInstruction()
   {
       SceneManager.LoadScene("Instructions1");
   }

   public void MenuScene()
   {
       SceneManager.LoadScene("Menu");
   }

   public void EndDay()
   {
       GameManager.instance.SetActionsLeft(0);
       SceneManager.LoadScene("Day Ended");
   }

   public void Work()
   {
       SceneManager.LoadScene("Work");
   }

   public void School()
   {
       SceneManager.LoadScene("School");
   }

   public void Library()
   {
       SceneManager.LoadScene("Library");
   }

   public void Dorms()
   {
       SceneManager.LoadScene("Dorms");
   }

   public void Phone()
   {
       SceneManager.LoadScene("PhoneScreen");
   }

   public void NotableScores()
   {
       SceneManager.LoadScene("NotableScores");
   }

   public void changeSceneToStudy()
   {
    SceneManager.LoadScene("StudyMinigame");
   }

   public void changeSceneToBeerPong()
   {
    SceneManager.LoadScene("Beerpong game");
   }
   public void ChangeToWordy()
   {
       SceneManager.LoadScene("Wordy");
   }

//    public void DropOut()
//    {
//         foreach (GameObject child in textBoxes)
//         {
//             child.SetActive(true);
//             Debug.Log(child + " in button function");
//         }
//    }

   public void ConfirmDO()
   {
       SceneManager.LoadScene("Dropped Out");
   }

   public void CancelDO()
   {
       foreach (GameObject child in textBoxes)
        {
            child.SetActive(false);
        }
   }
}
