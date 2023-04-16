using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public Camera sCam;
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Vector3 randomPickupSpawn = new Vector3(Random.Range(0, sCam.pixelHeight - 1), Random.Range(sCam.pixelWidth - 1, 1), 0.1f);
        ray = sCam.ScreenPointToRay(randomPickupSpawn);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                Debug.Log("Instantiating");
                Instantiate(pickupPrefab, new Vector3(hit.point.x, 0.8f, hit.point.z), Quaternion.identity);
            }
        }
        else
        {
            Spawn();
        }
    }
}
