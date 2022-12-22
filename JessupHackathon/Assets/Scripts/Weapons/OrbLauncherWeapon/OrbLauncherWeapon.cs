using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLauncherWeapon : Weapon
{
    public OrbLauncherWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeOnInit)
    : base(characterObject, weaponObject, new EnergyOrbFactory(), 6.0f, 10, mustRechargeOnInit, false, 1.0f) { }
}
