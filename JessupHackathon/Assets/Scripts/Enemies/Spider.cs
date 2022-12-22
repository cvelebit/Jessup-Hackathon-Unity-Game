using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : BaseEnemy
{
    public float attackRange;

    private Vector3 shootDirection = new Vector3(0.0f, 1.0f, 0.0f);

    private EnemyShooting enemyShooting;

    private GameObject playerObject;

    private void Start() {
        base.Start();
        enemyShooting = GetComponent<EnemyShooting>();
        enemyShooting.EnemyShouldFire = false;
        enemyShooting.EnemyShootDirectionVector = shootDirection;
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        enemyShooting.EnemyShouldFire = false;
        if (IsPlayerInRange() && GetDistanceToPlayer() > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            EnemyAnimator.SetBool("Idle", true);
            FaceTowardsPlayer();
        }
        if (IsPlayerInRange()) {
            Attack();
            enemyShooting.EnemyShouldFire = true;
        }

    }

    private void FaceTowardsPlayer()
        {
        
        if (PlayerTransform.position.x - transform.position.x > 0)
        {
            EnemyRenderer.flipX = false;
        }
        else
        {
            EnemyRenderer.flipX = true;
        }
        EnemyAnimator.SetFloat("Horizontal", PlayerTransform.position.x - transform.position.x);
        EnemyAnimator.SetFloat("Vertical", PlayerTransform.position.y - transform.position.y);
        }
        
    private void MoveTowardsPlayer()
    {
        Vector2 previousPosition = transform.position;
        Vector2 movement = Vector2.MoveTowards(transform.position, PlayerTransform.position, speed * Time.deltaTime);
        Vector2 currentDirection = (movement - previousPosition).normalized;
        UpdateAnimator(currentDirection);
        transform.position = movement;

    }

    private void UpdateAnimator(Vector2 movement)
    {
        if (movement == Vector2.zero)
        {
            EnemyAnimator.SetBool("Idle", true);
        }
        else
        {
            EnemyAnimator.SetBool("Idle", false);
        }
        if (movement.x > 0)
        {
            EnemyRenderer.flipX = false;
        }
        else
        {
            EnemyRenderer.flipX = true;
        }

        EnemyAnimator.SetFloat("Horizontal", movement.x);
        EnemyAnimator.SetFloat("Vertical", movement.y);

    }

    public override void PlayClip()
    {
        AudioSource.PlayClipAtPoint(this.clip, this.transform.position, volume); 
        
    }

    private void Attack() {
        Vector3 direction = Vector3.Normalize(playerObject.transform.position - transform.position);
        Vector2 direction2d = new Vector2(direction.x, direction.y);
        direction2d.Normalize();
        enemyShooting.EnemyShootDirectionVector = new Vector3(direction2d.x, direction2d.y, 0.0f);
    }
}
