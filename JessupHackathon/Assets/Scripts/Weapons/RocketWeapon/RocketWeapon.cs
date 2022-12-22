using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : Weapon
{
    public RocketWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeonInit)
    : base(characterObject, weaponObject, new RocketProjectileFactory(), 7.0f, 6, mustRechargeonInit, false, 1.0f) { }
}
