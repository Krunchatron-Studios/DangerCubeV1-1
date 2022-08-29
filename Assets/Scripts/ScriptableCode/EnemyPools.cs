using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPools", menuName = "ScriptableObjects/EnemyPools")]

public class EnemyPools : ScriptableObject {
	
	public BaseEnemy[] pedestrians;
	public BaseEnemy[] soldiers;
	public BaseEnemy[] helicopters;
	public Kiwikid[] kiwikids;
}
