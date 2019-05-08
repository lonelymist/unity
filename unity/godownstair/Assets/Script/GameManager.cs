using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public GameObject player;
    void Start()
    {
        restartButton.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Player.isDead)
        {
            player.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
