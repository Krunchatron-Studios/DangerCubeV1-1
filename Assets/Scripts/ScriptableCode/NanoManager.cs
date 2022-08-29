using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nano Bot Manager", menuName = "ScriptableObjects/NanoManager")]
public class NanoManager : ScriptableObject {
    public int maxNanoBots;
    public int currentNanoBots;
}
