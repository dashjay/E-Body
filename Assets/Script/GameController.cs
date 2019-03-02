using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController _instance;
    public Camera MainCamera;
    public float CameraSpeed;

    //版本信息
    private readonly string version = Const.Version;

    private GameObject _version;

    //男女模型
    public GameObject Male;
    public GameObject Female;


    private Dropdown CameraPositionSelect;

    private void Start()
    {
        //创建单例
        _instance = this;
        
        //刷新屏幕面板的版本信息
        _version = GameObject.Find("Version");
        _version.GetComponent<Text>().text = version;

        //对摄像头未知进行初始化
        CameraPositionInit();


        //初始化DropDown
        CameraPositionSelect = GameObject.Find(Const.CameraPositionSelect).GetComponent<Dropdown>();
        DropDownInit();
    }

    //当切换模型的按钮被按下时
    public void ChangeModelClick()
    {
        Male.SetActive(!Male.activeSelf);
        Female.SetActive(!Female.activeSelf);
    }

    #region CameraController

    public String[] Points;

    private Dictionary<string, GameObject> CameraPosition;
    private Dictionary<string, Transform> CameraPositionLookAt;

    //对所有相机位置进行初始化
    private void CameraPositionInit()
    {
        CameraPosition = new Dictionary<string, GameObject>
        {
            {Const.CameraOriginPosition, GameObject.Find(Const.CameraOriginPosition)}
        };

        foreach (var t in Points)
        {
            CameraPosition.Add(t, GameObject.Find(t));
        }

        CameraPositionLookAt = new Dictionary<string, Transform>();

        foreach (KeyValuePair<string, GameObject> keyValuePair in CameraPosition)
        {
            CameraPositionLookAt.Add(keyValuePair.Key + "LookAt",
                keyValuePair.Value.GetComponentInChildren<Transform>());
        }
    }

    private void DropDownInit()
    {
        foreach (string point in Points)
        {
            CameraPositionSelect.options.Add(new Dropdown.OptionData(point));
        }
    }

    public void ChangeCameraPosition()
    {
        MainCamera.transform.DOMove(CameraPosition[CameraPositionSelect.captionText.text].transform.position,
                CameraSpeed * Time.deltaTime)
            .SetEase(Ease.InOutSine);

//        MainCamera.transform
//            .DOLookAt(CameraPositionLookAt[CameraPositionSelect.captionText.text + "LookAt"].position,
//                CameraSpeed * Time.deltaTime).SetEase(Ease.InOutSine);
//        MainCamera.transform.LookAt(CameraPositionLookAt[CameraPositionSelect.captionText.text + "LookAt"]);
    }

    #endregion
}