using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHydrant : MonoBehaviour
{
    GameObject Canvas;
    public Texture splashImage;
    private AudioSource source;
    public AudioClip soundEffect;

    private void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        source = player.GetComponent<AudioSource>();
        soundEffect = (AudioClip)Resources.Load("SoundFX/WaterSplash_Medium");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.SendMessage("FireHydrantCollision");
            source.PlayOneShot(soundEffect);
        }
    }

    public IEnumerator FireHydrantCollision()
    {
            RawImage splash = Canvas.AddComponent<RawImage>();
            splash.texture = splashImage;
            yield return new WaitForSeconds(2);
            Destroy(Canvas.GetComponent<RawImage>());
    }
}
