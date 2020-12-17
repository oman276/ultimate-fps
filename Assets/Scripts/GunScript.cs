using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float range = 100f;

    public bool gameActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (gameActive == true)
        {
            muzzleFlash.Play();
            FindObjectOfType<AudioManager>().Play("gun");
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
            {
                print(hit.transform.name);

            }


            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
