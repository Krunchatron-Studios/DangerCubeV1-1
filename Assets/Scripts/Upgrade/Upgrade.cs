using Interfaces;
using UnityEngine;
public class Upgrade : MonoBehaviour {
	private IUpgradeThingInterface _interface;
	public int upgradeLevel = 0;
	public string upgradeName;
	public string upgradeTier;
	public string upgradeType;
	public Sprite upgradeSprite;
	public string description;
	[Header("Audio")] 
	public AudioSource audioSource;
	public float upgradeRange;
	
	private void Start() {
		_interface = WeaponSystem.Instance.GetComponent<IUpgradeThingInterface>();
	}
}
