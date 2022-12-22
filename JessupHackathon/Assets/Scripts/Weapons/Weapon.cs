using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public float ChargeTimeDuration;
    public float ChargeTimeLeft = 0.0f;
    public int NumberOfRoundsUntilChargeRequired;
    public int NumberOfRoundsSinceLastCharge = 0;
    public float EnergyRemaining() {
        float energyAmount = 1.0f - (float)ChargeTimeLeft / (float)ChargeTimeDuration;
        if (CanFire) {
            energyAmount = 1.0f - (float)NumberOfRoundsSinceLastCharge / (float)NumberOfRoundsUntilChargeRequired;
        }
        return energyAmount;
    }
    public bool CanFire { get; private set; } = true;

    private readonly GameObject characterObject;
    protected GameObject weaponObject;

    private float timeSinceLastRecoverCharge = 0.0f;

    private bool alwaysInvisible;

    private float minimumTimeBetweenFires;
    private float timeSinceLastFire;

    public IProjectileFactory ProjectileFactory { get; protected set; }
    protected Weapon(GameObject _characterObject, GameObject _weaponObject, IProjectileFactory projectileFactory, float chargeTimeDuration, int numberOfRoundsUntilChargeRequired, bool mustRechargeOnInit, bool _alwaysInvisible = false, float _minimumTimeBetweenFires = 0.0f) {
        ChargeTimeDuration = chargeTimeDuration;
        NumberOfRoundsUntilChargeRequired = numberOfRoundsUntilChargeRequired;
        ProjectileFactory = projectileFactory;
        weaponObject = _weaponObject;
        characterObject = _characterObject;
        alwaysInvisible = _alwaysInvisible;
        if (mustRechargeOnInit) {
            CanFire = false;
            ChargeTimeLeft = ChargeTimeDuration;
        }
        if (alwaysInvisible) {
            weaponObject.SetActive(false);
        }
        else {
            weaponObject.SetActive(true);
        }
        minimumTimeBetweenFires = _minimumTimeBetweenFires;
    }

    public void Update() {
        timeSinceLastFire += Time.deltaTime;
        RecoverChargeIfCanFire();
        ForceRechargeIfCannotFire();
    }

    protected void ForceRechargeIfCannotFire() {
        if (ChargeTimeLeft > 0.0f) {
            ChargeTimeLeft -= Time.deltaTime;
        } else {
            ChargeTimeLeft = 0.0f;
            CanFire = true;
        }
    }

    protected void RecoverChargeIfCanFire() {
        if (CanFire) {
            timeSinceLastRecoverCharge += Time.deltaTime;
            if (timeSinceLastRecoverCharge > (ChargeTimeDuration / NumberOfRoundsUntilChargeRequired) && NumberOfRoundsSinceLastCharge > 0) {
                NumberOfRoundsSinceLastCharge--;
                timeSinceLastRecoverCharge = 0.0f;
            }
        }
    }

    public bool DidFire() {
        if (CanFire && timeSinceLastFire >= minimumTimeBetweenFires) {
            timeSinceLastFire = 0.0f;
            // since the player fired the weapon we restart the time until the next recovery
            timeSinceLastRecoverCharge = 0.0f;
            if (NumberOfRoundsSinceLastCharge >= NumberOfRoundsUntilChargeRequired) {
                NumberOfRoundsSinceLastCharge = 0;
                CanFire = false;
                ChargeTimeLeft = ChargeTimeDuration;
                return false;
            }
            NumberOfRoundsSinceLastCharge++;
            return true;
        }
        return false;
    }
    
}
