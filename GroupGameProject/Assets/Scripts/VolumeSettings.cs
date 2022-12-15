using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    

    public const string MIXER_MUSIC = "MusicVolume";

   
    void Awake() // Changes volumes
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
     
    }

    void Start() //updates volume to loaded volume loaded by load volume in AudioManager
    {
        // sets volume to 1f if volume not retrieved
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f); 
       
    }

    //when scene exited, saves volume values
    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
  
    }

    // Sets volume of settings by setting float on mixers

    void SetMusicVolume(float volume)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(volume) * 20);
    }

   
}
