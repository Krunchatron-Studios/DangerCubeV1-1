using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager sm;

	private void Start() {
		sm = this;
	}

	[Header("Death Sounds")]
	public AudioSource humanDying1;
	public AudioSource humanDying2;
	public AudioSource humanDying3;


	[Header("Weapon Sounds")] 
	public AudioSource rapidGun;
	public AudioSource clusterGun;
	public AudioSource orbital;
	public AudioSource mutagenic;
	public AudioSource mineSlayer;
	public AudioSource meatSaw;
	public AudioSource deathRay;
}
