using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Fields
    [Header("Configuration")]
    [SerializeField] Button _playButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Button _exitGameButton;

    [Header("Panels")]
    [SerializeField] GameObject _settingsPanel;


    #endregion

    #region Unity Callbacks
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Initialize();

        _playButton.onClick.AddListener(StartGame);
        _settingsButton.onClick.AddListener(OpenSettings);
        _exitGameButton.onClick.AddListener(ExitGame);

        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    #endregion

    #region Private Methods
    private void Initialize()
    {
        _volumeSlider.value = AudioListener.volume;
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }
    private void OpenSettings()
    {
        _settingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    #endregion

}