using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : PowerUpBase
{
    public float speedUpgradeAmount= 0.25f;

    protected override void ActivateEffect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().addSpeed(speedUpgradeAmount);
    }
}
