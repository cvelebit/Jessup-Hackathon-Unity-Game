using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReference;
    private GameObject spawnedEnemy;

    private GameObject Player;
    private Transform PlayerTransform;
    private int randomIndex;

    public float dist;
    public bool coroutine;

    [SerializeField]
    public bool active = false;

    [SerializeField]
    private float ActiveRange=15f;

    [SerializeField]
    private int killsToDeactivate;
    [SerializeField]
    private int SpawnLimit = 50;

    [SerializeField]
    private Vector2 outerMax = new Vector2(5f,5f);
    [SerializeField]
    private Vector2 outerMin = new Vector2(-5f, -5f);
    [SerializeField]
    private Vector2 innerMax = new Vector2(2f, 2f);
    [SerializeField]
    private Vector2 innerMin = new Vector2(-2f, -2f);

    [SerializeField]
    private int[] RespawnTime = new int[] {1,5};

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = Player.transform;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (!coroutine)
        {
            coroutine = true;
            StartCoroutine(SpawnEnemies());
        }
        
        IsPlayerInRange();
        int playerKills = GetPlayerKills();
        if (playerKills>=killsToDeactivate || SpawnLimit<=0)
        {
            active = false;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (active)
        {
            yield return new WaitForSeconds(Random.Range(RespawnTime[0], RespawnTime[1]));
            randomIndex = Random.Range(0, enemyReference.Length);
            spawnedEnemy = Instantiate(enemyReference[randomIndex]);
            float[] Xs = new float[] { Random.Range(outerMin.x, innerMin.x), Random.Range(innerMax.x, outerMax.x)};
            float[] Ys = new float[] { Random.Range(outerMin.y, innerMin.y), Random.Range(innerMax.y, outerMax.y)};
            float y = Ys[Random.Range(0,1)];
            float x = Xs[Random.Range(0,1)];
            spawnedEnemy.transform.position = new Vector3(x+this.transform.position.x, y+this.transform.position.y, 1f);
            SpawnLimit -= 1;
        }
        coroutine = false;
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = GetDistToPlayer();
        if (distanceToPlayer < ActiveRange)
        {
            active = true;
            return true;
        }
        active = false;
        return false;
    }

    private float GetDistToPlayer()
    {
        dist = Vector2.Distance(PlayerTransform.position, transform.position);
        return dist;
    }

    private int GetPlayerKills()
    {
        PlayerShooting PlayerShootingScript = Player.GetComponent<PlayerShooting>();
        return PlayerShootingScript.CurLevelKillCount;
    }
}
