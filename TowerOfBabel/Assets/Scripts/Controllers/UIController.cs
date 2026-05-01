using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private TextMeshProUGUI _textHeight;
    [SerializeField] private TextMeshProUGUI _textLevel;

    #endregion

    #region Unity Callbacks
    void Update()
    {
        _energySlider.value = _jetpack.Energy;
        _textHeight.text = ((int)_jetpack.transform.position.y).ToString();

    }
    #endregion

    #region Public Methods
    public void UpdateLevelText(string level)
    {
        _textLevel.text = level;
    }

    #endregion

    #region Private Methods
    #endregion
}