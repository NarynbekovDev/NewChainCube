using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;
    private int _highScore;

    [SerializeField] private TextMeshProUGUI scoreText;  // UI элемент для отображения очков
    [SerializeField] private TextMeshProUGUI highScoreText; // UI элемент для отображения рекорда

    private void Awake()
    {
        // Реализуем синглтон
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //YandexGame.NewLeaderoardScored("LiderBoardChainCube", _highScore);

        LoadScores();  // Загружаем сохранённые очки
        UpdateScoreText();
        UpdateHighScoreText();
    }

    // Метод для увеличения очков
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreText();

        // Проверка на рекорд
        if (_score > _highScore)
        {
            _highScore = _score;
            SaveHighScore();  // Сохраняем новый рекорд
            UpdateHighScoreText();
        }
    }

    // Метод для загрузки очков и рекорда
    private void LoadScores()
    {
        _score = 0; // Начинаем с нуля при каждом старте игры
        _highScore = PlayerPrefs.GetInt("HighScore", 0);  // Загружаем рекорд
    }

    // Метод для сохранения рекорда
    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _highScore);  // Сохраняем рекорд
        PlayerPrefs.Save();
    }

    // Метод для обновления текста с текущими очками
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + _score.ToString();
        }
    }

    // Метод для обновления текста с рекордом
    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = _highScore.ToString();
        }
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.Save();
        _highScore = 0; // Обновляем локальный рекорд
        UpdateHighScoreText();
    }
}
