using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public bool isButtonActive;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        if (isButtonActive == true)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }
}
