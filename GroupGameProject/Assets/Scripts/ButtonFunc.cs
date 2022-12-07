using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{
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

   public void MenuScene()
   {
       SceneManager.LoadScene("Menu");
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
   
}
