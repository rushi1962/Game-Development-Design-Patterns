using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton
{
    public Rigidbody BoxPrefab;
    public float Force;

    private void Start()
    {
        ObjectPool<Rigidbody>.CreatePool(BoxPrefab);
    }

    private void Update()
    {
        Rigidbody RB = ObjectPool<Rigidbody>.GetFromPool(BoxPrefab);
        RB.gameObject.transform.position = Vector3.zero;
        RB.gameObject.transform.rotation = Quaternion.identity;
        RB.transform.SetParent(transform);
        RB.AddForce(Vector3.up * Force);
    }

    void XYZ(object[] param)
    {

    }
}
