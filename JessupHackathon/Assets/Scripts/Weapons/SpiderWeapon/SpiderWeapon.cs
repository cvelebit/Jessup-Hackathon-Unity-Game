using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeapon : Weapon
{
    public SpiderWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeOnInit)
    : base(characterObject, weaponObject, new WebProjectileFactory(), 3.0f, 8, mustRechargeOnInit, true) { }
}
