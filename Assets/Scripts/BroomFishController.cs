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
    private int scores;
    private int hp;
    private int battery;
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;

    public HealthBar healthBar;
    public HealthBar batteryBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        scores = 0;
        hp = 100;
        battery = 1000;

        SetScoreText();
        SetHPText();
        SetBatteryText();
        healthBar.SetMaxHealth(hp);
        batteryBar.SetMaxHealth(battery);
    }

    void Update()
    {
        Debug.Log("HP");

        if (hp > 0)
        {
            SetHPText();
        }
        else
        {
            gameOverText.text = "MODAR SIA :)";
        }

        if (battery > 0)
        {
            SetBatteryText();
        }
        else
        {
            gameOverText.text = "MODAR SIA :)";
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

    private void FixedUpdate()
    {
        // Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        Vector2 movement = new Vector2(movementX, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sampah"))
        {
            other.gameObject.SetActive(false);
            scores++;

            SetScoreText();
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            battery += 100000;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            hp -= 10;
        }
    }

}