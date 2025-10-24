using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public UIDocument uiDocument;

    private float score = 0f;
    private Label scoreText;

    private static Button restartButton;

    void Start()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        InitRestartButton();
    }

    void Update()
    {
        UpdateScore();
    }

    void InitRestartButton()
    {
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += SceneLoader.RunRelaadGameScene;
    }

    public static void DisplayRestartButton()
    {
        restartButton.style.display = DisplayStyle.Flex;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
