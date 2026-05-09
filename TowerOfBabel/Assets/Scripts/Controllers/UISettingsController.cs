using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISettingsController : MonoBehaviour
{
    #region Fields
    [Header("Configuration")]
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Dropdown _qualityDropdown;
    [SerializeField] private Toggle _vsyncToggle;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private Toggle _noShadowToggle;
    [SerializeField] private Toggle _softShadowToggle;
    [SerializeField] private Toggle _hardShadowToggle;
    [SerializeField] private Slider _particleResolutionSlider;

    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        Initialize();

        _qualityDropdown.onValueChanged.AddListener(SetQuality);
        _vsyncToggle.onValueChanged.AddListener(SetVSync);
        _fullScreenToggle.onValueChanged.AddListener(SetFullScreen);

        _noShadowToggle.onValueChanged.AddListener(isOn => SetShadowQuality(0));
        _hardShadowToggle.onValueChanged.AddListener(isOn => SetShadowQuality(1));
        _softShadowToggle.onValueChanged.AddListener(isOn => SetShadowQuality(2));

        _particleResolutionSlider.onValueChanged.AddListener(SetParticleResolution);

        _closeButton.onClick.AddListener(CloseSettings);

    }

    #endregion

    #region Private Methods
    private void Initialize()
    {
        // Quality dropdown
        _qualityDropdown.ClearOptions();

        var qualityNames = QualitySettings.names;
        _qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(qualityNames));

        _qualityDropdown.value = QualitySettings.GetQualityLevel();
        _qualityDropdown.RefreshShownValue();

        // Set VSync toggle
        _vsyncToggle.isOn = QualitySettings.vSyncCount > 0;

        // Set Fullscreen toggle
        _fullScreenToggle.isOn = Screen.fullScreen;

        // Set Shadow toggles
        switch (QualitySettings.shadows)
        {
            case ShadowQuality.Disable:
                _noShadowToggle.isOn = true;
                break;
            case ShadowQuality.HardOnly:
                _hardShadowToggle.isOn = true;
                break;
            case ShadowQuality.All:
                _softShadowToggle.isOn = true;
                break;
        }

        // Set Particle Resolution slider
        _particleResolutionSlider.value = QualitySettings.particleRaycastBudget;
    }
    private void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
    private void SetVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }
    private void SetFullScreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }
    private void SetShadowQuality(int quality)
    {
        switch (quality)
        {
            case 0:
                QualitySettings.shadows = ShadowQuality.Disable;
                break;
            case 1:
                QualitySettings.shadows = ShadowQuality.HardOnly;
                break;
            case 2:
                QualitySettings.shadows = ShadowQuality.All;
                break;
        }
    }
    private void SetParticleResolution(float value)
    {
        QualitySettings.particleRaycastBudget = (int)value;
    }
    private void CloseSettings()
    {
        _mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    #endregion

}
