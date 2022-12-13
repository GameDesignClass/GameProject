using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class WorkRandomScene : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] public string[] scenarios = new string[] { "Your manager asked if you would be willing to take on an extra shift. You know you really have to study, but the extra money would be nice.", 
    "Your coworker just quit and your team is short staffed, the manager asks if you could work longer shifts", "An angry customer is insulting you and the spotlight is now on you."};

    [SerializeField] GameObject scene1;
    [SerializeField] GameObject scene2;
    [SerializeField] GameObject scene3;
    [SerializeField] GameObject scene4;

    Button buttonToDiasable1;
    Button buttonToDiasable2;
    //Button continueButton;

    float number;

    private PlayerUI status;

    
    void Awake()
    {
        //hi
        //Debug.Log("Awake");
        number = animCurve.Evaluate(Random.value);
    }

    void Start()
    {
        // if (continueButton == null)
        // {
        //     continueButton = GameObject.Find("Continue").GetComponent<Button>();
        // }

        if (status == null)
        {
            status = GameObject.Find("StatsUI").GetComponent<PlayerUI>();
        }

       

        //Load number between 0 & 2
        scenarioText.text = scenarios[(int)number];
        Debug.Log(number);
    
        // buttonYes.gameObject.SetActive(false);
        // buttonNo.gameObject.SetActive(false);
        scene1.gameObject.SetActive(false);
        scene2.gameObject.SetActive(false);
        scene3.gameObject.SetActive(false);
        scene4.gameObject.SetActive(false);
    }

    void Update()
    {
        if ((int)number == 0)
        {
            scene1.gameObject.SetActive(true);
        }
        else if ((int)number == 1)
        {
            scene2.gameObject.SetActive(true);
        }
        else if ((int)number == 2)
        {
            scene3.gameObject.SetActive(true);
        }
        else
        {
            scene4.gameObject.SetActive(true);
        }
    } 

    public void whenYes1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Studying is important, but you also need to have enough money to buy food. You trade potential study time for extra cash <br>  +15 Money <br> -15 Energy";
        status.UpdateStats("money", 15);
        status.UpdateStats("energy", -15);
        //continueButton.gameObject.SetActive(true);
        
    }

    public void whenNo1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You think about it and realize that studying is more important at the moment and that by valuing study time, is an even greater investment to your future.<br> +8 Money <br> -5 Energy";
        status.UpdateStats("money", 8);
        status.UpdateStats("energy", -5);
    }

    public void whenYes2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Work is just as important as school, you decide to help out your team and sacrifice time to study for that test.  <br>  +20 Money <br> -20 Energy <br> +7 Social";
        status.UpdateStats("money", 20);
        status.UpdateStats("energy", -20);
        status.UpdateStats("social", +7);
        
    }

    public void whenNo2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You really want to help, but picking up for a lost spot would come between time with your friends and studying, You decline helping out.<br> +5 Money <br> -3 Energy <br> +10 Social";
        status.UpdateStats("money", 5);
        status.UpdateStats("energy", -3);
        status.UpdateStats("social", +10);
    }

    public void whenYes3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "The manager rushes to help out! They commend you and you get a bonus for being an outstanding employee  <br>  +18 Money <br> -10 Energy <br> +12 Social";
        status.UpdateStats("money", 18);
        status.UpdateStats("energy", -10);
        status.UpdateStats("social", +12);
        
    }

    public void whenNo3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Your manager hears the commotion and rushes to see you getting beaten up pretty bad by the customer. You are sent home with docked pay and utter embarassment.<br> -20 Money <br> -20 Energy <br> -20 Social";
        status.UpdateStats("money", -20);
        status.UpdateStats("energy", -20);
        status.UpdateStats("social", -20);
    }

    public void Default()
    {
        buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        scenarioText.text = "A fine day at work!<br> +8 Money <br> -5 Energy";
    }
}
