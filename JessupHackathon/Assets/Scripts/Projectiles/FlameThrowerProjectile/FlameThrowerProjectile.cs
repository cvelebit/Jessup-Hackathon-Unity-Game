using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerProjectile : Projectile
{
    public FlameThrowerProjectile(Vector3 direction)
    : base(1.0f, 2.0f, direction, 3.0f) { }
}
