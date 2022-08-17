using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLaser : Weapon {
    private Transform _playerPosition;
    private void FixedUpdate() {
        CanFireTimer();
        _playerPosition = GameObject.FindWithTag("Player").transform;
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        // needs a vertical point off screen to start beam
            // decrement size to target origin
            // on size 0 instantiate explosion
            float startX = Random.Range(_playerPosition.position.x * 50, _playerPosition.position.x * -50);
            float startY = _playerPosition.position.y + 20;
        Transform bulletTransform = Instantiate(projectile, new Vector3(startX, startY, 0), Quaternion.identity);
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        bullet.Setup(targetPosition);
        _nextFire = Time.time + rateOfFire;
        // bullet.MoveProjectile();
        BeamGrow(targetPosition);
    }

    public void BeamGrow(Vector3 targetPosition) {
        float distance = Vector3.Distance(projectile.position, targetPosition);
        Debug.Log("This is the distance: " + distance);
        float scaleY = this.transform.localScale.y;
        scaleY = distance;
    }
}
