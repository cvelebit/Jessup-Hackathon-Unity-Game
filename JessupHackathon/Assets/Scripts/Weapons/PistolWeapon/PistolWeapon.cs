using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolWeapon : Weapon
{
    public PistolWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeOnInit)
    : base(characterObject, weaponObject, new PistolProjectileFactory(), 5.0f, 10, mustRechargeOnInit, false, 0.3f) { }
}
