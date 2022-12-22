using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebProjectileFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new WebProjectile(direction);
    }
}
