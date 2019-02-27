using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string version = "Version: 0.0.2";
    private GameObject _version;

    public GameObject Male;
    public GameObject Female;

    private void Start()
    {
        _version = GameObject.Find("Version");
        _version.GetComponent<Text>().text = version;
    }

    public void ChangeModelClick()
    {
        Male.SetActive(!Male.activeSelf);
        Female.SetActive(!Female.activeSelf);
    }
}