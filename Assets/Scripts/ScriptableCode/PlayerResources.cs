using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Resources", menuName = "ScriptableObjects/PlayerResources")]
public class PlayerResources : ScriptableObject {
   
    public int bioGoo;
    public int metal;
    public int silicate;
    public int experience;
    public int collectionRange;
    
}
