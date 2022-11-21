using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject spawn, start;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        start.SetActive(false);
        spawn.SetActive(true);
    }
}
