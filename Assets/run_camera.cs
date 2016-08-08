using UnityEngine;
using System.Collections;

public class run_camera : MonoBehaviour {
    Vector2 run_camera_;
    // Use this for initialization
    void Start () {
        run_camera_ = gameObject.transform.position;
	}
    float delta = 0f;
	// Update is called once per frame
	void Update () {
        delta = gameObject.transform.position.x - run_camera_.x;
        if (delta != 0)
        {
            run_camera_ = gameObject.transform.position;
            Camera.main.transform.position += new Vector3(delta, 0, 0);
        }
	}
}
