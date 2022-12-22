using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{

    public bool touchingPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer)
        {
            ActivateEffect();
            Destroy(this.gameObject);
        }
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

    protected virtual void ActivateEffect(){}
}
