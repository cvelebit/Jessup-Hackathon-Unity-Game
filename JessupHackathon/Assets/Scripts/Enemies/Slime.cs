
using UnityEngine;

public class Slime : BaseEnemy
{

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsPlayerInRange())
        {
            MoveTowardsPlayer();
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
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            EnemyAnimator.SetFloat("Horizontal", Mathf.Abs(movement.x));
            EnemyAnimator.SetFloat("Vertical", 0);
            if (movement.x > 0)
            {
                EnemyRenderer.flipX = true;
            }
            else
            {
                EnemyRenderer.flipX = false;
            }
            return;
        }

        EnemyAnimator.SetFloat("Vertical", movement.y);
        EnemyAnimator.SetFloat("Horizontal", 0);

    }


}
