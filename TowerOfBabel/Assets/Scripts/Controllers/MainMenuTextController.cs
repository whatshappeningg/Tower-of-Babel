using UnityEngine;
using TMPro;

public class MainMenuTextController : MonoBehaviour
{
    #region Fields
    private string[] MenuText = new string[] { "Menu", "Menú", "Menu", "Menü" };
    private string[] PlayText = new string[] { "Play", "Jugar", "Gioca", "Spielen" };
    private string[] SettingsText = new string[] { "Settings", "Configuración", "Impostazioni", "Einstellungen" };
    [SerializeField] private TextMeshProUGUI _menuText;
    [SerializeField] private TextMeshProUGUI _playText;
    [SerializeField] private TextMeshProUGUI _settingsText;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        int languageIndex = Random.Range(0, PlayText.Length);

        _menuText.text = MenuText[languageIndex];
        _playText.text = PlayText[languageIndex];
        _settingsText.text = SettingsText[languageIndex];
    }

    #endregion
}
