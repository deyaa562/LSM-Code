using UnityEngine;

[CreateAssetMenu(menuName = "UI Images/ ImagesSO")]
public class UI_Data : ScriptableObject
{
    // State 1: Ready to plant seed
    // State 2: Plant is growing
    // State 3: Ready to collect
    public Sprite[] images = new Sprite[3];

}
