using System;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    protected Animator EnemyAnimator;
    protected Transform PlayerTransform;
    protected Rigidbody2D EnemyRigidbody;
    protected SpriteRenderer EnemyRenderer;
    protected GameObject Player;

    [SerializeField]
    public AudioClip clip;
    [SerializeField]
    public float volume = 1f;

    public float speed;
    public int health;
    public float aggroRange;
    public int enemyScore;

    public EnemyDrops dropSystem;
    private HitPointsManager hitPointsManager;

    // Start is called before the first frame update
    protected void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = Player.transform;
        dropSystem = GameObject.FindGameObjectWithTag("DropSystem").GetComponent<EnemyDrops>();
        hitPointsManager = GetComponent<HitPointsManager>();
    }

    protected void Update()
    {
        if (hitPointsManager.HealthRatio <= 0)
        {
            dropItem();
            destroyEnemy();
        }
    }

    protected bool IsPlayerInRange()
    {
        float distanceToPlayer = GetDistanceToPlayer();
        if (distanceToPlayer < aggroRange)
        {
            return true;
        }
        return false;
    }

    protected float GetDistanceToPlayer()
    {
        return Vector2.Distance(PlayerTransform.position, transform.position);
    }

    public virtual void PlayClip()
    {
        if (this.IsPlayerInRange()) { AudioSource.PlayClipAtPoint(clip, this.transform.position, volume); }
    }

    private void destroyEnemy()
    {
        PlayerShooting PlayerShootingScript = Player.GetComponent<PlayerShooting>();
        PlayerShootingScript.CurLevelKillCount += 1;
        GlobalVariables.Score += enemyScore;
        Destroy(this.gameObject);
    }

    private void dropItem()
    {
        GameObject drop = dropSystem.GetDrop();
        if (drop != null)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
    }

}
