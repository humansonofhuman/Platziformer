using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectablePoints = 0;
    Text collectablePointsText;
    ParticleSystem collectableParticle;
    AudioSource collectableAudio;
    // Start is called before the first frame update
    void Start()
    {
        collectablePoints = 0;
        collectablePointsText = GameObject
            .Find("CollectableCounter")
            .GetComponent<Text>();

        collectableParticle = GameObject
            .Find("CollectableParticle")
            .GetComponent<ParticleSystem>();

        collectableAudio = GameObject
            .Find("Collectables")
            .GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            collectableAudio.Play();
            collectableParticle.transform.position = transform.position;
            collectableParticle.Play();
            collectablePoints++;
            collectablePointsText.text = collectablePoints.ToString();
            gameObject.SetActive(false);
        }
    }
}
