using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject : MonoBehaviour
{
    public int level;
    public float revSpeed = 50f;
    public LayerMask playerLayers;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb2d.MoveRotation(rb2d.rotation + revSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D() {
        Collider2D[] selected = Physics2D.OverlapBoxAll(rb2d.position, transform.localScale, rb2d.rotation, playerLayers);
        if (selected.Length == 1) {
            transform.localScale *= 2f;
        }
        else if (selected.Length == 2) {
            SceneManager.LoadScene(level);
        }
    }

    private void OnTriggerExit2D() {
        Collider2D[] selected = Physics2D.OverlapBoxAll(rb2d.position, transform.localScale, rb2d.rotation, playerLayers);
        if (selected.Length == 0) {
            transform.localScale /= 2f;
        }
    }
}
