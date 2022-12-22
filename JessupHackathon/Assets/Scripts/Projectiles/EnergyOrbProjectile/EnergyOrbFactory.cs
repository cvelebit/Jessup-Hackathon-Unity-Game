using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrbFactory : IProjectileFactory {
    public Projectile Create(Vector2 direction) {
        return new EnergyOrbProjectile(direction);
    }
}
