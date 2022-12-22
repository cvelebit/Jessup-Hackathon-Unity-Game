using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMeter : MonoBehaviour
{
    private PlayerShooting playerShooting;
    private UnityEngine.UI.Text UIText;
    // Start is called before the first frame update
    void Start()
    {
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        UIText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = $"Energy: {playerShooting.EquippedWeapon.EnergyRemaining()}";
    }
}
