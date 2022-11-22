using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Spawner spawn;
    public TextMeshProUGUI text;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameoverText;
    public float timer = 60;
    public GameObject gameover;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score.ToString();
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + timer.ToString();
        if(timer<=30f)
        {
            spawn.SpawnSpeedUp();
        }
        if(timer<=0f)
        {
            timerEnd();
            spawn.StopSpawn();
            gameoverText.text = "GAME OVER! Your Score:" +score.ToString();
        }
        if(score == spawn.targetScore)
        {
            timerEnd();
            spawn.StopSpawn();
            gameoverText.text = "GAME OVER! You hit the MAX Score!";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="ball")
        {
            score +=1;
            Destroy(other.gameObject);
        }
    }

    public void timerEnd()
    {
        timer = 0;
        timerText.text = "Timer: " + timer.ToString();
        gameover.SetActive(true);
    }

}
