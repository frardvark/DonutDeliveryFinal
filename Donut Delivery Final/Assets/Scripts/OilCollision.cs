using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCollision : MonoBehaviour
{
    private AudioSource source;
    public AudioClip soundEffect;

    private void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        source = camera.GetComponent<AudioSource>();
        soundEffect = (AudioClip)Resources.Load("SoundFX/skid");
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("HitObstacle", 2); //Call Method For Oil Slick Slow Down
            source.PlayOneShot(soundEffect);
        }
    }
}
