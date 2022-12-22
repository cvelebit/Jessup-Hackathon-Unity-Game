using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunBehavior : WeaponBehavior {
    public override void Init() {
        EquippedWeapon = new LaserGunWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
