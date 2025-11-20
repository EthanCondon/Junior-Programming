using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    public GameManager gameManager;
    public int difficulty;

    void Start()
    {
        button = GetComponent<Button>();
	button.onClick.AddListener(SetDifficulty);
	gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " clicked");
        gameManager.StartGame(difficulty);
    }
}
