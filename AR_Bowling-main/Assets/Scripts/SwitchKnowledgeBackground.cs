using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchKnowledgeBackground : MonoBehaviour
{
    public int currentSprite = 0;
    public Sprite[] backgrounds;

    public void onNextButton()
    {
        currentSprite++;
        if( currentSprite > 2)
        {
            currentSprite = 2;
        }
        onClickChangeBackground();
    }

    public void onPreviousButton()
    {
        currentSprite--;
        if( currentSprite < 0 )
        {
            currentSprite = 0;
        }
        onClickChangeBackground();
    }

    public void onClickChangeBackground()
    {
        GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[currentSprite];
    }

}
