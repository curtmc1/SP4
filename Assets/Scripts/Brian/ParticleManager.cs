using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    ParticleSystem particles;

    // Start is called before the first frame update
    [System.Obsolete]
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().duration);
        Destroy(gameObject);
    }
    
    void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("Graphics"));
        particles = (ParticleSystem)FindObjectOfType(typeof(ParticleSystem));
        SetQuality();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Bring over graphic settings for particles
    public void SetQuality()
    {
        if (particles)
        {
            int index = PlayerPrefs.GetInt("Graphics");
            switch (index)
            {
                case 0:
                    particles.gameObject.SetActive(false);
                    break;
                case 1:
                    particles.gameObject.SetActive(false);
                    break;
                case 2:
                    particles.gameObject.SetActive(false);
                    var pce = particles.emission;
                    pce.rateOverTime = 5;
                    particles.gameObject.SetActive(true);
                    break;
                case 3:
                    particles.gameObject.SetActive(false);
                    pce = particles.emission;
                    pce.rateOverTime = 10;
                    particles.gameObject.SetActive(true);
                    break;
                case 4:
                    particles.gameObject.SetActive(false);
                    pce = particles.emission;
                    pce.rateOverTime = 20;
                    particles.gameObject.SetActive(true);
                    break;
                case 5:
                    particles.gameObject.SetActive(false);
                    pce = particles.emission;
                    pce.rateOverTime = 30;
                    particles.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
