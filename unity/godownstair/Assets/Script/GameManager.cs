using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    // 設定重新開始按鈕

    public GameObject player;
    // 抓取角色

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        // 開始時將按鈕隱藏

    }
    void Update()
    {
        if (Player.isDead)
        {
            player.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
        // 角色死亡時 角色隱藏 按鈕顯示
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 重新載入當前場景
    }
}
