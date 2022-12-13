using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{

    GameObject[] textBoxes;

    void Start()
    {
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

   public void FinishCustomize()
   {
       SceneManager.LoadScene("Instructions");
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

   public void changeSceneToStudy()
   {
    SceneManager.LoadScene("StudyMinigame");
   }

   public void changeSceneToBeerPong()
   {
    SceneManager.LoadScene("Beerpong game");
   }

   public void DropOut()
   {
        foreach (GameObject child in textBoxes)
        {
            child.SetActive(true);
            Debug.Log(child + " in button function");
        }
   }

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
