using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ChestOpen : MonoBehaviour
{
    [FormerlySerializedAs("powerup")] public GameObject[] drops;
    public Sprite closedChest;
    public Sprite openChest;
    private SpriteRenderer renderer;
    private bool touchingPlayer;
    private BoxCollider2D boxCollider;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private float volume = 1f;
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = closedChest;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (touchingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            spawnDrop();
            PlayClip();
            renderer.sprite = openChest;

            boxCollider.enabled = false;


            StartCoroutine(delayDestroy(5));
        }
    }

    private void spawnDrop()
    {
        int dropNum = Random.Range(0, drops.Length);
        Instantiate(drops[dropNum], transform.position, Quaternion.identity);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            touchingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            touchingPlayer = false;
        }
    }

    IEnumerator delayDestroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

    private void PlayClip()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }
}
