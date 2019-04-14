using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private AudioSource source;
    public AudioClip soundEffect;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        source = player.GetComponent<AudioSource>();
        soundEffect = (AudioClip)Resources.Load("SoundFX/spike");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Bruh");
            col.gameObject.SendMessage("HitObstacle", 1); //Call Method For Spike Slow Down
            source.PlayOneShot(soundEffect);
        }
    }
}
