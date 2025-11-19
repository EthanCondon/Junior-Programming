using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    public GameManager gameManager; // assign in inspector
    public int difficulty = 1;

    void Start()
    {
        button = GetComponent<Button>();
        if (button != null && gameManager != null)
            button.onClick.AddListener(SetDifficulty);
        else
            Debug.LogError("Button or GameManager not assigned!");
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " clicked");
        gameManager.StartGame(difficulty);
    }
}
