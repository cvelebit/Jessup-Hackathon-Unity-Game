using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : BaseEnemy
{
   // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            MoveTowardsPlayer();
        }
        else
        {
            EnemyAnimator.SetFloat("Vertical", 0);
            EnemyAnimator.SetFloat("Horizontal", 0);
        }
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
        EnemyAnimator.SetFloat("Horizontal", movement.x);
        EnemyAnimator.SetFloat("Vertical", movement.y);
        if (movement.x < 0)
        {
            EnemyRenderer.flipX = true;
        }
        else
        {
            EnemyRenderer.flipX = false;
        }
    }
}
