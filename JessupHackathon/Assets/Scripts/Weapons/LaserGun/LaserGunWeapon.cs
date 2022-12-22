using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunWeapon : Weapon
{
    public LaserGunWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeOnInit = false)
    : base(characterObject, weaponObject, new LaserProjectileFactory(), 2.0f, 15, mustRechargeOnInit, false, 0.2f) { }
}
