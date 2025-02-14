using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;
    private int _highScore;

    [SerializeField] private TextMeshProUGUI scoreText;  // UI ������� ��� ����������� �����
    [SerializeField] private TextMeshProUGUI highScoreText; // UI ������� ��� ����������� �������

    private void Awake()
    {
        // ��������� ��������
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

        LoadScores();  // ��������� ���������� ����
        UpdateScoreText();
        UpdateHighScoreText();
    }

    // ����� ��� ���������� �����
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreText();

        // �������� �� ������
        if (_score > _highScore)
        {
            _highScore = _score;
            SaveHighScore();  // ��������� ����� ������
            UpdateHighScoreText();
        }
    }

    // ����� ��� �������� ����� � �������
    private void LoadScores()
    {
        _score = 0; // �������� � ���� ��� ������ ������ ����
        _highScore = PlayerPrefs.GetInt("HighScore", 0);  // ��������� ������
    }

    // ����� ��� ���������� �������
    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _highScore);  // ��������� ������
        PlayerPrefs.Save();
    }

    // ����� ��� ���������� ������ � �������� ������
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + _score.ToString();
        }
    }

    // ����� ��� ���������� ������ � ��������
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
        _highScore = 0; // ��������� ��������� ������
        UpdateHighScoreText();
    }
}
