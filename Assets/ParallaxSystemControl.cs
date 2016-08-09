using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxSystemControl : MonoBehaviour {

	// Use this for initialization
    [System.Serializable]
    public class ParallaxSetting
    {
        public Renderer ObjBack;
        public Vector2 Speed;
        public bool AutoRun;
    }
    float[] ArrZmichennyaX;
    float[] ArrZmichennyaY;
    private float MaxPositionObject = 0f;
    private float MinPositionObject = 0f;
    private Vector3 RunCar = new Vector3();
    private Vector3 LastPositionCar = new Vector3();
    public List<ParallaxSetting> ListParallaxObject = new List<ParallaxSetting>();
    public GameObject Car;
    public float StartWidht;
    void Start () {
        if (ListParallaxObject.Count == 0)
        {
            Debug.Log("Not parallax object");
            return;
        }
        if(Car == null)
        {
            Debug.Log("Not car, pleas select car");
            return;
        }
        MinPositionObject = ListParallaxObject[0].ObjBack.bounds.min.x;
        MaxPositionObject = ListParallaxObject[0].ObjBack.bounds.max.x;
	    for(int i = 1; i < ListParallaxObject.Count; i++)
        {
            if (MinPositionObject > ListParallaxObject[i].ObjBack.bounds.min.x)
                MinPositionObject = ListParallaxObject[i].ObjBack.bounds.min.x;
            if (MaxPositionObject < ListParallaxObject[i].ObjBack.bounds.max.x)
                MaxPositionObject = ListParallaxObject[i].ObjBack.bounds.max.x;
        }
        LastPositionCar = Car.transform.position;
    }
	// Update is called once per frame
	void Update () {
        if (StartWidht != Screen.width)
        {
            StartWidht = Screen.width;
            return;
        }
        RunCar = Car.transform.position - LastPositionCar;
        LastPositionCar = Car.transform.position;
        for (int i = 0; i < ListParallaxObject.Count; i++)
        {
            if (RunCar.x >= 0)
            {

                if (ListParallaxObject[i].AutoRun == true)
                    ListParallaxObject[i].ObjBack.transform.localPosition += new Vector3(-((ListParallaxObject[i].Speed.x * Time.deltaTime) + (RunCar.x * Time.deltaTime)), -(ListParallaxObject[i].Speed.y * RunCar.y * Time.deltaTime), 0f);
                else
                    ListParallaxObject[i].ObjBack.transform.localPosition += new Vector3(-((ListParallaxObject[i].Speed.x * Time.deltaTime) * (RunCar.x)), -(ListParallaxObject[i].Speed.y * RunCar.y * Time.deltaTime) ,0f);
                if (ListParallaxObject[i].ObjBack.transform.localPosition.x < MinPositionObject)
                    ListParallaxObject[i].ObjBack.transform.localPosition = new Vector3(MaxPositionObject, ListParallaxObject[i].ObjBack.transform.position.y, ListParallaxObject[i].ObjBack.transform.localPosition.z);
            }
            else if(RunCar.x < 0)
            {
                if (ListParallaxObject[i].AutoRun == true)
                    ListParallaxObject[i].ObjBack.transform.localPosition += new Vector3((ListParallaxObject[i].Speed.x * Time.deltaTime) + (-RunCar.x * Time.deltaTime), -(ListParallaxObject[i].Speed.y * RunCar.y * Time.deltaTime), 0f);
                else
                    ListParallaxObject[i].ObjBack.transform.localPosition += new Vector3((ListParallaxObject[i].Speed.x * Time.deltaTime) * (-RunCar.x), -(ListParallaxObject[i].Speed.y * RunCar.y * Time.deltaTime), 0f);
                if (ListParallaxObject[i].ObjBack.transform.localPosition.x > MaxPositionObject)
                    ListParallaxObject[i].ObjBack.transform.localPosition = new Vector3(MinPositionObject, ListParallaxObject[i].ObjBack.transform.position.y, ListParallaxObject[i].ObjBack.transform.localPosition.z);
            }
        }
    }
}
