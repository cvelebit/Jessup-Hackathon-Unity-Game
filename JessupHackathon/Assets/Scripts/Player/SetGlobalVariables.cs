using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGlobalVariables : MonoBehaviour
{

    public GameObject weaponToEquip;
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.Score = 0;
        GlobalVariables.Speed = 5.0f;
        GlobalVariables.DamageModifier = 0.0f;
        GlobalVariables.CurrentWeapon = weaponToEquip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
