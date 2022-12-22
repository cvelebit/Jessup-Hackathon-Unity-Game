using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector2 tempPos;

    [SerializeField]
    private Vector2 max;
    [SerializeField]
    private Vector2 min;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        if (max == min)
        {
            transform.position = new Vector3((player.position.x), (player.position.y), -10f);
            return;
        }
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;
        if (tempPos.x > max.x)
        {
            tempPos.x = max.x;
        }
        else if (tempPos.x < min.x)
        {
            tempPos.x = min.x;
        }

        if (tempPos.y > max.y)
        {
            tempPos.y = max.y;
        }
        else if (tempPos.y < min.y)
        {
            
            tempPos.y = min.y;Debug.Log(tempPos+ ": " + player.position);
        }
        transform.position = new Vector3 (tempPos.x, tempPos.y, -10f);
        
    }

    public void StopMusic()
    {
        AudioSource src = this.GetComponent<AudioSource>();
        src.enabled = false;
    }

    private void OnDrawGizmos()
    {
        //Camera position bounds
        //top line
        Gizmos.DrawLine(new Vector3(min.x, max.y), max);
        //left side
        Gizmos.DrawLine(min, new Vector3(min.x, max.y));
        //bottom line
        Gizmos.DrawLine(min, new Vector3(max.x, min.y));
        //right line
        Gizmos.DrawLine(max, new Vector3(max.x, min.y));

        //Camera viewport bounds
        float cameraHeight = GetComponent<Camera>().orthographicSize;
        float cameraWidth = cameraHeight * GetComponent<Camera>().aspect;
        Vector2 viewportMin = new Vector2(min.x - cameraWidth, min.y - cameraHeight);
        Vector2 viewportMax = new Vector2(max.x + cameraWidth, max.y + cameraHeight);
        // top line
        Gizmos.DrawLine(new Vector3(viewportMin.x, viewportMax.y), viewportMax);
        //left side
        Gizmos.DrawLine(viewportMin, new Vector3(viewportMin.x, viewportMax.y));
        //bottom line
        Gizmos.DrawLine(viewportMin, new Vector3(viewportMax.x, viewportMin.y));
        //right line
        Gizmos.DrawLine(viewportMax, new Vector3(viewportMax.x, viewportMin.y));
    }
}
