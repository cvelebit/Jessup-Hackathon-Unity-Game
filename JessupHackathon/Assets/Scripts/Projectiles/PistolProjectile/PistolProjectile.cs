using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : Projectile
{
    public PistolProjectile(Vector3 direction)
    : base(5.0f, 15.0f, direction, 4.0f) { }
}
