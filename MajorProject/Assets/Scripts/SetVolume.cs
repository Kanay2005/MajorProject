using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetBackgroundMusicLevel(float sliderValue){
        mixer.SetFloat("BackgroundMusicVol", Mathf.Log10(sliderValue)*20);
    }
    public void SetSFXLevel(float sliderValue){
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue)*20);
    }
}
