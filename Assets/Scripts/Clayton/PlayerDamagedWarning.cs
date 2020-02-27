using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamagedWarning : MonoBehaviour
{
    private Image damagedWarning;
    private float targetAlpha;
    private float fadeRate;
    private float timer;
    bool needStopDamage;
    public bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        damagedWarning = transform.Find("damagedWarning").GetComponent<Image>();
        targetAlpha = timer = 0;
        fadeRate = 0.1f;
        damaged = needStopDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            StartCoroutine(FadeIn());
            needStopDamage = true;
        }

        if (needStopDamage)
        {
            if (timer > 1f)
            {
                StartCoroutine(FadeOut());
                damaged = false;
                needStopDamage = false;
            }
            else
                timer += Time.deltaTime;
        }
        else
            timer = 0;
    }

    IEnumerator FadeIn()
    {
        targetAlpha = 0.25f;
        Color curColor = damagedWarning.color;

        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate);
            damagedWarning.color = curColor;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        targetAlpha = 0f;
        Color curColor = damagedWarning.color;

        while (Mathf.Abs(targetAlpha - curColor.a) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate);
            damagedWarning.color = curColor;
            yield return null;
        }
    }
}