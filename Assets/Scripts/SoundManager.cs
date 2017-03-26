using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;
	
	private static SoundManager instance{
		get{
			if(Instance == null){
				GameObject go = new GameObject("SoundManager");
				go.AddComponent<SoundManager>();
			}
			return instance;
		}
	}



	void Awake()
	{
		Instance = this;
	}

	public AudioClip player_death;
	public AudioClip hitExplosion;
	private AudioSource audio;
	private AudioSource currentAudio;
	void Start()
	{
		AudioSource[] audios = GetComponents<AudioSource>();
		audio = audios[0];
		currentAudio = audios[1];
	}


	public void playGemSound(){
		audio.Play();
	}

	public void playPlayerDeadSFX(){
		currentAudio.clip = player_death;
		currentAudio.Play();
	}

	public void hitSFX(){
		currentAudio.Stop();
		currentAudio.clip = hitExplosion;
		currentAudio.Play();
	}

}
