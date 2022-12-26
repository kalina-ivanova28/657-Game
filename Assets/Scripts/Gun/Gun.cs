using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        
    }

    void Shoot() {

        muzzleFlash.Play();        //plays muzzle flash every time the player left clicks

        RaycastHit hit;

        //If the raycast hits something i.e. gameobject, environment etc...
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            //Only perform this if we have found a component on impact
            if (target != null) {
                target.takeDamage(damage);
            }
        }

    }
}
