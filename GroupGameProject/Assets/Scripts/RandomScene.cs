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
    [SerializeField] public string[] scenarios = new string[] { "Your manager asked if you would be willing to take on an extra shift. You know you really really have to study, but the extra money would be nice.", 
    "Your manager has offered you a promotion, but it does require you to take on an extra shift a week."};

    private Button button;

    float number;

    
    void Awake()
    {
        //Debug.Log("Awake");
        number = animCurve.Evaluate(Random.value);
    }

    void Start()
    {
       
        //Load number between 0 & 2
        //Debug.Log((int)number);

        if ((int)number == 0)
        {
            scenarioText.text = scenarios[0];
        }
        else if ((int)number == 1)
        {
            scenarioText.text = scenarios[1];
        }
        else if ((int)number == 2)
        {
            Debug.Log((int)number);
        }
    } 
}
