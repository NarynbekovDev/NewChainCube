using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] musicClips; // ������ � ������� �������

    public Slider volumeSlider;

    private int currentTrackIndex = 0;

    private void Awake()
    {
        // ��������� �������� ��� MusicManager
        if (Instance == null)
        {
            Instance = this;
        }

        // ��������� ���������� ���������
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        audioSource.volume = savedVolume;
    }

    private void Start()
    {
        // ������������� ���������
        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        if (musicClips.Length > 0)
        {
            PlayMusic(currentTrackIndex);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        // ���������, ������� �� ������� ����� ������������
        if (volumeSlider == null)
        {
            // ��������� ����� ������� �� �����
            volumeSlider = FindObjectOfType<Slider>();
            if (volumeSlider != null)
            {
                volumeSlider.value = audioSource.volume;
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }
    }

    private void Update()
    {
        if (musicClips.Length == 0 || audioSource.clip == null) return;

        if (!audioSource.isPlaying)
        {
            Invoke("PlayNextTrack", 0.5f); // �������� ��� �������� � ���������� �����
        }
    }

    public void PlayMusic(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= musicClips.Length)
        {
            Debug.LogError("Invalid track index!");
            return;
        }

        currentTrackIndex = trackIndex;
        audioSource.clip = musicClips[trackIndex];
        audioSource.Play();
    }

    public void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicClips.Length;
        PlayMusic(currentTrackIndex);
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void TogglePause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else if (audioSource.clip != null)
        {
            audioSource.UnPause();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
