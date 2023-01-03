using UnityEngine;

public class SelectWeaponHolder : MonoBehaviour
{

    public MovementAI weaponChoice;           //Holds c# script instance 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponChoice.waypointIndex == 2)
        {
            //Debug.Log("Able to switch weapon");
            //Weapon choices
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                transform.Find("WeaponHolder_FAMAS").gameObject.SetActive(true);
                transform.Find("WeaponHolder_Flashlight").gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                transform.Find("WeaponHolder_FAMAS").gameObject.SetActive(false);
                transform.Find("WeaponHolder_Flashlight").gameObject.SetActive(true);
            }

        }
    }
}
