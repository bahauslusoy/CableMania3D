using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastFis : MonoBehaviour
{
    public GameObject mevcutSoket;
    [SerializeField] private string socketColor;

    [SerializeField] private GameManager gameManager;
    bool choosed;
    bool changePos;
    bool goSocket;

    GameObject movePos;
    GameObject soketSelf;



    void Start()
    {

    }


    void Update()
    {
        if (choosed)
        {
            transform.position = Vector3.Lerp(transform.position, movePos.transform.position, 0.04f);
            if (Vector3.Distance(transform.position, movePos.transform.position) < 0.01f)
            {
                choosed = false;
            }
        }
        if (changePos)
        {
            transform.position = Vector3.Lerp(transform.position, movePos.transform.position, 0.04f);
            if (Vector3.Distance(transform.position, movePos.transform.position) < 0.01f)
            {
                changePos = false;
                goSocket = true;
            }
        }
        if (goSocket)
        {
            transform.position = Vector3.Lerp(transform.position, soketSelf.transform.position, 0.04f);
            if (Vector3.Distance(transform.position, soketSelf.transform.position) < 0.01f)
            {
                
                goSocket = false;
                gameManager.isMove = false;
                mevcutSoket = soketSelf;
            }
        }
    }

    public void ChoosePos(GameObject GoToObj, GameObject Soket)
    {

        movePos = GoToObj;
        choosed = true;

    }

    public void ChangePos(GameObject GoToObj, GameObject Soket)
    {
        soketSelf = Soket;


        movePos = GoToObj;
        changePos = true;

    }
     public void ComeBackToSocket(GameObject Soket)
    {
        soketSelf = Soket;


        goSocket = true;

    }
}
