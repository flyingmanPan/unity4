using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Done
//Pass
public class DiskFactory : MonoBehaviour {

    public GameObject DiskPrefab;
    public List<DiskProperties> NewDisk = new List<DiskProperties>();
    public List<DiskProperties> UsedDisk = new List<DiskProperties>();

    public void Awake()
    {
        Debug.Log("Factory start");
        DiskPrefab = GameObject.Instantiate(Resources.Load("Prefabs/disk", typeof(GameObject)),
            Vector3.zero, Quaternion.identity,null) as GameObject;
        DiskPrefab.SetActive(false);
    }
    public GameObject GetDisk(int round)
    {
        GameObject DiskObj = null;
        if(NewDisk.Count>0)
        {
            DiskObj = NewDisk[0].gameObject;
            NewDisk.Remove(NewDisk[0]);
        }
        else
        {
            DiskObj = GameObject.Instantiate<GameObject>(DiskPrefab, Vector3.zero, Quaternion.identity);
            DiskObj.AddComponent<DiskProperties>();
        }
        //Add properties
        DiskObj.GetComponent<DiskProperties>().color = Color.yellow;
        DiskObj.GetComponent<DiskProperties>().speed = 4.0f;
        DiskObj.GetComponent<DiskProperties>().direction = new Vector3(1, 1, 0);
        DiskObj.GetComponent<Renderer>().material.color = Color.yellow;
        //--
        UsedDisk.Add(DiskObj.GetComponent<DiskProperties>());
        DiskObj.name = DiskObj.GetInstanceID().ToString();
        return DiskObj;
    }
    public void FreeDisk(GameObject DiskObj)
    {
        DiskProperties tmp = null;
        foreach (DiskProperties item in UsedDisk)
        {
            if (DiskObj.GetInstanceID() == item.gameObject.GetInstanceID())
                tmp = item;
        }
        if(tmp!=null)
        {
            tmp.gameObject.SetActive(false);
            NewDisk.Add(tmp);
            UsedDisk.Remove(tmp);
        }
    }
}
