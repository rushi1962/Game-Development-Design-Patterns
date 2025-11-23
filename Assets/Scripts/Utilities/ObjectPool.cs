using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    public static Dictionary<Type, List<T>> PoolDictionary = new Dictionary<Type, List<T>>();
    public static int DefaultPoolSize = 100;

    public static void CreatePool(T PrefabInstance)
    {
        if(PoolDictionary.ContainsKey(typeof(T)))
        {
            return;
        }

        List<T> NewPool = new List<T>();

        for(int i = 0; i < DefaultPoolSize; i++)
        {
            T NewGO = UnityEngine.Object.Instantiate(PrefabInstance);
            NewGO.gameObject.SetActive(false);
            NewPool.Add(NewGO);
        }

        PoolDictionary.Add(typeof(T), NewPool);
    }

    public static void AddElement(T PrefabInstance)
    {
        if (!PoolDictionary.ContainsKey(typeof(T)))
        {
            CreatePool(PrefabInstance);
        }

        List<T> NewPool = PoolDictionary[typeof(T)];
        T NewGO = UnityEngine.Object.Instantiate(PrefabInstance);
        NewGO.gameObject.SetActive(false);
        NewPool.Add(NewGO);
    }

    public static T GetFromPool(T PrefabInstance)
    {
        if (!PoolDictionary.ContainsKey(typeof(T)))
        {
            CreatePool(PrefabInstance);
        }

        if(PoolDictionary[typeof(T)].Count == 0)
        {
            AddElement(PrefabInstance);
        }

        T Element = PoolDictionary[typeof(T)][0];
        PoolDictionary[typeof(T)].RemoveAt(0);
        Element.gameObject.SetActive(true);

        return Element;
    }

    public static void ReturnToPool(T ElementToReturn)
    {
        if (!PoolDictionary.ContainsKey(typeof(T)))
        {
            Debug.LogError("No pool of such elements exists");
            return;
        }

        ElementToReturn.transform.SetParent(null);
        ElementToReturn.gameObject.SetActive(false);
        PoolDictionary[typeof(T)].Add(ElementToReturn);
    }
}
