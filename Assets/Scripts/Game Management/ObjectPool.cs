using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(PopulatePool());
    }

    // filling old scene pool on leave scene
    IEnumerator PopulatePool()
    {
        yield return new WaitForEndOfFrame();

        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            GameObject tmp;
            for (int i = 0; i < item.amountToPool; i++)
            {
                tmp = Instantiate(item.objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(PoolTagSO tag)
    {
        // Retrieve deactivated object from pool. 
        foreach (GameObject pooledObject in pooledObjects)
        {
            if (pooledObject != null && !pooledObject.activeInHierarchy && pooledObject.GetComponent<PoolTag>().PoolTagSO == tag)
            {
                return pooledObject;
            }
        }
        // If there are no available objects in pool, expand it. 
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.GetComponent<PoolTag>().PoolTagSO == tag)
            {
                GameObject obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        Debug.LogWarning($"No pooled item ({tag.name}) to return. Add item to \"Items To Pool\" list in Object Pool");
        return null;
    }
}