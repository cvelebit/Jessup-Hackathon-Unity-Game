using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : Weapon
{
    public TestWeapon(GameObject characterObject, GameObject weaponObject, bool mustRechargeOnInit)
    : base(characterObject, weaponObject, new TestProjectileFactory(), 5.0f, 1000, mustRechargeOnInit) { }
}
