using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<PoolObject> objects;
    
    private void AddObject(PoolObject sample)
    {
        var temp = GameObject.Instantiate(sample.gameObject, this.transform, true);
        temp.name = sample.name;
        objects.Add(temp.GetComponent<PoolObject>());
        temp.SetActive(false);
    }

    public void Init(PoolObject po, int count)
    {
        objects = new List<PoolObject>();
        for (var i = 0; i < count; ++i)
            AddObject(po);
    }
    
    public PoolObject GetObject () {
        for (int i = 0; i < objects.Count; ++i) {
            if (objects[i].gameObject.activeInHierarchy==false) {
                return objects[i];
            }
        }
        AddObject(objects[0]);
        return objects[objects.Count-1];
    }
}