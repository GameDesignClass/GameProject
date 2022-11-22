using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{
   public void StartGame()
   {
       SceneManager.LoadScene("Scene1");
   }

   public void FinishCustomize()
   {
       SceneManager.LoadScene("Scene2");
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
