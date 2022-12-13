using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionsLeftChecker : MonoBehaviour
{
    public int playerActionsLeft;

    void Start()
    {
        playerActionsLeft = GameManager.instance.GetActionsLeft();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerActionsLeft <= 0)
       {
           SceneManager.LoadScene("Day Ended");
           GameManager.instance.ResetActions();
           GameManager.instance.ResetDays();
           GameManager.instance.NextSemester();
           GameManager.instance.EndGame();
       }
    }

    
}
