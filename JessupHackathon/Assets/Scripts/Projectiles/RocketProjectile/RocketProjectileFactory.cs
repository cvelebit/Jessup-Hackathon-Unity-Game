using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectileFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new RocketProjectile(direction);
    }
}
