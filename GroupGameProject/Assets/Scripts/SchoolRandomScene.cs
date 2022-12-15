using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SchoolRandomScene : MonoBehaviour
{
   [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] private TextMeshProUGUI additionalText;
    [SerializeField] public string[] scenarios = new string[] { "You managed your time poorly, should you ask your professor for an extension on your essay?", 
    "Your Friends are cutting class to do things that kids do nowadays",
    "Your favorite pdf website got shut down, now you need to actually buy your own textbooks", 
    "A couple of people in your class are pooling money to pay someone for the upcoming test answers. "};

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

        scene1 = GameObject.Find("Scenario1");

       

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
        scenarioText.text = "The teacher was understanding and granted you with enough time to turn in a well developed essay. Good Job <br>  +15 Average <br> -15 Energy";
        status.UpdateStats("average", 15);
        status.UpdateStats("energy", -15);
        
    }

    public void whenNo1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You just turn in what you were able to and got a bad grade. Maybe next time ask for the extension, the wosrt they can do is say no.<br> -10 Average <br> -8 Energy";
        status.UpdateStats("average", -10);
        status.UpdateStats("energy", -8);
    }

    public void whenYes2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You ditch class and it just so happens that an important topic that was to be on the next exam was taught. You never know what may be taught next, next time you should go to class.  <br>  -15 Average <br> -10 Energy <br> +15 Social";
        status.UpdateStats("average", -15);
        status.UpdateStats("energy", -10);
        status.UpdateStats("social", +15);
        
    }

    public void whenNo2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        int calculatedAvg = GameManager.instance.GetAverage();
        scenarioText.text = "Just so happened that there was a pop quiz today! Going to class is very important and not even one should be missed! <br> +5 Average <br> -10 Energy <br> -7 Social";
        if (calculatedAvg > 50)
        {
            additionalText.text = "You aced the exam <br> +15 Average";
            status.UpdateStats("average", 15);
        }
        else{
            additionalText.text = "That exam kicked your butt. Study more and be ready for every exam! <br> -8 Average";
            status.UpdateStats("average", -8);
        }
        status.UpdateStats("average", 5);
        status.UpdateStats("energy", -10);
        status.UpdateStats("social", -7);
    }

    public void whenYes3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Wow, the professor's class is really textbook heavy. Buying the textbooks have helped you keep up with the class. <br>  -35 Money <br> +15 Average <br> -10 Energy";
        status.UpdateStats("money", -35);
        status.UpdateStats("energy", -10);
        status.UpdateStats("average", +15);
        
    }

    public void whenNo3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Oh no! There are topics you never heard of and you can't find a good video online! Though textbooks are tiresome and pricey, it's always a good idea to have.<br> -5 Average <br> -10 Energy";
        status.UpdateStats("average", -5);
        status.UpdateStats("energy", -10);
    }

    public void whenYes4()
    {
        buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario4No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        double rand = (double)Random.value;
        if (rand <= 0.6)
        {
            scenarioText.text = "You get the test answers and afterwards are called into the principal's office. You get caught but they have pity and only fail you for the test. Pity...<br> -30 Average<br> -10 Energy<br> -5 Social";
            status.UpdateStats("average", -30);
            status.UpdateStats("energy", -10);
            status.UpdateStats("social", -5);
        }
        else
        {
            scenarioText.text = "You get the test answers and pass. Cheating is risky and immoral and you lay low for a while, thinking about your actions...<br> +15 Average, -8 Energy<br> +30 Depression";
            status.UpdateStats("average", 15);
            status.UpdateStats("energy", -8);
        }
        
    }

    public void whenNo4()
    {
        buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario4No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        double rand = (double)Random.value;
        if (rand <= 0.5)
        {
            scenarioText.text = "You stand for academic integrity and good moral! You take the chance on the test on your own and do fairly average! Honesty is always the better choice.<br> +10 Average<br> -10 Energy<br> -15 Social";
            status.UpdateStats("average", +10);
            status.UpdateStats("energy", -10);
            status.UpdateStats("social", -15);
        }
        else
        {
            scenarioText.text = "You stand for academic integrity and good moral! You take the chance on the test on your own and pass with flying colours! Honesty is always the better choice.<br> +20 Average, -12 Energy";
            status.UpdateStats("average", 20);
            status.UpdateStats("energy", -12);
        }
        
    }

    public void Wordy()
    {
        SceneManager.LoadScene("Wordy");
    }
}
