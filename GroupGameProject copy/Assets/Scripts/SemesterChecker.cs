using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SemesterChecker : MonoBehaviour
{
    public TextMeshProUGUI semesterText;

    public int semester;

    // Start is called before the first frame update
    void Start()
    {
        semester = GameManager.instance.GetSemesterCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (semester == 1)
        {
            semesterText.text = "Semester One";
        }
        else if (semester == 2)
        {
            semesterText.text = "Semester Two";
        }
    }
}
