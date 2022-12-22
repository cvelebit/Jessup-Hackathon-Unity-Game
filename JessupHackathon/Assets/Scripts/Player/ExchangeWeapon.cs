using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeWeapon : MonoBehaviour
{

    private GameObject weaponInRange = null;

    private PlayerShooting playerShooting;

    // Start is called before the first frame update
    void Start()
    {
        playerShooting = GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponInRange != null && Input.GetKeyDown(KeyCode.E)) {
            // discard a instance of the current equipped weapon
            Instantiate(playerShooting.equippedWeaponObject, weaponInRange.transform.position, new Quaternion());
            playerShooting.EquipWeapon(weaponInRange, true);
            Destroy(weaponInRange);
            weaponInRange = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Weapon" && collision.gameObject != playerShooting.equippedWeaponObject) {
            weaponInRange = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Weapon" && collision.gameObject != playerShooting.equippedWeaponObject) {
            weaponInRange = null;
        }
    }
}
