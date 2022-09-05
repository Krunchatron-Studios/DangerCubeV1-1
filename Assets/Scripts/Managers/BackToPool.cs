using UnityEngine;

public class BackToPool : MonoBehaviour
{
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
            gameObject.SetActive(false);
        }	
        if (_returnParticleSystem.isPlaying) {
            return;
        }
        gameObject.SetActive(false);
    }
}
