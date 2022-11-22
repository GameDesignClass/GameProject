using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public int targetScore = 20;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
            Vector2 position = new Vector2(Random.Range(-5,5), Random.Range(1,4));
            Instantiate(ball, position, Quaternion.identity);
    }

    public void StopSpawn()
    {
        CancelInvoke();
    }

    public void SpawnSpeedUp()
    {
        Time.timeScale = 2f;
    }
}
