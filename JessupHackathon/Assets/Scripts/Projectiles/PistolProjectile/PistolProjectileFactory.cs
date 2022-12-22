using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectileFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new PistolProjectile(direction);
    }
}
