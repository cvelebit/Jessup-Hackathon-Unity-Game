using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerWeapon : Weapon
{
    public FlameThrowerWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeOnInit)
    : base(characterObject, weaponObject, new FlameThrowerProjectileFactory(), 1.0f, 20, mustRechargeOnInit, false, 0.05f) { }
}
