using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded;

    public int agentCount;

    private int _count;

    public GameObject completeLevelUI;
    
    public GameObject failLevelUI;

    public GameObject levelNo;

    private void Start()
    {
        _count = 0;
        levelNo.GetComponent<Text>().text = SceneManager.GetActiveScene().name.ToUpper();
    }

    public void CompleteLevel()
    {
        _count++;
        if (_gameHasEnded == false && _count == agentCount)
        {
            _gameHasEnded = true;
            completeLevelUI.SetActive(true);
        }
    }
    public void FailLevel()
    {
        if (_gameHasEnded == false)
        {
            _gameHasEnded = true;
            failLevelUI.SetActive(true);
        }
    }
}
