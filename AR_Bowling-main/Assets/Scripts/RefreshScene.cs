using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshScene : MonoBehaviour
{

    public void onRefreshButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void onCustomizeButtonClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void onHomeuttonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
