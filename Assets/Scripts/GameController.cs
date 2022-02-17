using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject body1, body2;

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
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Q) && SceneManager.GetActiveScene().name == "MainMenu") {
            Application.Quit();
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            SceneManager.LoadScene(0);
        }
    }
}
