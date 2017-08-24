using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureManager : MonoBehaviour {

    public GameObject _BrushGo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 inputPos = Vector3.zero;
#if UNITY_EDITOR
        inputPos = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            DrawPic(inputPos);
        }
#else
        if(Input.touchCount > 0){
            var touch = Input.GetTouch(0);
            inputPos = touch.position;
            DrawPic(inputPos);
        }
#endif
    }

    void DrawPic(Vector3 intputPos_)
    {
        var ray = Camera.main.ScreenPointToRay(intputPos_);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {

        }
        else
        {
            var go = GameObject.Instantiate<GameObject>(_BrushGo);
            go.SetActive(true);
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(intputPos_.x, intputPos_.y, 7));
            go.transform.position = pos;
        }
    }
}
