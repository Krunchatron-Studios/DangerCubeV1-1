using MoreMountains.Tools;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Sprite weaponSprite;
	private AudioClip _weaponSound;
	public AudioSource audioSource;
	
	[Header("Main Weapon Vars")]
	public string weaponName;
	public string weaponDescription;
	public float weaponDamage = 1f;

	public MMSimpleObjectPooler objectPooler;
	
	private void Start() {
		audioSource = GetComponent<AudioSource>();
	}
}
