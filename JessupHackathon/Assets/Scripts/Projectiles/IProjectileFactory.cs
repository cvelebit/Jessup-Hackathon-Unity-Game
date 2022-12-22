using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileFactory
{
    public Projectile Create(Vector2 direction);
}
