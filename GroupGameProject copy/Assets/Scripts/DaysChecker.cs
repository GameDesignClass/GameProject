using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaysChecker : MonoBehaviour
{
    public TextMeshProUGUI daysText;

    public int day;

    // Start is called before the first frame update
    void Start()
    {
        day = GameManager.instance.GetDayCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (day == 1)
        {
            daysText.text = "Day One";
        }
        else if (day == 2)
        {
            daysText.text = "Day Two";
        }
        else if (day == 3)
        {
            daysText.text = "Day Three";
        }
        else if (day == 4)
        {
            daysText.text = "Day Four";
        }
    }
}
