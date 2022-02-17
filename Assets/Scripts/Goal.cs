using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float revSpeed = 50f;
    public LayerMask playerLayers;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.localScale = Vector3.one / 2f;
    }

    private void FixedUpdate() {
        rb2d.MoveRotation(rb2d.rotation + revSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D() {
        Collider2D[] playersReachedGoal = Physics2D.OverlapBoxAll(rb2d.position, transform.localScale, rb2d.rotation, playerLayers);
        if (playersReachedGoal.Length == 1) {
            transform.localScale *= 2f;
        }
        else if (playersReachedGoal.Length == 2) {
            GameController.instance.Win();
        }
    }

    private void OnTriggerExit2D() {
        Collider2D[] playersReachedGoal = Physics2D.OverlapBoxAll(rb2d.position, transform.localScale, rb2d.rotation, playerLayers);
        if (playersReachedGoal.Length == 0) {
            transform.localScale /= 2f;
        }
    }
}
