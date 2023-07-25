using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public bool isPause=true;
 
 
    public GameObject textTutorial;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public Button btnLeft;
    public Button btnRight;
    private void Start()
    {
        textTutorial = GetComponent<GameObject>();
    }

    void Update()
    {
        if (isPause)
        {
            Time.timeScale = 0f;

        
           // textTutorial.SetActive(true);
         
            arrowLeft.SetActive(true);


            if (Input.GetKeyDown(KeyCode.LeftArrow) || btnLeft != null && EventSystem.current.currentSelectedGameObject == btnLeft.gameObject)
            {
                FindObjectOfType<Player>().LeftArrow();
                arrowLeft.SetActive(false);
                arrowRight.SetActive(true);



            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || btnLeft != null && EventSystem.current.currentSelectedGameObject == btnLeft.gameObject)
            {
                arrowRight.SetActive(false);

            }
         }
    }
}
