using UnityEngine;

public class BackToPool : MonoBehaviour
{
    public bool returnParent;

    public float returnDelay;
    
    private ParticleSystem _returnParticleSystem;
    private float _startTime;

    void Start() {
        _returnParticleSystem = GetComponent<ParticleSystem>();
        if (returnDelay != 0) {
            _startTime = Time.time;
        }
    }

    protected virtual void Update() {	
        if (returnDelay != 0 && Time.time - _startTime > returnDelay) {
            ReturnParticleSystem();
        }	
        if (_returnParticleSystem.isPlaying) {
            return;
        }
        ReturnParticleSystem();
    }

    protected virtual void ReturnParticleSystem() {
        if (transform.parent) {
            if (returnParent) {
                gameObject.SetActive(false);
            }
        }					
        gameObject.SetActive(false);
    }
}
