using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Projectile
{
    public RocketProjectile(Vector3 direction) : base(30.0f, 10.0f, direction, 4.0f) { }
}
