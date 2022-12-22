using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehavior : MonoBehaviour
{
    [SerializeField]
    public GameObject projectilePrefab;

    public Weapon EquippedWeapon { get; protected set; }

    public GameObject characterObject;

    public bool mustRechargeOnInit = false;

    public abstract void Init();
}
