using MoreMountains.Tools;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Sprite weaponSprite;
	private AudioClip _weaponSound;
	public AudioSource audioSource;
	[Header("Main Weapon Vars")]
	public string weaponName;
	public string weaponDescription;
	public float weaponDamage;
	public string damageType;
	public float knockForce;

	public MMSimpleObjectPooler objectPooler;
	public void Knockback (Collider2D other) {
		Debug.Log("this is a test ");

		Rigidbody2D thisRigidBody = other.GetComponent<Rigidbody2D>();
		Vector3 difference = (transform.position - other.transform.position).normalized;
		Vector3 appliedForce = difference * knockForce;
		thisRigidBody.AddForce(appliedForce, ForceMode2D.Impulse);
	}
}
