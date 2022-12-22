using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWeapon : MonoBehaviour
{
    public Slider energyBar;
    public Image gunImage;
    private PlayerShooting playerShooting;

    // Start is called before the first frame update
    void Start()
    {
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        gunImage.sprite = playerShooting.equippedWeaponPrefab.GetComponent<SpriteRenderer>().sprite;
        energyBar.value = playerShooting.EquippedWeapon.EnergyRemaining();
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.value = playerShooting.EquippedWeapon.EnergyRemaining();
    }
}
