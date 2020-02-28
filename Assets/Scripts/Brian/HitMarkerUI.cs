using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMarkerUI : MonoBehaviour
{
    private Image hitMarkerImage;

    public bool hit = false;

    float imageTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hitMarkerImage = transform.Find("Image").GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
            hitMarkerImage.enabled = false;
        if (hit)
        {
            hitMarkerImage.enabled = true;

            imageTimer -= Time.deltaTime;

            if (imageTimer < 0f)
            {
                hit = false;
                imageTimer = 1f;
            }
        }
    }
}
