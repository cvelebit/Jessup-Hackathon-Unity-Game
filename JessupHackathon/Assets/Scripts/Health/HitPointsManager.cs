using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointsManager : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maxHealth;

    public float HealthRatio { get => currentHealth / maxHealth; }

    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private AudioClip attackedSound;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private float damageToPlayer;

    [SerializeField]
    private float minTimeBetweenDamagesToPlayer;

    private float timeSinceLastDamageToPlayer = 0.0f;

    private float timeSinceCharacterAttackedSoundWasPlayed = 0.0f;

    public float timeBetweenCharacterAttackSoundPlays = 1.0f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timeSinceCharacterAttackedSoundWasPlayed += Time.deltaTime;
        if (!isPlayer) {
            timeSinceLastDamageToPlayer += Time.deltaTime;
        }
    }

    void HandleIfDead() {
        if (currentHealth <= 0.0f) {
            currentHealth = 0.0f;
            // make sure to destroy any equipped weapons
            if (isPlayer) {
                PlayerShooting playerShooting = GetComponent<PlayerShooting>();
                Destroy(playerShooting?.equippedWeaponObject);
                Destroy(gameObject);
            }
            else {
                EnemyShooting enemyShooting = GetComponent<EnemyShooting>();
                Destroy(enemyShooting?.equippedWeaponObject);
            }
            if (deathSound) AudioSource.PlayClipAtPoint(deathSound, transform.position, 1.0f);
        }
    }

    void PlayAttackedSound() {
        if (attackedSound && timeSinceCharacterAttackedSoundWasPlayed >= timeBetweenCharacterAttackSoundPlays) {
            timeSinceCharacterAttackedSoundWasPlayed = 0.0f;
            AudioSource.PlayClipAtPoint(attackedSound, transform.position, 1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if ((isPlayer && collision.gameObject.tag == "EnemyProjectile")
            || (!isPlayer && collision.gameObject.tag == "PlayerProjectile")) {
            // apply the damage of the projectile
            Projectile projectile = collision.gameObject.GetComponent<ProjectileBehavior>().SpawnedProjectile;
            currentHealth -= projectile.Damage;
            // attacked sound plays at game object position
            PlayAttackedSound();
            HandleIfDead();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (!isPlayer && collision.gameObject.tag == "Player" && timeSinceLastDamageToPlayer >= minTimeBetweenDamagesToPlayer) {
            timeSinceLastDamageToPlayer = 0.0f;
            HitPointsManager playerHpManager = collision.gameObject.GetComponent<HitPointsManager>();
            playerHpManager.currentHealth -= damageToPlayer;
            playerHpManager.PlayAttackedSound();
            playerHpManager.HandleIfDead();
        }
    }

    public void addHealth(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Kill()
    {
        currentHealth = 0;
    }
}
