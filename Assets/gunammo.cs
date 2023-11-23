using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunammo : MonoBehaviour
{
    public float ammoLevel;
    public AudioClip ammopickup;
    public AudioClip gunshot;
    public AudioClip gunreload;
    public AudioClip noammo;
    public GameObject ammobox;

    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoLevel == 0)
        {
            ammobox.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1") && ammoLevel > 0)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit result;
            Physics.Raycast(ray, out result);

            ammoLevel = ammoLevel - 1;





            if (Input.GetButtonDown("Fire1") && ammoLevel == 0)
            {
                au.clip = noammo;
                au.Play();
            }




            if (result.collider.transform.name == "target")
            {
                GameObject g = result.collider.gameObject;
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
            }
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Ammobox"))
        {
            other.gameObject.SetActive(false);
            ammoLevel += 20;

        }

    }
}