using Interfaces;
using UnityEngine;
public class Upgrade : MonoBehaviour {
	private IUpgradeThingInterface _interface;
	public string upgradeName;
	public string upgradeTier;
	public string upgradeType;
	public Sprite sprite;
	public string description;
	[Header("Audio")] 
	public AudioSource audioSource;
	public float upgradeRange;
	
	private void Start() {
		_interface = WeaponSystem.Instance.GetComponent<IUpgradeThingInterface>();
	}
}
