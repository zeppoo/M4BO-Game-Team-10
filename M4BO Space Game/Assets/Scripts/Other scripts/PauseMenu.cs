using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject crossAir;

    private bool isPaused = false;

    private void pause()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        crossAir.SetActive(false);
        gameObject.GetComponent<Canvas>().enabled = true;
        isPaused = true;

        Time.timeScale = 0;

        player.GetComponent<PlayerController>().enabled = false;
    }

    public void _resume()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        crossAir.SetActive(true);
        gameObject.GetComponent<Canvas>().enabled = false;
        isPaused = false;
        Time.timeScale = 1;

        player.GetComponent<PlayerController>().enabled = true;
    }

    public void _mainMenu()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<Canvas>().enabled = false;
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");

        player.GetComponent<PlayerController>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                this.pause();
            }
            else
            {
                this._resume();
            }
        }
    }
}
