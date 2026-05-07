using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISettings : MonoBehaviour
{
    #region Fields
    [SerializeField] private Button _closeButton;


    [SerializeField] private TMP_Dropdown _qualityDropdown;
    [SerializeField] private Toggle _vsyncToggle;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private Toggle _noShadowToggle;
    [SerializeField] private Toggle _softShadowToggle;
    [SerializeField] private Toggle _hardShadowToggle;
    [SerializeField] private Slider _particleResolutionSlider;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        _closeButton.onClick.AddListener(CloseSettings);

    }

    #endregion

    #region Private Methods
    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }

    #endregion

}
