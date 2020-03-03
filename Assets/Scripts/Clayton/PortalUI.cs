using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUI : MonoBehaviour
{
    public Image portal1UI; //[SerializeField] private Image portal1UI;
    public Image portal2UI;
    public Text ammoText;

    public bool canDisplay1;
    public bool canDisplay2;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        canDisplay1 = canDisplay2 = false;
        ammoText.text = "30";
        ammo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "" + ammo; //Ammo UI

        if (canDisplay1) //Display portal 1
        {
            portal1UI.gameObject.SetActive(true);
            portal1UI.gameObject.transform.Rotate(0, 0, 1 * 0.5f);
        }
        else
            portal1UI.gameObject.SetActive(false);

        if (canDisplay2) //Display portal 2
        {
            portal2UI.gameObject.SetActive(true);
            portal2UI.gameObject.transform.Rotate(0, 0, 1 * 0.5f);
        }
        else
            portal2UI.gameObject.SetActive(false);
    }
}
