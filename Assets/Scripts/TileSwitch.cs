using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwitch : MonoBehaviour
{
    public GameObject tile;
    public Color on, off;
    
    private CanChangeColor canChangeColor;

    void Start() {
        GetComponent<SpriteRenderer>().color = off;
        canChangeColor = tile.GetComponent<CanChangeColor>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // TODO add switch sound
        GetComponent<SpriteRenderer>().color = on;
        if (canChangeColor != null) {
            canChangeColor.ChangeColor();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        GetComponent<SpriteRenderer>().color = off;
        if (canChangeColor != null) {
            canChangeColor.ChangeColor();
        }
    }
}
