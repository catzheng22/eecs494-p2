using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowEffect : MonoBehaviour
{
    SpriteRenderer sprite;
    public float rainbowSpeed = 30f;
    private float hue, sat, bri;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sat = 1;
        bri = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Color.RGBToHSV(sprite.color, out hue, out sat, out bri);
        hue += rainbowSpeed / 10000;
        if (hue >= 1) {
            hue = 0;
        }
        sprite.color = Color.HSVToRGB(hue, sat, bri);
    }
}
