using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerWeaponBehavior : WeaponBehavior {
    public override void Init() {
        EquippedWeapon = new FlameThrowerWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
