using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clothing : MonoBehaviour
{
    public Player player;
    public SpriteRenderer[] renderers = new SpriteRenderer[3];
    private int currentIndex;
  
    public void ChangeColor(Image image)
    {
        
        renderers[currentIndex].color = image.color;
        
    }

    public void ChangeIndex(int index)
    {
        currentIndex = index;
    }
}
