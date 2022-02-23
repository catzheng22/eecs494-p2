using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public bool willChangeColor = true;
    public float moveSpeed = 3;
    public float bufferTime = 0.5f;
    public Vector3 offset;
    private Vector3 origin;
    private bool returning = false, moving = true;
    private CanChangeColor canChangeColor;

    void Start() {
        origin = transform.position;
        canChangeColor = GetComponent<CanChangeColor>();
    }

    void Update()
    {
        if (moving) {
            if (returning) {
                transform.position = Vector3.MoveTowards(transform.position, origin, moveSpeed * Time.deltaTime);
                if (transform.position == origin) {
                    StartCoroutine(Wait());
                    returning = false;
                }
            } else {
                transform.position = Vector3.MoveTowards(transform.position, origin+offset, moveSpeed * Time.deltaTime);
                if (transform.position == origin+offset) {
                    StartCoroutine(Wait());
                    returning = true;
                }
            }
        }
    }

    private IEnumerator Wait() {
        moving = false;
        yield return new WaitForSeconds(bufferTime);
        if (canChangeColor && willChangeColor) {
            canChangeColor.ChangeColor();
        }
        yield return new WaitForSeconds(bufferTime);
        moving = true;
    }
}
