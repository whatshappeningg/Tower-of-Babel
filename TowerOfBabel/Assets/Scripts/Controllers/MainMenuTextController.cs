using UnityEngine;
using TMPro;

public class MainMenuTextController : MonoBehaviour
{
    #region Fields
    private string[] StartGameText = new string[] { "Start game", "Spiel starten", "Ludum incipe", "Avvia il gioco" };
    private string[] ExitGameText = new string[] { "Exit game", "Spiel beenden", "Ludum exi", "Esci dal gioco" };
    [SerializeField] private TextMeshProUGUI _startGameText;
    [SerializeField] private TextMeshProUGUI _exitGameText;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        int languageIndex = Random.Range(0, StartGameText.Length);

        _startGameText.text = StartGameText[languageIndex];
        _exitGameText.text = ExitGameText[languageIndex];
    }

    #endregion
}
