using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    //public float aspectRatio;
	/*
    void Start ()
    {
        offset = transform.position - player.transform.position;

        // Beginning
        //aspectRatio = 3.0f / 2.0f;
        //float windowAspect = (float)Screen.width / (float)Screen.height;
        //float scaleheight = windowAspect / aspectRatio;
        Camera camera = GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        // End

        /*        
        // if scaled height is less than current height, add letterbox
         

    }
	*/
    void LateUpdate ()
    {
        transform.position = new Vector3( player.transform.position.x, transform.position.y, transform.position.z);
    }
}
