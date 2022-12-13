using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LibraryRandomScene : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] private TextMeshProUGUI additionalText;
    [SerializeField] public string[] scenarios = new string[] { "Walking throughout the library you find a wallet on the ground that's stashed with cash and a school id.", 
    "You have a test on coming up, but you just don’t feel like studying. I mean, work and classes have been overwhelming as is...", 
    "One of your friends has invited you to join their study group, should you join?",
    "TIME TO STUDY!!"};

    [SerializeField] GameObject scene1;
    [SerializeField] GameObject scene2;
    [SerializeField] GameObject scene3;
    [SerializeField] GameObject scene4;
    //[SerializeField] GameObject scene5;

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

       //continueButton = GameObject.Find("Continue").GetComponent<Button>();

        //Load number between 0 & 2
        scenarioText.text = scenarios[(int)number];
        //Debug.Log(number);
    
        // buttonYes.gameObject.SetActive(false);
        // buttonNo.gameObject.SetActive(false);
        scene1.gameObject.SetActive(false);
        scene2.gameObject.SetActive(false);
        scene3.gameObject.SetActive(false);
        scene4.gameObject.SetActive(false);
       // scene5.gameObject.SetActive(false);
       //continueButton.gameObject.SetActive(false);
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
        // else
        // {
        //     scene5.gameObject.SetActive(true);
        // }
    } 

    public void whenYes1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "The people in the library see your deed and report you to capmus security. They have no idea how much money you took so they take what's in your pockets scold you. Do the right thing next time.<br>  -30 Money <br> -10 Energy <br> -30 Nobility";
        status.UpdateStats("money", -30);
        status.UpdateStats("energy", -10);
    }

    public void whenNo1()
    {
        buttonToDiasable1 = GameObject.Find("Scenario1Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario1No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Finally! The owner has been searching for hours for their wallet. Money is important but being a moral person is better.<br>The best stat earned is a job well done :)";
        additionalText.text = "*User won't forget that*";
    }

    public void whenYes2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        int calculatedAvg = GameManager.instance.GetAverage();
        float rand = (float)Random.value;
        scenarioText.text = "One coffee turns to two, three, at this point you've read the chapters about three times over. Coffee at night might not be a good idea but sometimes you need to study..<br>-20 Energy";
         if (rand >= 0.3)
        {
            additionalText.text = "Oh No! You crashed from coffee overdose! Coffee is a drug and must be abolished!<br> -10 Energy";
            status.UpdateStats("energy", -10);
        }
        
        status.UpdateStats("energy", -20);
        
    }

    public void whenNo2()
    {
        buttonToDiasable1 = GameObject.Find("Scenario2Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario2No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        int calculatedAvg = GameManager.instance.GetAverage();
        float rand = (float)Random.value;
        scenarioText.text = "Instead of studying, you relax and dose off into a great sleep with hopes that you are prepared enough for the test<br>+20 Energy";
        if (calculatedAvg <= 40 || rand <= 0.4)
        {
            additionalText.text = "Darn, the test was heavy on the topic you never caught a good grasp on<br>-10 Average";
            status.UpdateStats("average", -10);
        }
        else
        {
            additionalText.text = "What luck, the test was on topics you already had a firm grasp on. Might not be so lucky next time<br> +10 Average";
            status.UpdateStats("average", +10);
        }
        status.UpdateStats("energy", 20);
    }

    public void whenYes3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "Success! Studying in a larger group can help figure out topics you would've never gotten on your own.<br>  +10 Average<br> +10 Social";
        status.UpdateStats("average", 10);
        status.UpdateStats("social", 10);
    }

    public void whenNo3()
    {
        buttonToDiasable1 = GameObject.Find("Scenario3Yes").GetComponent<Button>();
        buttonToDiasable2 = GameObject.Find("Scenario3No").GetComponent<Button>();
        buttonToDiasable1.enabled = false;
        buttonToDiasable2.enabled = false;
        scenarioText.text = "You decline and study on your own. Struggle as it was, it took you nearly half the day to only go through half the topics. Studying in groups is a helpful way of understanding more topics and possibly discovering new ways to look at a topic.<br>+5 Average <br>-20 Energy <br> -5 Social";
        status.UpdateStats("energy", -20);
        status.UpdateStats("average", +5);
        status.UpdateStats("social", -5);
    }

    // public void whenYes4()
    // {
    //     buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
    //     buttonToDiasable2 = GameObject.Find("Scenario4No").GetComponent<Button>();
    //     buttonToDiasable1.enabled = false;
    //     buttonToDiasable2.enabled = false;
    //     scenarioText.text = "You're strapped on cash the next couple of weeks so you take the shift. Well, without money how will you eat, do laundry, or even get to go out.<br> +10 Money<br> -15 Energy";
    //     status.UpdateStats("money", +10);
    //     status.UpdateStats("energy", -15);
    // }

    // public void whenNo4()
    // {
    //     buttonToDiasable1 = GameObject.Find("Scenario4Yes").GetComponent<Button>();
    //     buttonToDiasable2 = GameObject.Find("Scenario4No").GetComponent<Button>();
    //     buttonToDiasable1.enabled = false;
    //     buttonToDiasable2.enabled = false;
    //     scenarioText.text = "You decline the shift. Grant it, you're tired enough with school and the work you've already done  for the week.<br>+5 Energy";
    //     status.UpdateStats("energy", -5);
    // }

    public void TIMETOSTUDY()
    {
        SceneManager.LoadScene("StudyMinigame");
    }
}
