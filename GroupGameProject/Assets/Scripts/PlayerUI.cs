using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
   public TextMeshProUGUI averageText;
   public TextMeshProUGUI socialText;
   public TextMeshProUGUI moneyText;
   public TextMeshProUGUI energyText;
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
       GameManager.instance.average = average;
       social = 50; //represents friends or potentially people you know
       GameManager.instance.social = social;
       money = Random.Range(0, 35); //represents currency amount
       GameManager.instance.money = money;
       energy = 40; //reflects tiredness which goes down by each activity
       GameManager.instance.energy = energy;

       DisplayStats();
   }

   private void UpdateStats(string stat, int statsToAdd)
   {
       if (stat == "average")
       {
           average += statsToAdd;
           GameManager.instance.average += statsToAdd;
       } 
       else if (stat == "social")
       {
           social += statsToAdd;
           GameManager.instance.social += statsToAdd;
       }
       else if (stat == "money")
       {
           money += statsToAdd;
           GameManager.instance.money += statsToAdd;
       }
       else
       {
           energy += statsToAdd;
           GameManager.instance.energy += statsToAdd;
       }

       DisplayStats();
   }

   public void DisplayStats()
   {
       averageText.text = "Average: " + GameManager.instance.average + "/100";
       socialText.text = "Social: " + GameManager.instance.social + "/100";
       moneyText.text = "Money: " + GameManager.instance.money + "/100";
       energyText.text = "Energy: " + GameManager.instance.energy + "/100";
   }
}
