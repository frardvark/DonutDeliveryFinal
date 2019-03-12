using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private AudioSource source;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        source = camera.GetComponent<AudioSource>();
        soundEffect = (AudioClip)Resources.Load("SoundFX/carHorn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PedestrianCar")
        {
            source.PlayOneShot(soundEffect);
        }
    }
}
