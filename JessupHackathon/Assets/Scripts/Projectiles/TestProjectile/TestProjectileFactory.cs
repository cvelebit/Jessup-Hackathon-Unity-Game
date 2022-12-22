using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectileFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new TestProjectile(direction);
    }
}
