using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeardedManStudios.Forge.Networking.Unity;

public class HitMarkerUI : MonoBehaviour
{
    private Image hitMarkerImage;

    public bool serverHit = false;
    public bool clientHit = false;

    float imageTimer = 1f;
    float imageTimer2 = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hitMarkerImage = transform.Find("Image").GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.Instance.IsServer)
        {
            if (!serverHit)
                hitMarkerImage.enabled = false;

            if (serverHit)
            {
                hitMarkerImage.enabled = true;

                imageTimer -= Time.deltaTime;

                if (imageTimer < 0f)
                {
                    serverHit = false;
                    imageTimer = 1f;
                }
            }
        }
        else
        {
            if (!clientHit)
                hitMarkerImage.enabled = false;

            if (clientHit)
            {
                hitMarkerImage.enabled = true;

                imageTimer2 -= Time.deltaTime;

                if (imageTimer2 < 0f)
                {
                    clientHit = false;
                    imageTimer2 = 1f;
                }
            }
        }

    }
}
