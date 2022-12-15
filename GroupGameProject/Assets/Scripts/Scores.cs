using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
   const int NUM_HIGH_SCORES = 5;
    const string NAME_KEY = "Player";
    const string AVERAGE_KEY = "Average";
    const string SOCIAL_KEY = "Social";
    const string MONEY_KEY = "Money";
    const string ENERGY_KEY = "Energy";
    const string MAJOR_KEY = "Major";

    [SerializeField] string playerName;
    [SerializeField] int playerAverage;
    [SerializeField] int playerSocial;
    [SerializeField] int playerMoney;
    [SerializeField] int playerEnergy;
    [SerializeField] string playerMajor;

    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] avgTexts;
    [SerializeField] TextMeshProUGUI[] socialTexts;
    [SerializeField] TextMeshProUGUI[] moneyTexts;
    [SerializeField] TextMeshProUGUI[] energyTexts;
    [SerializeField] TextMeshProUGUI[] majorTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = GameManager.instance.GetName();
        playerAverage = GameManager.instance.GetAverage();
        playerSocial = GameManager.instance.GetSocial();
        playerMoney = GameManager.instance.GetMoney();
        playerEnergy = GameManager.instance.GetEnergy();
        playerMajor = GameManager.instance.GetMajor();
    
        SaveHighScores();
        ShowHighScores();
    }

    public void SaveHighScores()
    {
        for (int i = 0; i <= NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentAverageKey = AVERAGE_KEY + i;
            string currentSocialKey = SOCIAL_KEY + i;
            string currentMoneyKey = MONEY_KEY + i;
            string currentEnergyKey = ENERGY_KEY + i;
            string currentMajorKey = MAJOR_KEY + i;

            if (PlayerPrefs.HasKey(currentNameKey) && PlayerPrefs.HasKey(currentMajorKey))
            {

                int currentAverage = PlayerPrefs.GetInt(currentAverageKey);
                int currentSocial = PlayerPrefs.GetInt(currentSocialKey);
                int currentMoney = PlayerPrefs.GetInt(currentMoneyKey);
                int currentEnergy = PlayerPrefs.GetInt(currentEnergyKey);

                if (playerAverage > currentAverage || playerSocial > currentSocial || playerEnergy > currentEnergy || playerMoney > currentMoney)
                {
                    int tempAvg = currentAverage;
                    int tempSoc = currentSocial;
                    int tempMoney = currentMoney;
                    int tempEn = currentEnergy;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey,playerName);
                    PlayerPrefs.SetInt(currentAverageKey, playerAverage);
                    PlayerPrefs.SetInt(currentSocialKey, playerSocial);
                    PlayerPrefs.SetInt(currentMoneyKey, playerMoney);
                    PlayerPrefs.SetInt(currentEnergyKey, playerEnergy);

                    playerName = tempName;
                    playerSocial = tempSoc;
                    playerMoney = tempMoney;;
                    playerEnergy = tempEn; 

                }
            }
            else{
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentAverageKey, playerAverage);
                PlayerPrefs.SetInt(currentSocialKey, playerSocial);
                PlayerPrefs.SetInt(currentMoneyKey, playerMoney);
                PlayerPrefs.SetInt(currentEnergyKey, playerEnergy);
                return;
            }
        }
    }

    public void ShowHighScores(){
        for(int i = 0; i < NUM_HIGH_SCORES; i++) {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + (i+1));
            avgTexts[i].text = PlayerPrefs.GetInt(AVERAGE_KEY + (i+1)).ToString();
            socialTexts[i].text = PlayerPrefs.GetInt( SOCIAL_KEY + (i+1)).ToString();
            moneyTexts[i].text = PlayerPrefs.GetInt(MONEY_KEY + (i+1)).ToString();
            energyTexts[i].text = PlayerPrefs.GetInt(SOCIAL_KEY + (i+1)).ToString();
        }
    }
}
