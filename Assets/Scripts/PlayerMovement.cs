using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public bool active;
    public float moveSpeed = 3f;
    public Color myColor, dieColor;

    private float X, Y;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    private Behaviour halo;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halo = (Behaviour) GetComponent("Halo");
        halo.enabled = active;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            active = !active;
            halo.enabled = active;
        }

        if (active) {
            X = Input.GetAxis("Horizontal");
            Y = Input.GetAxis("Vertical");

            if (Mathf.Abs(X) > 0 || Mathf.Abs(Y) > 0) {
                direction.x = X;
                direction.y = Y;
                Move();
            }
            else {
                rb2d.velocity = Vector2.zero;
            }
        }
    }

    private void Move() {
        rb2d.velocity = moveSpeed * direction;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Tilemap>() != null) {
            if (other.GetComponent<Tilemap>().color == dieColor) {
                StartCoroutine(Die());
            }
            else if (other.GetComponent<Tilemap>().color == myColor) {
                other.GetComponent<Tilemap>().color = dieColor;
            }
        }
    }

    private IEnumerator Die() {
        active = false;
        rb2d.velocity = Vector2.zero;

        Color objectColor = GetComponent<SpriteRenderer>().color;
        float fadeAmount;
        while (GetComponent<SpriteRenderer>().color.a > 0)
        {
            fadeAmount = objectColor.a - (3 * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            GetComponent<SpriteRenderer>().color = objectColor;
            yield return null;
        }

        Destroy(gameObject);
        GameController.instance.Restart();
    }
}
