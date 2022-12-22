using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUpBase
{
    public float healAmount = 5;
    protected override void ActivateEffect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HitPointsManager>().addHealth(healAmount);
    }
}
