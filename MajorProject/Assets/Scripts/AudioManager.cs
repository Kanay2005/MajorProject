using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	//Declaring all the variables used in the code
	public static AudioManager instance;
	int maxWidth;
	int maxHeight;

	public AudioMixerGroup mixerGroup;
	[NonReorderable]
	//Getting the sounds which were inputted in unity
	public Sound[] sounds;

	void Awake()
	{
		//Checking if there is another audio manager
		if (instance != null)
		{
			//Deleting itself if there is already an audio mangaer
			Destroy(gameObject);
		}
		else
		{
			//Keeping itself through scenes if there isnt an audio mangaer
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		//Looping through all the audio clips
		foreach (Sound s in sounds)
		{
			//Inputting all the audio clips in the gameobject
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			//Adding the mixer group
			if(s.mixerGroup != null){
				s.source.outputAudioMixerGroup = s.mixerGroup;
			}
			else{
				s.source.outputAudioMixerGroup = mixerGroup;
			}

			//playing the background music on the start
			if(s.name.ToString() == "BackgroundMusic"){
				s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
				s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

				s.source.Play();
			}
		}
	}
	void Start()
	{
		//Finding all the compatiable resolutions
		Resolution[] resolutions = Screen.resolutions;
        foreach (var res in resolutions){
            Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
			//Saving the resolutions which are in the correct aspect ratio
			if(Math.Round((float)res.width/(float)res.height, 6) == Math.Round((float)1920/(float)1080, 6)){
				maxWidth = res.width;
				maxHeight = res.height;
				print(maxWidth.ToString() + ", "+ maxHeight.ToString());
			}
        }
		//Setting the resolution to the highest resolution with the correct aspect ratio
		Screen.SetResolution(maxWidth, maxHeight, FullScreenMode.ExclusiveFullScreen);
	}

	//Fuction for other game objects to call if they need to play a sound
	public void Play(string sound)
	{
		//finding the sound clip name inputted
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		//playing the sound clip if found
		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}
}
