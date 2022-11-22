using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject musicObj = GameObject.FindGameObjectWithTag("Game Music");

        if (musicObj != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
