using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeaponBehavior : WeaponBehavior {
    public override void Init() {
        EquippedWeapon = new SpiderWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
