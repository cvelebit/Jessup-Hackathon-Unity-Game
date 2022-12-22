using UnityEngine;
using UnityEngine.UI;

public class HeathBarUpdate : MonoBehaviour
{
    private HitPointsManager playerHealth;
    private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HitPointsManager>();
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        healthBar.value = playerHealth.HealthRatio;
    }
}
