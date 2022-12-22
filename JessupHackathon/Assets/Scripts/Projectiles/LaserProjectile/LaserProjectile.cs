using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : Projectile
{
    public LaserProjectile(Vector3 direction) : base(3.0f, 20.0f, direction, 3.0f) { }
}
