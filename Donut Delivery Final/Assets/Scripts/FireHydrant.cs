using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHydrant : MonoBehaviour
{
    GameObject Canvas;
    public Texture splashImage;

    private void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.SendMessage("FireHydrantCollision");
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
