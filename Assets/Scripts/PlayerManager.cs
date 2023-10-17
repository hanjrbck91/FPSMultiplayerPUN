using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    GameObject controller;


    #region MonoBehaviour Callbacks

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Debug.Log("Instantiated Player Controller");
        //Instantiate our player controller

        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerController"),Vector3.zero, Quaternion.identity,0,new object[] {PV.ViewID});
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }

    #endregion
}
