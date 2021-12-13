using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject batteryPrefabs;
    public int batteryTimeSpawn;
    public int batteryCountSpawn;
    public List<GameObject> sampahPrefabs;
    public float[] peluangSampah;
    public int sampahCountSpawn;
    public int sampahTimeSpawn;
    public bool isGameActive;

    private int score;
    private int battery;
    private int health;
    private int tier;
    private float timeStop;
    public HealthBar healthBar;
    public HealthBar batteryBar;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI evolutionText;

    public Button restartButton;
    public Button mainMenuButton;
    public Button resumeButton;

    private float leftMap = -90.0f;
    private float rightMap = 90.0f;
    private float topMap = 60.0f;
    private float bottomMap = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 100;
        battery = 1000;

        for (int i = 0; i < sampahCountSpawn; i++)
        {
            int index = Random.Range(0, sampahPrefabs.Count);

            Instantiate(sampahPrefabs[index], RandomSpawnPosition(), sampahPrefabs[index].transform.rotation);

        }
        isGameActive = true;
        tier = 0;
        StartCoroutine(SpawnSampah());
        StartCoroutine(SpawnBattery());

        healthBar.SetMaxHealth(health);
        batteryBar.SetMaxHealth(battery);

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(health);
        batteryBar.setHealth(battery);

        CheckTier();

        if (health == 0 || battery == 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnSampah()
    {
        while (isGameActive)
        {

            yield return new WaitForSeconds(sampahTimeSpawn);

            for (int i = 0; i < sampahCountSpawn; i++)
            {
                int index = GetRandomSampah();

                Instantiate(sampahPrefabs[index], RandomSpawnPosition(), sampahPrefabs[index].transform.rotation);

            }
        }
    }

    IEnumerator SpawnBattery()
    {
        while (isGameActive)
        {

            yield return new WaitForSeconds(batteryTimeSpawn);

            for (int i = 0; i < batteryCountSpawn; i++)
            {

                Instantiate(batteryPrefabs, RandomSpawnPosition(), batteryPrefabs.transform.rotation);

            }
        }
    }

    private int GetRandomSampah()
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < peluangSampah.Length; i++)
            total += peluangSampah[i];

        for (int i = 0; i < sampahPrefabs.Count; i++)
        {
            if (peluangSampah[i] / total + numForAdding >= random)
                return i;
            else
                numForAdding += peluangSampah[i] / total;
        }
        return 0;

    }

    Vector2 RandomSpawnPosition()
    {
        float spawnPosX = Random.Range(leftMap, rightMap);
        float spawnPosY = Random.Range(bottomMap, topMap);

        Vector2 spawnPosition = new Vector2(spawnPosX, spawnPosY);
        return spawnPosition;

    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score : " + score;
    }

    public void UpdateBattery(int addBattery)
    {
        battery += addBattery;
    }

    public void UpdateHealth(int addHealth)
    {
        health += addHealth;
    }

    void CheckTier()
    {
        if (score >= 0 && tier == 0)
        {
            timeStop = Time.time + 3;
            tier = 1;
            ShowTier(timeStop);


        }
        else if (score >= 100 && tier == 1)
        {
            timeStop = Time.time + 3;

            tier = 2;
            ShowTier(timeStop);

        }
        else if (score >= 300 && tier == 2)
        {
            timeStop = Time.time + 3;

            tier = 3;
            ShowTier(timeStop);

        }

        if (Time.time > timeStop)
        {
            evolutionText.gameObject.SetActive(false);

        }
    }
    void ShowTier(float time)
    {
        evolutionText.text = "Tier : " + tier;
        evolutionText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public int getTier()
    {
        return tier;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

