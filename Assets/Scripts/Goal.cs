using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float revSpeed = 50f;
    public LayerMask layerMask;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb2d.MoveRotation(rb2d.rotation + revSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D() {
        Collider2D[] others = Physics2D.OverlapBoxAll(rb2d.position, new Vector2(0.5f, 0.5f), rb2d.rotation, layerMask);
        int count = 0;
        foreach (var other in others) {
            if (other.gameObject.CompareTag("Player")) {
                count++;
            }
        }
        if (count >= 2) {
            GameController.instance.Win();
        }
    }
}
