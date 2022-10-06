using UnityEngine;
public class LobbedProjectile : Projectile {
    public AnimationCurve arc;
    private Vector3 _startPos;
    public float timer;

    void Start() {
        _startPos = transform.position;
    }

    void Awake() {
        timer = 0;
    }
    void Update() {
        timer += Time.deltaTime;
        Vector3 pos = Vector3.Lerp(_startPos, targetPosition, timer);
        pos.y += arc.Evaluate(timer);
        transform.position = pos;
    }

    public override void MoveProjectile() {
        Debug.Log("poop");
    }
}
