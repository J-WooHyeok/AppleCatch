using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameDi : MonoBehaviour
{
    GameObject timeText;
    GameObject pointText;
    GameObject bestScoreText;
    float time = 30.0f;
    int point = 0;
    int bestScore = 0;
    GameObject generator;

    void Start()
    {
        this.timeText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.bestScoreText = GameObject.Find("BestScore");
        this.generator = GameObject.Find("ItemGenerator");
        GameObject restartButton = GameObject.Find("RestartButton");
        if (restartButton != null)
        {
            restartButton.GetComponent<Button>().onClick.AddListener(RestartGame);
        }
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreUI();
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenarator>().SetParameter(1000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<ItemGenarator>().SetParameter(0.9f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenarator>().SetParameter(0.4f, -0.06f, 6);
        }
        else if (15 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenarator>().SetParameter(0.7f, -0.04f, 4);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenarator>().SetParameter(1.0f, -0.03f, 2);
        }

        this.timeText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + "point";
    }

    public void GetApple()
    {
        this.point += 50;
        UpdateBestScore();
    }

    public void GetBomb()
    {
        this.point /= 2;
        UpdateBestScore();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UpdateBestScore()
    {
        if (point > bestScore)
        {
            bestScore = point;
            PlayerPrefs.SetInt("BestScore", bestScore); 
            UpdateBestScoreUI();
        }
    }
    void UpdateBestScoreUI()
    {
        bestScoreText.GetComponent<TextMeshProUGUI>().text = "Best Score: " + bestScore.ToString();
    }
}