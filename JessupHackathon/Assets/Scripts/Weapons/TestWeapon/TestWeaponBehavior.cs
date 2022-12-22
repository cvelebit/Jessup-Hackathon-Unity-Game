using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponBehavior : WeaponBehavior
{
    // Start is called before the first frame update
    public override void Init()
    {
        EquippedWeapon = new TestWeapon(characterObject, gameObject, mustRechargeOnInit);
    }
}
