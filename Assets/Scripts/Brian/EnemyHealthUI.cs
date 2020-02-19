using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    private Image hpImage;

    EnemyHealth enemyhp;

    // Start is called before the first frame update
    void Start()
    {
        hpImage = transform.Find("hpbar").GetComponentInChildren<Image>();
        enemyhp = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = enemyhp.health / 10f;
        hpImage.fillAmount = temp;
    }
}
