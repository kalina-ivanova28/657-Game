using UnityEngine;
using System.Collections;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;
    public float fireRate;
    private float nextTimeToFire = 0f;

    public TextMeshProUGUI ammoText;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    //Ammo + reloading
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    void Start() 
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable ()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0) 
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            muzzleFlash.Emit(10);    
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        ammoText.text = "Ammo: " + currentAmmo.ToString() + "/ ∞";
        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        ammoText.text = "Reloading..";

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot() {

        //muzzleFlash.Play();        //plays muzzle flash every time the player left clicks

        currentAmmo--;

        RaycastHit hit;

        //If the raycast hits something i.e. gameobject, environment etc...
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);
            //muzzleFlash.Play(); 
            Target target = hit.transform.GetComponent<Target>();
            //Only perform this if we have found a component on impact
            if (target != null) {
                target.takeDamage(damage);
            }
        }

    }
}
