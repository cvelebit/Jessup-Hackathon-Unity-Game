using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolWeaponBehavior : WeaponBehavior {
    public override void Init() {
        EquippedWeapon = new PistolWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
