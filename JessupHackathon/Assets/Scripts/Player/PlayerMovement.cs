using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementDirection;

    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private float volume = 1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = GlobalVariables.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        Animate();
    }

    void PlayerMoveKeyboard()
    {
        movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        movementDirection.Normalize();

        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0f) * Time.deltaTime * speed;
    }

    void Animate()
    {
        anim.SetFloat("Horizontal", movementDirection.x);
        anim.SetFloat("Vertical", movementDirection.y);
        if (movementDirection.x > 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

    private void PlayClip()
    {
        AudioSource.PlayClipAtPoint(clip, this.transform.position, volume);
    }

    void ProcessInputs() {

    }

    public void addSpeed(float speedUpAmount)
    {
        speed += speedUpAmount;
    }

    private void OnDestroy()
    {
        GlobalVariables.Speed = speed;
    }
}
