using UnityEngine;

public class InGameController : MonoBehaviour
{
    #region Fields
    private string[] Levels = new string[5] { "Floor 0 - Priest", "Floor 1 - Bishop", "Floor 2 - Archbishop", "Floor 3 - Cardinal", "Floor 4 - Pope" };
    private int _currentLevel = 0;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        _currentLevel = 0;
    }

    #endregion

    #region Public Methods
    public string ChangeLevel()
    {
        _currentLevel++;
        return Levels[_currentLevel];
    }
    #endregion
}
