using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanChangeColor : MonoBehaviour
{
    private SpriteRenderer sprite;
    
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor() {
        sprite.color = sprite.color == Color.white ? Color.black : Color.white;
    }
}
