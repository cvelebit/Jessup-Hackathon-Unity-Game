using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpener : MonoBehaviour
{
    public string SceneToChangeTo;
    private Animator animator;

    private GameObject Player;

    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private float volume = 1f;
    [SerializeField]
    private int KillsToOpen = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")&&(GetPlayerKills()>=KillsToOpen))
        {
            animator.SetBool("OpenDoor", true);
        }
    }

    private void PlayClip()
    {
        if (SceneToChangeTo != null && SceneToChangeTo != "") { GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().StopMusic(); }
        AudioSource.PlayClipAtPoint(clip, this.transform.position, volume);
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(SceneToChangeTo);
    }

    private void OpenDoor()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void EndGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HitPointsManager>().Kill();
    }


    private int GetPlayerKills()
    {
        PlayerShooting PlayerShootingScript = Player.GetComponent<PlayerShooting>();
        return PlayerShootingScript.CurLevelKillCount;
    }
}
