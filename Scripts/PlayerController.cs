using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject SpawnerEnvironment;
    private Rigidbody2D rb;
    public Vector2 directionOfMovement;
    public float speed;
    private bool IsVulnerable = true;

    [SerializeField] private Animator animator;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private GameObject GameOver_Panel;
    private int livesCount;
    [SerializeField] private List<GameObject> Lives_HUD = new List<GameObject>(3);

    private int scoresCounter;
    [SerializeField] private TMPro.TMP_Text ScoresHUD;

    [SerializeField] private ParticleSystem GettingScore_ParticleSystem;
    [SerializeField] private ParticleSystem SnowScattering_ParticleSystem;

    [SerializeField] private AudioSource LossAudio;

    private void Awake() 
    {
        if (SaveManager.instance.hasLoaded)
            StaticLibrary.difficultyLevel = SaveManager.instance.activeSave.difficultyLevel;
        else
            StaticLibrary.difficultyLevel = 1;
    }
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        livesCount = 3;
        IsVulnerable = true;

        SpawnerEnvironment = GameObject.FindGameObjectWithTag("Spawner");

        GameOver_Panel.SetActive(false);

        scoresCounter = 0;

        switch (StaticLibrary.difficultyLevel)
        {
            case 1:
                speed = 3f;
                break;
            case 2:
                speed = 5f;
                break;
            case 3:
                speed = 7f;
                break;
        }
    }

    private void Update() 
    {
        GetDirectionOfMovementPlayer();
        SetParametersFromAnimatorPlayer();
    }

    private void FixedUpdate() 
    {
        MovePlayer();
    }

    private void GetDirectionOfMovementPlayer()
    {
        directionOfMovement.x = joystick.Horizontal;
        directionOfMovement.y = joystick.Vertical;
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(directionOfMovement.x * speed, 0);
    }

    private void SetParametersFromAnimatorPlayer()
    {
        animator.SetFloat("Horizontal", directionOfMovement.x);
        animator.SetFloat("Vertical", directionOfMovement.y);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        OnTriggerWithTriggerForSpawn(trigger);
        OnTriggerWithDanger(trigger);
        OnTriggerWithControlPoint(trigger);
    }

    private void OnTriggerWithTriggerForSpawn(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("TriggerForSpawn"))
            SpawnerEnvironment.GetComponent<SpawnerEnvironment>().Spawn();
    }

    private void OnTriggerWithDanger(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Danger") && IsVulnerable)
        {
            SnowScattering_ParticleSystem.Play();
            livesCount--;
            Lives_HUD[livesCount].SetActive(false);
            IsVulnerable = false;
            Invoke("ReturnVulnerability", 0.5f);

            if (livesCount < 1)
            {
                GameOver_Panel.SetActive(true);
                Time.timeScale = 0f;
                LossAudio.Play();

                if (scoresCounter > StaticLibrary.recordScore)
                {
                    StaticLibrary.recordScore = scoresCounter;
                    SaveManager.instance.activeSave.recordScore = StaticLibrary.recordScore;
                    SaveManager.instance.Save();
                }   
            }
        }
    }

    private void OnTriggerWithControlPoint(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("ControlPoint"))
        {
            Destroy(trigger.gameObject);
            GettingScore_ParticleSystem.Play();
            scoresCounter++;
            ScoresHUD.text = scoresCounter.ToString();
        }
    }

    private void ReturnVulnerability()
    {
        IsVulnerable = true;
    }
}