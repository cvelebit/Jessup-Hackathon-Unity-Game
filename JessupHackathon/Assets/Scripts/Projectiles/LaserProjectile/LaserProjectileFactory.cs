using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectileFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new LaserProjectile(direction);
    }
}
