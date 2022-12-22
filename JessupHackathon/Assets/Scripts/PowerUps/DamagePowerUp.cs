using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUpBase
{
    public float damageBoost;

    protected override void ActivateEffect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().damageModifier += damageBoost;
    }
}
