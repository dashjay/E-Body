using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Camera main;

    public Vector3 originPosition;

    public GameObject CastCamTarget;

    public Button StartButton;

    public Button CastButton;

    public Button BackButton;

    public Text Cast;

    public float speed;

    public float castSpeed;


    private void Start()
    {
        //获取初始位置 
        originPosition = main.transform.position;


        Cast.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
    }

    public void CastClick()
    {
        main.transform.DOMove(CastCamTarget.transform.position, speed * Time.deltaTime).SetEase(Ease.InOutSine);

        StartButton.gameObject.SetActive(false);
        CastButton.gameObject.SetActive(false);
        Cast.gameObject.SetActive(true);

        Cast.transform.DOLocalMoveY(986, castSpeed * Time.deltaTime).SetEase(Ease.Linear);

        BackButton.gameObject.SetActive(true);
    }

    public void BackInit()
    {
        main.transform.DOMove(originPosition, speed * Time.deltaTime).SetEase(Ease.InOutSine);

        StartButton.gameObject.SetActive(true);
        CastButton.gameObject.SetActive(true);
        Cast.gameObject.SetActive(false);

        BackButton.gameObject.SetActive(false);
    }
}