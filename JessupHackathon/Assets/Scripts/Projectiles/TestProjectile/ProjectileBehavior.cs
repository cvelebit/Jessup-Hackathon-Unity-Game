using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Projectile SpawnedProjectile { get; set; }

    public AudioClip projectileSpawnSound;
    // Start is called before the first frame update
    void Start()
    {
        if (projectileSpawnSound) AudioSource.PlayClipAtPoint(projectileSpawnSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnedProjectile.Update(gameObject);
        if (SpawnedProjectile.ShouldDespawn) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.gameObject.tag == "Player" && tag == "PlayerProjectile") || (collision.gameObject.tag == "Enemy" && tag == "EnemyProjectile")) {
        } else {
            Destroy(gameObject);
        }
    }
}
