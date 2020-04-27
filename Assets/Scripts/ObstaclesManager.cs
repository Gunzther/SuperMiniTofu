using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesManager : MonoBehaviour
{
    public GameObject pipe, panel;
    public AudioSource scoreUpSFX, gameoverSFX;
    public Text textScore;
    public int score = 0, best = 0;

    public bool gameOver;
    public float speed;
    float timer;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Best"))
        {
            best = PlayerPrefs.GetInt("Best");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) timer += Time.deltaTime;
        if (timer >= 10)
        {
            speed += 0.5f;
            timer = 0;
        }
    }

    public void GenerateLevel()
    {
        for (int i = 1; i <= 4; i++)
        {
            GameObject.Instantiate(pipe).transform.position = new Vector3((i*12) + 40, Random.Range(-2f, 1.5f), 0);
        }
    }

    public void GenerateSingleObstacle()
    {
        GameObject.Instantiate(pipe).transform.position = new Vector3(40, Random.Range(-2f, 1.5f), 0);
    }

    public void ScoreUp()
    {
        if (gameOver) return;
        scoreUpSFX.Play();
        score++;
        textScore.text = score.ToString();

        if (score > best)
        {
            best = score;
        }
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameoverSFX.Play();
            gameOver = true;
            PlayerPrefs.SetInt("Best", best);
            PlayerPrefs.Save();
            panel.SetActive(true);
            panel.transform.GetChild(0).GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetInt("Best").ToString();
        }
    }
}
