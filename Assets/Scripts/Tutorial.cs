using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public bool isRight=false;

    public GameObject spawner;
    public GameObject textTutorial;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public Button btnLeft;
    public Button btnRight;
    public GameObject timer;
    AudioManager audioManager;
    private bool _isPopupFirst;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {

        arrowLeft.SetActive(true);
        arrowRight.SetActive(false);
        spawner.SetActive(false);
        timer.SetActive(false) ;
        audioManager.PlaySFX(audioManager.tutorial);
    }

    void Update()
    {



        if (!_isPopupFirst)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (btnLeft != null && EventSystem.current.currentSelectedGameObject == btnLeft.gameObject))
            {
                arrowLeft.SetActive(false);
                arrowRight.SetActive(true);
                _isPopupFirst = true;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || (btnRight != null && EventSystem.current.currentSelectedGameObject == btnRight.gameObject))
            {
                timer.SetActive(true);
                arrowRight.SetActive(false);
                arrowLeft.SetActive(false);
                textTutorial.SetActive(false);
                spawner.SetActive(true);
                isRight = true;
            }

        }

    }
}
