using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class RandomScene : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] public string[] scenarios = new string[] { "Your manager asked if you would be willing to take on an extra shift. You know you really have to study, but the extra money would be nice.", 
    "Your manager has offered you a promotion, but it does require you to take on an extra shift a week.", "An angry customer is insulting you and the spotlight is now on you."};

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
            // buttonYes = GameObject.Find("Scenario1Yes").GetComponent<Button>();
            // buttonNo = GameObject.Find("Scenario1No").GetComponent<Button>();

            // buttonNo.gameObject.SetActive(true);
            // buttonYes.gameObject.SetActive(true);
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

    public void whenYes()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Studying is important, but you also need to have enough money to buy food. You trade potential study time for extra cash <br>  +15 Money <br> -10 Energy";
        status.UpdateStats("money", 15);
        status.UpdateStats("energy", -10);
        //continueButton.gameObject.SetActive(true);
        
    }

    public void whenNo()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You think about it and realize that studying is more important at the moment and that by valuing study time, is an even greater investment to your future.<br> +8 Money <br> -5 Energy";
        status.UpdateStats("money", 8);
        status.UpdateStats("energy", -5);
    }
}
