using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public bool active;
    public float moveSpeed = 3f;
    public Color myColor, dieColor;
    public static int becomeGhostCount = 0;

    private float X, Y;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    private PolygonCollider2D collider;
    private SpriteRenderer sprite;
    private Behaviour halo;
    private bool solid = true;

    public bool Solid {
        get {
            return solid;
        }
        set {
            solid = value;
            collider.enabled = solid;
            if (solid) {
                sprite.color = myColor;
            } else {
                sprite.color = new Color(myColor.r, myColor.g, myColor.b, myColor.a / 2);
            }
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        myColor = sprite.color;

        halo = (Behaviour) GetComponent("Halo");
        halo.enabled = active;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            active = !active;
            halo.enabled = active;
            rb2d.velocity = Vector2.zero;
        }

        if (active) {
            X = Input.GetAxisRaw("Horizontal");
            Y = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(X) > 0 || Mathf.Abs(Y) > 0) {
                direction.x = X;
                direction.y = Y;
                Move();
            }
            else {
                rb2d.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                if (solid && becomeGhostCount > 0) {
                    becomeGhostCount--;
                    Solid = false;
                } else {
                    Solid = true;
                }
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
            // else if (other.GetComponent<Tilemap>().color == myColor) {
            //     other.GetComponent<Tilemap>().color = dieColor;
            // }
        }
    }

    private IEnumerator Die() {
        active = false;
        rb2d.velocity = Vector2.zero;

        Color objectColor = sprite.color;
        float fadeAmount;
        while (sprite.color.a > 0)
        {
            fadeAmount = objectColor.a - (3 * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            sprite.color = objectColor;
            yield return null;
        }

        Destroy(gameObject);
        GameController.instance.Restart();
    }
}
