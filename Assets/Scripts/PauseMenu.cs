using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool paused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused) {
                Pause();
            } else {
                Resume();
            }
            paused = !paused;
        }
        if (pauseMenu.activeSelf && Input.GetKeyDown(KeyCode.Q)) {
            Quit(0);
        }
    }
    
    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit(int sceneID) {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
