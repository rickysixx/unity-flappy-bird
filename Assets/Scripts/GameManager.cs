using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    private Text scoreDisplay;

    [SerializeField]
    private GameObject playButton;

    [SerializeField]
    private GameObject gameOverMessage;

    [SerializeField]
    private GameObject getReadyMessage;

    [SerializeField]
    private Bird player;

    public static GameManager Instance { get; private set; }

    private void InitializeGameUI()
    {
        scoreDisplay.text = "0";
        playButton.SetActive(true);
        gameOverMessage.SetActive(false);
        getReadyMessage.SetActive(true);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            InitializeGameUI();
            ResetScore();
            Pause();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void RemoveAllPipes()
    {
        foreach (var pipe in FindObjectsOfType<PipeContainer>())
        {
            Destroy(pipe.gameObject);
        }
    }

    private void ResetScore()
    {
        score = 0;
        scoreDisplay.text = "0";
    }

    private void DisableUI()
    {
        playButton.SetActive(false);
        gameOverMessage.SetActive(false);
        getReadyMessage.SetActive(false);
    }

    private void Pause()
    {
        /*
         * By setting the time scale to 0, Update methods will not be invoked.
         * In our game, this means that pipes, background and ground will not move, so this is equivalent of pausing the game.
         */
        Time.timeScale = 0f;

        player.enabled = false;
    }

    public void GameOver()
    {
        Debug.Log("Game over.");

        gameOverMessage.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void StartGame()
    {
        DisableUI();
        ResetScore();
        RemoveAllPipes(); // clean any pipes from the previous game

        Time.timeScale = 1f;

        player.enabled = true;
    }

    public void IncreaseScore()
    {
        score++;
        scoreDisplay.text = score.ToString();
    }
}
