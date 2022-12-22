using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Vector3 cursorPosition;
    public Vector3 ShootDirectionVector { get; private set; }
    public int CurLevelKillCount = 0;

    public GameObject equippedWeaponPrefab;
    public GameObject equippedWeaponObject;
    private WeaponBehavior weaponBehavior;

    private BoxCollider2D playerCollisionBox;

    public Weapon EquippedWeapon { get; private set; }

    private SpriteRenderer weaponSpriteRenderer;

    public float damageModifier = 0.0f;

    public float DamageModifier { get => 1.0f + damageModifier; }

    private EquippedWeapon equippedWeaponScript;
    public void EquipWeapon(GameObject weaponPrefabToEquip, bool mustRechargeOnInit = false) {
        Destroy(equippedWeaponObject);
        equippedWeaponObject = Instantiate(weaponPrefabToEquip, transform.position, new Quaternion());
        weaponBehavior = equippedWeaponObject.GetComponent<WeaponBehavior>();
        // set the player as the character object
        weaponBehavior.characterObject = gameObject;
        // set whether the weapon must recharge first
        weaponBehavior.mustRechargeOnInit = mustRechargeOnInit;
        weaponBehavior.Init();
        EquippedWeapon = weaponBehavior.EquippedWeapon;
        weaponSpriteRenderer = equippedWeaponObject.GetComponent<SpriteRenderer>();
        // change equipped weapon sprite
        equippedWeaponScript.gunImage.sprite = weaponSpriteRenderer.sprite;

    }

    private void Awake() {
        equippedWeaponScript = GameObject.FindGameObjectWithTag("EquippedGun").GetComponent<EquippedWeapon>();
        equippedWeaponPrefab = GlobalVariables.CurrentWeapon;
        EquipWeapon(equippedWeaponPrefab);
        cursorPosition = Input.mousePosition;
        ShootDirectionVector = new Vector3();
        playerCollisionBox = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        damageModifier = GlobalVariables.DamageModifier;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursorAndShootDirectionVector();
        EquippedWeapon.Update();
        // weapon should look at the direction it fired
        float rotationZ = Mathf.Atan2(ShootDirectionVector.y, ShootDirectionVector.x) * Mathf.Rad2Deg;
        equippedWeaponObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        // flip the weapon based on the rotation
        if (rotationZ > -90.0f && rotationZ < 90.0f) {
            weaponSpriteRenderer.flipY = false;
        }
        else {
            weaponSpriteRenderer.flipY = true;
        }
        // move the weapon in the direction of the shot
        equippedWeaponObject.transform.position = (gameObject.transform.position + ShootDirectionVector * playerCollisionBox.size.y);
        if (Input.GetMouseButton(0) && EquippedWeapon.DidFire()) {
            // projectile should face the direction it was fired
            ProjectileBehavior projectileBehavior =
            Instantiate(weaponBehavior.projectilePrefab, 
            (transform.position + ShootDirectionVector * playerCollisionBox.size.y*1.5f),
            Quaternion.Euler(0.0f, 0.0f, rotationZ)).GetComponent<ProjectileBehavior>();
            projectileBehavior.SpawnedProjectile = EquippedWeapon.ProjectileFactory.Create(ShootDirectionVector);
            // add damage modifier
            projectileBehavior.SpawnedProjectile.Damage *= DamageModifier;
        }
    }

    void UpdateCursorAndShootDirectionVector() {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPosition = transform.position;
        cursorPosition.z = 0.0f;
        playerPosition.z = 0.0f;
        ShootDirectionVector = Vector3.Normalize(cursorPosition - playerPosition);
    }

    private void OnDestroy()
    {
        GlobalVariables.DamageModifier = damageModifier;
        GlobalVariables.CurrentWeapon = equippedWeaponPrefab;
    }
}
