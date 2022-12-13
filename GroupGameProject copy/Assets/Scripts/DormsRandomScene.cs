using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DormsRandomScene : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] private TextMeshProUGUI additionalText;
    [SerializeField] public string[] scenarios = new string[] { "Your food pantry is empty and you're hungry now. The market is just up the block but uber eats is always an option.", 
    "Your friends are asking to hang out, play board games, and spend some time away from studying and everything school/work related.", 
    "These past weeks are really getting to you, sleep sounds great but assignments are piling on high.",
    "You just reached home and your boss just called asking if you'd like to come into work for the evening. Rest would be ideal, but extra cash....",
    "PARTYYY!!!!!"};

    [SerializeField] GameObject scene1;
    [SerializeField] GameObject scene2;
    [SerializeField] GameObject scene3;
    [SerializeField] GameObject scene4;
    [SerializeField] GameObject scene5;

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
        scene5.gameObject.SetActive(false);
        GameManager.instance.UpdateActions(-1);
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
        else if ((int)number == 3)
        {
            scene4.gameObject.SetActive(true);
        }
        else
        {
            scene5.gameObject.SetActive(true);
        }
    } 

    public void whenYes1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Ordering online is expensive, you pick up some quick ingredients and whip up a meal that lasts for the rest of the week.<br>  -15 Money <br> -10 Energy";
        status.UpdateStats("money", -15);
        status.UpdateStats("energy", -10);
        
    }

    public void whenNo1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "It's so much easier to order food out. Though pricy, it was really good tasting. Wait.. is that a hair in your food?<br> -25 Money <br> -5 Energy";
        status.UpdateStats("money", -25);
        status.UpdateStats("energy", -5);
    }

    public void whenYes2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        int calculatedSocial = GameManager.instance.GetSocial();
        float rand = (float)Random.value;
        scenarioText.text = "The stress of school and work will always be there; you enjoy the night with your friends and have yourself a night to remember.<br> +25 Social <br> -18 Energy";
         if (calculatedSocial >= 50 && rand >= 0.4)
        {
            additionalText.text = "*BONUS*<br> Your crush came over and you woo'd them with your moxie. YOU DIRTY DOG!<br> +20 Social";
            status.UpdateStats("social", 20);
        }
        
        status.UpdateStats("energy", -18);
        status.UpdateStats("social", +25);
        
    }

    public void whenNo2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "The stress consumes you and you spend your time alone to get some rest. We all need time to ourselves but its always good to get out some time.<br>+20 Energy <br> -10 Social";
        status.UpdateStats("energy", 20);
        status.UpdateStats("social", -10);
    }

    public void whenYes3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Sleep..sounds..*YAWN*...*Snores* <br> Sleeping helps with brainflow and increasing focus onthose assignments that need it.<br>  +30 Energy";
        status.UpdateStats("energy", 30);
        
        
    }

    public void whenNo3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Tired as you are, staying on top of your work load is important. The decision between sleep and working is always an issue.<br>+5 Average <br>-20 Energy <br> +10 Sadness";
        status.UpdateStats("energy", -20);
        status.UpdateStats("average", +5);
    }

    public void whenYes4()
    {
        buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario4No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You're strapped on cash the next couple of weeks so you take the shift. Well, without money how will you eat, do laundry, or even get to go out.<br> +10 Money<br> -15 Energy";
        status.UpdateStats("money", +10);
        status.UpdateStats("energy", -15);
    }

    public void whenNo4()
    {
        buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario4No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You decline the shift. Grant it, you're tired enough with school and the work you've already done  for the week.<br>+5 Energy";
        status.UpdateStats("energy", -5);
    }

    public void PARTY()
    {
        SceneManager.LoadScene("Beerpong game");
    }
}
