using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;

    Rigidbody2D rb;

    public float thrustForce = 1f;
    public float maxSpeed = 5f;

    public UIDocument uiDocument;
    private Label scoreText;

    public GameObject explosionEffect;
    public GameObject boosterFlame;

    //for mobile
    public InputAction moveForward;
    public InputAction lookPosition;

    //나중에 따로 뺌
    private Button restartButton;
    public GameObject borderParent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");

        //for mobile
        moveForward.Enable();
        lookPosition.Enable();

        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        MovePlayer();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }


        //for mobile
        //if (moveForward.WasPressedThisFrame())
        //{
        //    boosterFlame.SetActive(true);
        //}
        //else if (moveForward.WasReleasedThisFrame())
        //{
        //    boosterFlame.SetActive(false);
        //}
    }

    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }

    void MovePlayer()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }

        //for mobile
        //if (moveForward.IsPressed())
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(lookPosition.ReadValue<Vector2>());
        //    Vector2 direction = (mousePos - transform.position).normalized;
        //    transform.up = direction;
        //    rb.AddForce(direction * thrustForce);

        //    if (rb.linearVelocity.magnitude > maxSpeed)
        //    {
        //        rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        //    }
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);

        restartButton.style.display = DisplayStyle.Flex;
        borderParent.SetActive(false);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
