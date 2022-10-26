using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject selectedObj;
    GameObject selectedSoket;
    public bool isMove;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider != null)
                {
                    if (selectedObj == null && !isMove)
                    {
                        if (hit.collider.CompareTag("Blue_Fis") || hit.collider.CompareTag("RedFis") || hit.collider.CompareTag("YellowFis"))
                        {

                            LastFis lastFis = hit.collider.GetComponent<LastFis>();
                            lastFis.ChoosePos(lastFis.mevcutSoket.GetComponent<Soket>().movePos, hit.collider.GetComponent<LastFis>().
                            mevcutSoket);
                            selectedObj = hit.collider.gameObject;
                            selectedSoket = lastFis.mevcutSoket;
                            isMove = true;


                            // Debug.Log(hit.collider.gameObject.name);
                        }
                    }
                    if (hit.collider.CompareTag("Soket"))
                    {
                        if (selectedObj != null && !hit.collider.GetComponent<Soket>().isFully && selectedObj != hit.collider.gameObject)
                        {
                            selectedSoket.GetComponent<Soket>().isFully = false;
                            Soket soket = hit.collider.GetComponent<Soket>();
                            selectedObj.GetComponent<LastFis>().ChangePos(soket.movePos, hit.collider.gameObject);
                            soket.isFully = true;

                            selectedObj = null;
                            selectedSoket = null;
                            isMove = true;

                        }
                        else if (selectedSoket == hit.collider.gameObject)
                        {
                            selectedObj.GetComponent<LastFis>().ComeBackToSocket(hit.collider.gameObject);
                            selectedObj = null;
                            selectedSoket = null;
                            isMove = true;
                        }
                    }
                }
            }
        }
    }
}
