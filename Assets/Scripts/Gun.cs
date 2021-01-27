using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawnPoint;

    public PlayerMain playerMain;

    public void Shoot()
    {
 
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(myray, out hit, Mathf.Infinity))
        {

            GameObject newBullet = Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(myray.direction * playerMain.speedFire, ForceMode.Impulse);
            
        
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if(rb != null)
            {
                Debug.Log("impulse2");
                rb.AddForceAtPosition(-hit.normal * 8f, hit.transform.InverseTransformPoint(hit.point), ForceMode.Impulse);
            }

            
                Destroy(newBullet.gameObject, 3f);
            
        }
    }      
}
            
    
