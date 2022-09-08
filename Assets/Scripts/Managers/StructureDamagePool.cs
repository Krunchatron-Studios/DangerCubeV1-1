using UnityEngine;
using MoreMountains.Tools;

public class StructureDamagePool : MonoBehaviour
{
    public static StructureDamagePool sdp;

    private void Start() {
        sdp = this;
    }

    [Header("Structure Particle Pools")] 
    public MMSimpleObjectPooler softDustPool;
    public MMSimpleObjectPooler rockShatterPool;
    public MMSimpleObjectPooler glassShatterPool;

    [Header("Fire Particle Pool")] 
    public MMSimpleObjectPooler fire1;
    public MMSimpleObjectPooler fire2;
    public MMSimpleObjectPooler fire3;

    [Header("Smoke Particle Pool")] 
    public MMSimpleObjectPooler smoke1;
    public MMSimpleObjectPooler smoke2;
    public MMSimpleObjectPooler smoke3;

}
