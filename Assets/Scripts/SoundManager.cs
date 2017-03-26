using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static AudioSource[] audio;
	private static AudioSource gemAudio;

	// Use this for initialization
	void Start () {
		audio = GetComponents<AudioSource>();
		gemAudio = audio[0];
	}
	
	public static void playGemSound(){
		gemAudio.Play();
	}

}
