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

       DisplayStats();
   }

   private void UpdateStats(string stat, int statsToAdd)
   {
       if (stat == "average")
       {
           average += statsToAdd;
       } 
       else if (stat == "social")
       {
           social += statsToAdd;
       }
       else if (stat == "money")
       {
           money += statsToAdd;
       }
       else
       {
           energy += statsToAdd;
       }

       DisplayStats();
   }

   public void DisplayStats()
   {
       averageText.text = "Average: " + average + "/100";
       socialText.text = "Social: " + social + "/100";
       moneyText.text = "Money: " + money + "/100";
       energyText.text = "Energy: " + energy + "/100";
   }
}
