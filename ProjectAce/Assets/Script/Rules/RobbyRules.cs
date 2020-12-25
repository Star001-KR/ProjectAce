using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobbyRules : MonoBehaviour
{
    public GameObject obj_defaultUI;
    public GameObject obj_deckSetting;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        obj_defaultUI.SetActive(true);
        obj_deckSetting.SetActive(false);
    }

    public void OnGameStartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnDeckSettingButtonClick()
    {
        obj_defaultUI.SetActive(false);
        obj_deckSetting.SetActive(true);
    }

    public void OnDeckSetting_BackButtonClick()
    {
        obj_defaultUI.SetActive(true);
        obj_deckSetting.SetActive(false);
    }
}
