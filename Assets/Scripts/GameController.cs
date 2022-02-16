using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject body1, body2;
    public GameObject tilemap1, tilemap2;
    public GameObject victoryText;
    private Color color1, color2;
    private bool playerWon = false;

    void Awake() {
        if (instance != null) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    void Start()
    {
        color1 = tilemap1.GetComponent<Tilemap>().color;
        color2 = tilemap2.GetComponent<Tilemap>().color;
        victoryText.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win() {
        if (!playerWon) {
            playerWon = true;
            victoryText.SetActive(true);
        }
        // StartCoroutine(TriggerVictory());
    }

    // private IEnumerator TriggerVictory() {
    //     Debug.Log("You Won!");
    //     victoryText.SetActive(true);
    // }

    public void ExitGame() {
        Application.Quit();
    }
}
