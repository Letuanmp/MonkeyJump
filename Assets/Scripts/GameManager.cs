﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player player;
    public Spawner spawner;
    public Text scoreText;

    public GameObject gameOver;
    public GameObject newGame;
    public GameObject resetGame;


    private int score = 0; // Điểm số hiện tại

    private void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString(); // Cập nhật số vào đối tượng Text
    }

    // Gọi phương thức UpdateScore() khi Spawner chết
    public void SpawnerDeath()
    {
        UpdateScore();
    }
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        spawner = FindAnyObjectByType<Spawner>();  
    }
    private void Pause()
    {
        
        Time.timeScale = 0f; // Đặt Time.timeScale thành 0
    }
    public void NewGame()
    {
        gameOver.SetActive(false);
        newGame.SetActive(false);
        resetGame.SetActive(false);
        Time.timeScale = 1f;

        // Reset the current scene
        //RestartCurrentScene();
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2f);
        
    }
    public void Back()
    {
        SceneManager.LoadScene("PlayScreen");
        Time.timeScale = 1f;
    }

    //public void RestartCurrentScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    Time.timeScale = 1f;
    //}
    public void GameOver()
    {
        Wait();
        Pause();
        gameOver.SetActive( true);
        newGame.SetActive( true);
        resetGame.SetActive( true);
        FindObjectOfType<AudioManager>().Mute();
        
    }

    public void Point()
    {
         spawner.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }
}
