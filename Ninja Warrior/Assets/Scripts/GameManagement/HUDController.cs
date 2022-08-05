using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject PauseImg;
    [SerializeField] GameObject WinImg;
    [SerializeField] GameObject LoseImg;
    [SerializeField] GameObject TutorialImg;
    [SerializeField] GameObject StartImg;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        
        if (PlayerStatus.lives <= 0)
            StartCoroutine(Restartar());
    }

    IEnumerator Restartar()
    {
        yield return new WaitForSeconds(0.1f);
        LoseImg.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        PauseImg.SetActive(false);
        Time.timeScale = 1;
    }
    public void SeeTips()
    {
        StartImg.SetActive(false);
        TutorialImg.SetActive(true);
    }

    public void Back()
    {
        TutorialImg.SetActive(false);
        StartImg.SetActive(true);
    }

    public void Pause()
    {
        if (Time.timeScale == 0f)
        {
            PauseImg.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            PauseImg.SetActive(true);
            Time.timeScale = 0f;          
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
        WinImg.SetActive(false);
        Time.timeScale = 1;
    }
    public void TryAgain()
    {
        LoseImg.SetActive(false);
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
        PlayerStatus.lives = 3;
        Score.points = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        PauseImg.SetActive(false);
    }
}