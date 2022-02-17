using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadow : MonoBehaviour
{
    public Vector2 offset = new Vector2(-1,-1);

    private SpriteRenderer spriteRndCaster;
    private SpriteRenderer spriteRndShadow;

    private Transform transCaster;
    private Transform transShadow;

    void Start() {

    }
}
