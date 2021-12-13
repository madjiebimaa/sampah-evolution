using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BroomFishController : MonoBehaviour
{
    public float speed = 0;
    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI hpText;
    // public TextMeshProUGUI batteryText;
    // public TextMeshProUGUI gameOverText;
    // public TextMeshProUGUI evolutionText;
    // public string Name;
    // private int scores;
    // private int hp;
    // private int battery;
    private Rigidbody2D rb;
    private BoxCollider2D boxPlayer;
    private float movementX;
    private float movementY;
    private float gameSpeed;
    // public HealthBar healthBar;
    // public HealthBar batteryBar;

    private GameManager gameManager;

    public Animator animator;

    // private void SetScoreText()
    // {
    //     scoreText.text = "Score : " + scores.ToString();
    // }

    // private void SetHPText()
    // {
    //     hpText.text = "HP : " + hp.ToString();
    // }

    // private void SetBatteryText()
    // {
    //     batteryText.text = "Battery : " + battery.ToString();
    //     battery--;
    // }

    // private void SetEvolution(int tier)
    // {
    //     if (tier == 0)
    //     {
    //         evolutionText.text = " ";

    //     }
    //     else
    //     {

    //         if (tier == 2)
    //         {
    //             boxPlayer.size = new Vector2(6.0f, 3.0f);
    //         }
    //         if (tier == 3)
    //         {
    //             boxPlayer.size = new Vector2(7.75f, 4.0f);
    //         }
    //         evolutionText.text = "Tier " + tier;
    //     }

    // }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxPlayer = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // scores = 0;
        // hp = 100;
        // battery = 1000;

        // SetScoreText();
        // SetHPText();
        // SetBatteryText();
        // SetEvolution("tier 1");

        // healthBar.SetMaxHealth(hp);
        // batteryBar.SetMaxHealth(battery);
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

        // Debug.Log("HP");

        // if (hp > 0)
        // {
        //     SetHPText();
        // }
        // else
        // {
        //     gameOverText.text = "Meninggal :)";
        // }

        // if (battery > 0)
        // {
        //     SetBatteryText();
        // }
        // else
        // {
        //     gameOverText.text = "Meninggal :)";
        // }

        // if (scores < 100)
        // {
        //     SetEvolution(0);
        // }

        // if (scores == 100)
        // {
        //     Name = "Tier2";
        //     SetEvolution(2);
        // }

        // if (scores > 100 && scores < 500)
        // {
        //     SetEvolution(0);
        // }

        // if (scores == 500)
        // {
        //     Name = "Tier3";
        //     SetEvolution(3);
        // }

        // if (scores > 500)
        // {
        //     SetEvolution(0);
        // }

        // healthBar.setHealth(hp);
        // batteryBar.setHealth(battery);

        if (gameManager.getTier() == 2)
        {
            boxPlayer.size = new Vector2(6.0f, 3.0f);
            animator.SetInteger("Tier", 2);
        }
        if (gameManager.getTier() == 3)
        {
            boxPlayer.size = new Vector2(7.75f, 4.0f);
            animator.SetInteger("Tier", 3);
        }



        gameManager.UpdateBattery(-1);
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
            //scores += 5;

            //SetScoreText();
            gameManager.UpdateScore(5);
            FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);
        }

        if (other.gameObject.CompareTag("Sampah_7"))
        {
            other.gameObject.SetActive(false);
            //scores += 7;

            //SetScoreText();
            gameManager.UpdateScore(7);
            FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);
        }

        if (other.gameObject.CompareTag("Sampah_15"))
        {
            other.gameObject.SetActive(false);
            // scores += 15;

            // SetScoreText();
            gameManager.UpdateScore(15);
            FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);
        }

        if (other.gameObject.CompareTag("Sampah_20"))
        {
            other.gameObject.SetActive(false);

            // if (Name == "Tier2")
            // {
            //     scores += 20;
            // }
            // else
            // {
            //     hp -= 10;
            // }

            // SetScoreText();

            if (gameManager.getTier() >= 2)
            {
                gameManager.UpdateScore(20);
                FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);

            }
            else
            {
                gameManager.UpdateHealth(-10);
                FishCrashAudio.sfxInstance.Audio.PlayOneShot(FishCrashAudio.sfxInstance.Click);
            }
        }

        if (other.gameObject.CompareTag("Sampah_50"))
        {
            // other.gameObject.SetActive(false);
            // if (Name == "Tier2")
            // {
            //     scores += 50;
            // }
            // else
            // {
            //     hp -= 10;
            // }

            // SetScoreText();

            if (gameManager.getTier() >= 2)
            {
                gameManager.UpdateScore(50);
                FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);
            }
            else
            {
                gameManager.UpdateHealth(-10);
                FishCrashAudio.sfxInstance.Audio.PlayOneShot(FishCrashAudio.sfxInstance.Click);
            }
        }

        if (other.gameObject.CompareTag("Sampah_100"))
        {
            // other.gameObject.SetActive(false);
            // if (Name == "Tier2")
            // {
            //     scores += 100;
            // }
            // else
            // {
            //     hp -= 20;
            // }
            // SetScoreText();
            if (gameManager.getTier() >= 2)
            {
                gameManager.UpdateScore(100);
                FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);

            }
            else
            {
                gameManager.UpdateHealth(-20);
                FishCrashAudio.sfxInstance.Audio.PlayOneShot(FishCrashAudio.sfxInstance.Click);
            }
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            // battery += 1000;
            gameManager.UpdateBattery(1000);
            FishEatAudio.sfxInstance.Audio.PlayOneShot(FishEatAudio.sfxInstance.Click);

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            // hp -= 10;
            gameManager.UpdateHealth(-10);
            FishCrashAudio.sfxInstance.Audio.PlayOneShot(FishCrashAudio.sfxInstance.Click);
        }
    }

}