using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BroomFishController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI batteryText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI evolutionText;
    public string Name;
    private int scores;
    private int hp;
    private int battery;
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;
    private float gameSpeed;
    public HealthBar healthBar;
    public HealthBar batteryBar;

    private void SetScoreText()
    {
        scoreText.text = "Score : " + scores.ToString();
    }

    private void SetHPText()
    {
        hpText.text = "HP : " + hp.ToString();
    }

    private void SetBatteryText()
    {
        batteryText.text = "Battery : " + battery.ToString();
        battery--;
    }

    private void SetEvolution(string tier)
    {
        evolutionText.text = tier;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        scores = 0;
        hp = 100;
        battery = 1000;

        SetScoreText();
        SetHPText();
        SetBatteryText();
        // SetEvolution("tier 1");

        healthBar.SetMaxHealth(hp);
        batteryBar.SetMaxHealth(battery);
    }

    void Update()
    {

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
        //     rb.velocity = transform.right * speed;
        // }

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
        //     rb.velocity = -transform.right * speed;
        // }

        Debug.Log("HP");

        if (hp > 0)
        {
            SetHPText();
        }
        else
        {
            gameOverText.text = "Meninggal :)";
        }

        if (battery > 0)
        {
            SetBatteryText();
        }
        else
        {
            gameOverText.text = "Meninggal :)";
        }

        if (scores < 100) {
            SetEvolution("");
        }

        if (scores == 100) {
            Name = "Tier2";
            SetEvolution("tier 2");
        }

        if (scores > 100 && scores < 500) {
            SetEvolution("");
        }

        if (scores == 500) {
            Name = "Tier3";
            SetEvolution("tier 3");
        }

        if (scores > 500) {
            SetEvolution("");
        }

        healthBar.setHealth(hp);
        batteryBar.setHealth(battery);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sampah_5"))
        {
            other.gameObject.SetActive(false);
            scores+=5;

            SetScoreText();
        }

        if (other.gameObject.CompareTag("Sampah_7"))
        {
            other.gameObject.SetActive(false);
            scores+=7;

            SetScoreText();
        }

        if (other.gameObject.CompareTag("Sampah_15"))
        {
            other.gameObject.SetActive(false);
            scores+=15;

            SetScoreText();
        }

        if (other.gameObject.CompareTag("Sampah_20"))
        {
            other.gameObject.SetActive(false);
            if (Name == "Tier2") {
                scores+=20;
            } else {
                hp-=10;
            }

            SetScoreText();
        }

        if (other.gameObject.CompareTag("Sampah_50"))
        {
            other.gameObject.SetActive(false);
            if (Name == "Tier2") {
                scores+=50;
            } else {
                hp-=10;
            }

            SetScoreText();
        }

        if (other.gameObject.CompareTag("Sampah_100"))
        {
            other.gameObject.SetActive(false);
            if (Name == "Tier2") {
                scores+=100;
            } else {
                hp-=20;
            }
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            battery += 1000;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            hp -= 10;
        }
    }

}