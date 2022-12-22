using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLauncherWeaponBehavior : WeaponBehavior {
    public override void Init() {
        EquippedWeapon = new OrbLauncherWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
