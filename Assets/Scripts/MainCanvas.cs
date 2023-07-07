using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas Instance { get; private set; }
    public Text scoreText;
    public Text bossText;

    public GameObject menu;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        scoreText.text = $"分数：{GameManager.Instance.score:0}";
        bossText.text = $"小恶魔：\n" +
            $"肚子：{GameManager.Instance.boss.food:0}\n" +
            $"生命：{GameManager.Instance.boss.health:0}";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnGameOver();
        }
    }

    public void OnGameOver()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//如果是在unity编译器中
#else
        Application.Quit();//否则在打包文件中
#endif
    }
}
