using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
   public TextMeshProUGUI averageText;
   public TextMeshProUGUI socialText;
   public TextMeshProUGUI moneyText;
   public TextMeshProUGUI energyText;
   public TextMeshProUGUI actionsLeftText;
   public int average, social, money, energy;  //These player stats max at 100
   public int playerAverage, playerSocial, playerMoney, playerEnergy;


   public Character c;

   private void Start() //Sets initial stats for player
   {
       if (GameManager.instance != null)
       {
           c = GameManager.instance.GetCharacter();
       }
       average = 100; //represents grade overall
       social = 50; //represents friends or potentially people you know
       money = Random.Range(0, 35); //represents currency amount
       energy = 40; //reflects tiredness which goes down by each activity
       if (GameManager.instance.GetEnergy() == -1)
       {
            GameManager.instance.SetEnergy(energy);
            GameManager.instance.SetAverage(average);
            GameManager.instance.SetSocial(social);
            GameManager.instance.SetMoney(money);
       }
      
        playerEnergy = GameManager.instance.GetEnergy();
        playerAverage = GameManager.instance.GetAverage();
        playerSocial = GameManager.instance.GetSocial();
        playerMoney = GameManager.instance.GetMoney();

       
       Debug.Log(playerEnergy);
       Debug.Log(energy);
       DisplayStats();
   }

   void Update()
   {
       DisplayStats();
   }

   public void UpdateStats(string stat, int statsToAdd)
   {
       if (stat == "average")
       {
           average += statsToAdd;
           playerAverage += statsToAdd;
           GameManager.instance.SetAverage(playerAverage);
       } 
       else if (stat == "social")
       {
           social += statsToAdd;
           playerSocial += statsToAdd;
           GameManager.instance.SetSocial(playerSocial);
       }
       else if (stat == "money")
       {
           money += statsToAdd;
           playerMoney += statsToAdd;
           GameManager.instance.SetMoney(playerMoney);
       }
       else
       {
           energy += statsToAdd;
           playerEnergy += statsToAdd;
           GameManager.instance.SetEnergy(playerEnergy);
       }

       DisplayStats();
   }

   public void DisplayStats()
   {
       averageText.text = "Average: " + GameManager.instance.GetAverage() + "/100";
       socialText.text = "Social: " + GameManager.instance.GetSocial() + "/100";
       moneyText.text = "Money: " + GameManager.instance.GetMoney() + "/100";
       energyText.text = "Energy: " + GameManager.instance.GetEnergy() + "/100";
       actionsLeftText.text = "Actions Left: " + GameManager.instance.GetActionsLeft() + "/2";
   }
}
