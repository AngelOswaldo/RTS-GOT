using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPause : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject menu;
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame() {

        menu.SetActive(true);
        Time.timeScale = 0;

    }

    public void PlayGame()
    {

        menu.SetActive(false);
        Time.timeScale = 1;

    }
}
