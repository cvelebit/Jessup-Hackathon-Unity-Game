using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeaponBehavior : WeaponBehavior {
    public override void Init() {
        EquippedWeapon = new RocketWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
