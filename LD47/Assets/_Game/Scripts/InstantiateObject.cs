using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject prefab = null;

    public bool instantiateOnStart = false;

    public Vector3 offset = Vector3.zero;

    public float destroyTimer = -1;

    private void Start()
    {
        if (instantiateOnStart)
            Instantiate();
    }

    public void Instantiate()
    {
        GameObject instance = Instantiate(prefab, transform.position, prefab.transform.rotation);
        if (destroyTimer > 0.0f)
            Destroy(instance, destroyTimer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, 0.15f);
    }
}
