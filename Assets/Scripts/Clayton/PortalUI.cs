using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUI : MonoBehaviour
{
    [SerializeField] private Image portal1UI;
    [SerializeField] private Image portal2UI;
    [SerializeField] private Text ammoText;

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
        //GameObject p1 = GameObject.FindGameObjectWithTag("Portal1");
        //GameObject p2 = GameObject.FindGameObjectWithTag("Portal2");

        //if (p1)
        //    portal1UI.gameObject.SetActive(true);
        //else
        //    portal1UI.gameObject.SetActive(false);

        //if (p2)
        //    portal2UI.gameObject.SetActive(true);
        //else
        //    portal2UI.gameObject.SetActive(false);

        ammoText.text = "" + ammo;

        if (canDisplay1)
        {
            portal1UI.gameObject.SetActive(true);
            portal1UI.gameObject.transform.Rotate(0, 0, 1 * 0.5f);
        }
        else
            portal1UI.gameObject.SetActive(false);

        if (canDisplay2)
        {
            portal2UI.gameObject.SetActive(true);
            portal2UI.gameObject.transform.Rotate(0, 0, 1 * 0.5f);
        }
        else
            portal2UI.gameObject.SetActive(false);
    }
}
