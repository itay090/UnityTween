using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] GameObject Cam;
    [SerializeField] SpriteRenderer Sprite;
    private float length, startpos;
    public float parallaxefx;

    void Start()
    {
        startpos = transform.position.x;
        length = Sprite.bounds.size.x;
    }

   
    void FixedUpdate()
    {
        float temp = (Cam.transform.position.x * (1 - parallaxefx));
        float dist = (Cam.transform.position.x * parallaxefx);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
