using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrops : MonoBehaviour
{
    [Tooltip("use this to weigh rarities of drops, will drop if generated num is >= weight")] [Header("Drop Weights")]
    public int gunChestWeight;
    public int powerupChestWeight;
    public int coinWeight;
    public int nothingWeight;

    public GameObject coin;
    public GameObject[] powerupChests;
    public GameObject[] gunChests;

    public GameObject GetDrop()
    {
        int drop = GenerateDropWeight();
        switch (drop)
        {
            case -1:
                return null;
            case 1:
                return coin;
            case 2:
                return DropPowerupChest();
            case 3:
                return DropGunChest();
        }

        return null;
    }
   
    private int GenerateDropWeight()
    {
        int[] rarities = { nothingWeight, coinWeight, powerupChestWeight, gunChestWeight};
        int dropWeight = Random.Range(1, rarities.Sum());

        if (dropWeight >= rarities[0])
        {
            return -1;
        }

        for (int i = 1; i < rarities.Length; i++)
        {
            if (dropWeight >= rarities[i])
            {
                return i;
            }
        }

        return -1;
    }

    private GameObject DropPowerupChest()
    {
        int drop = Random.Range(0, powerupChests.Length);
        return powerupChests[drop];
    }

    private GameObject DropGunChest()
    {
        int drop = Random.Range(0, gunChests.Length);
        return gunChests[drop];
    }
}
