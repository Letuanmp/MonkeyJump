using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player player;
    public Spawner spawner;
    public Text scoreText; 

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
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        Pause();
    }

    public void Point()
    {
         spawner.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }
}
