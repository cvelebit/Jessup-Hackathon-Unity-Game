using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile
{
    public float Damage { get; set; }
    public float Speed { get; private set; }
    public Vector3 Direction { get; private set; }
    public bool ShouldDespawn { get; private set; } = false;
    public float TimeLeftToDespawn { get; private set; }

    protected Projectile(float damage, float speed, Vector3 direction, float timeToDespawnDuration) {
        Damage = damage;
        Speed = speed;
        Direction = direction;
        TimeLeftToDespawn = timeToDespawnDuration;
    }

    protected void Move(GameObject projectileGameObject) {
        projectileGameObject.transform.position += Direction * Speed * Time.deltaTime;
    }

    protected void UpdateDespawnTimer() {
        if (TimeLeftToDespawn <= 0.0f) {
            TimeLeftToDespawn = 0.0f;
            ShouldDespawn = true;
        } else {
            TimeLeftToDespawn -= Time.deltaTime;
        }
    }

    public void Update(GameObject projectileGameObject) {
        Move(projectileGameObject);
        UpdateDespawnTimer();
    }
}
