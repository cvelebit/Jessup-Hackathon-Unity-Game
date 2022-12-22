using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    public Vector3 EnemyShootDirectionVector;

    public GameObject equippedWeaponPrefab;

    public GameObject equippedWeaponObject;

    private WeaponBehavior weaponBehavior;

    private BoxCollider2D enemyCollisionBox;

    public Weapon EquippedWeapon { get; private set; }

    public bool EnemyShouldFire = false;

    public float timeBetweenFires = 1.0f;
    private float timeSinceLastFire = 0.0f;

    private SpriteRenderer weaponSpriteRenderer;

    public void EquipWeapon(GameObject weaponPrefabToEquip) {
        equippedWeaponObject = Instantiate(weaponPrefabToEquip, transform.position, new Quaternion());
        weaponBehavior = equippedWeaponObject.GetComponent<WeaponBehavior>();
        // set the player as the character object
        weaponBehavior.characterObject = gameObject;
        weaponBehavior.Init();
        EquippedWeapon = weaponBehavior.EquippedWeapon;
        weaponSpriteRenderer = equippedWeaponObject.GetComponent<SpriteRenderer>();
    }

    private void Awake() {
        EquipWeapon(equippedWeaponPrefab);
        EnemyShootDirectionVector = EnemyShootDirectionVector == null ? new Vector3() : EnemyShootDirectionVector;
        enemyCollisionBox = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        EquippedWeapon.Update();
        timeSinceLastFire += Time.deltaTime;
        if (EnemyShouldFire && timeSinceLastFire > timeBetweenFires && EquippedWeapon.DidFire()) {
            timeSinceLastFire = 0.0f;
            // weapon should look at the direction it fired
            float rotationZ = Mathf.Atan2(EnemyShootDirectionVector.y, EnemyShootDirectionVector.x) * Mathf.Rad2Deg;
            equippedWeaponObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            // flip the weapon based on the rotation
            if (rotationZ > -90.0f && rotationZ < 90.0f) {
                weaponSpriteRenderer.flipX = false;
            } else {
                weaponSpriteRenderer.flipX = true;
            }
            // move the weapon in the direction of the shot
            equippedWeaponObject.transform.position = (gameObject.transform.position + EnemyShootDirectionVector * (enemyCollisionBox.size.y/2.0f));
            // projectile should look face the direction it fired
            ProjectileBehavior projectileBehavior =
            Instantiate(weaponBehavior.projectilePrefab,
            (transform.position + EnemyShootDirectionVector * enemyCollisionBox.size.y * 1.25f),
            Quaternion.Euler(0.0f, 0.0f, rotationZ)).GetComponent<ProjectileBehavior>();
            projectileBehavior.SpawnedProjectile = EquippedWeapon.ProjectileFactory.Create(EnemyShootDirectionVector);
        }
    }
}
