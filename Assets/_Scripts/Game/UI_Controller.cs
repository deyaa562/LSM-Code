using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public UI_Data UI_Data;
    
    [SerializeField] private Image image;
    public int state;
    public void SetState(int state)
    {
        this.state = state;
        image.sprite = UI_Data.images[state];
    }
}
