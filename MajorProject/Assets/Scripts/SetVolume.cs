using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //Declaring all the variables used in the code
    public AudioMixer mixer;
    public void SetBackgroundMusicLevel(float sliderValue){
        //Setting the Music volume according to the slider in the game
        mixer.SetFloat("BackgroundMusicVol", Mathf.Log10(sliderValue)*20);
    }
    public void SetSFXLevel(float sliderValue){
        //Setting the sfx volume according to the slider in the game
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue)*20);
    }
}
