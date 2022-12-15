using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    public static AudioManager instance;

    //Use key to save stats into player prefs
    public const string MUSIC_KEY = "musicVolume";
  
   

    void Awake() //Saves sound volume between scenes 
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void Start()
    {
        LoadVolume();
    }

    void LoadVolume()   //VolumeSettings saved in VolumeSettings with OnDisable function
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);


        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);

    }
}
