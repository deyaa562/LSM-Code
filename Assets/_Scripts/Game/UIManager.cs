using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject UI_Game;
    private static UIManager _Instance; 
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        else if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
    }


    public void OpenSection(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void CloseSection(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void CloseStore()
    {
        UI_Game.SetActive(true);

        GameObject deactivateGO = GameObject.FindGameObjectWithTag("UI");
        if (deactivateGO != null)
            deactivateGO.SetActive(false);

    }
}
