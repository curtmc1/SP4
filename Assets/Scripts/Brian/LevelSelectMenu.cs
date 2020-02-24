using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public bool selectLevel1 = true;
    public bool selectLevel2 = false;
    public bool selectLevel3 = false;

    public Button level1BtnRef;
    public Button level2BtnRef;
    public Button level3BtnRef;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("LevelName", "Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLevel1()
    {
        if (!selectLevel1)
            selectLevel1 = true;

        if (selectLevel1)
        {
            PlayerPrefs.SetString("LevelName", "Level1");
            selectLevel2 = false;
            selectLevel3 = false;
        }
    }

    public void SelectLevel2()
    {
        if (!selectLevel2)
            selectLevel2 = true;

        if (selectLevel2)
        {
            PlayerPrefs.SetString("LevelName", "Level2");
            selectLevel1 = false;
            selectLevel3 = false;
        }
    }

    public void SelectLevel3()
    {
        if (!selectLevel3)
            selectLevel3 = true;

        if (selectLevel3)
        {
            PlayerPrefs.SetString("LevelName", "Level3");
            selectLevel1 = false;
            selectLevel2 = false;
        }
    }
}
