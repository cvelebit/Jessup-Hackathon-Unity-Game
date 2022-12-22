using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerProjectileFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new FlameThrowerProjectile(direction);
    }
}
