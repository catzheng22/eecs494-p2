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

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && SceneManager.GetActiveScene().buildIndex == 0) {
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
