using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject body1, body2;
    // public GameObject tilemap1, tilemap2;
    // private Color color1, color2;
    private int level = 0; // 0 is main menu

    void Awake() {
        if (instance != null) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    void Start()
    {
        // color1 = tilemap1.GetComponent<Tilemap>().color;
        // color2 = tilemap2.GetComponent<Tilemap>().color;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Q) && SceneManager.GetActiveScene().name == "MainMenu") {
            Application.Quit();
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win() {
        level++;
        if (level < 6) {
            SceneManager.LoadScene("Level" + level);
        } else {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
