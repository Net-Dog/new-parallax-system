using UnityEngine;
using System.Collections;

public class push : MonoBehaviour
{
    Rigidbody2D body;
    public static bool stop = false;
    public bool tmp_stop = false;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //body.AddTorque(1000);
    }
    // Update is called once per frame
    float run = 0f;
    public float is_break = 0f;
    public float power_break = 0f;
    float krut_moment = 20f;
    void Update()
    {
        is_break = Input.GetAxisRaw("Vertical");
        if(is_break != 0)
        {
            if (body.velocity.x > 0)
            {
                body.velocity = new Vector2(body.velocity.x - power_break, body.velocity.y);
                power_break += 0.05f;
                body.AddTorque(0);
            }
            else
            {
                body.velocity = new Vector2(body.velocity.x + power_break, body.velocity.y);
                power_break += 0.05f;
                body.AddTorque(0);
            }
            return;
        }
        power_break = 0;
        if (Input.GetKey(KeyCode.U))
            krut_moment += 0.5f;
        run = Input.GetAxisRaw("Horizontal");
        if (run > 0)
            body.AddTorque(-krut_moment, ForceMode2D.Impulse);
        else if(run < 0)
            body.AddTorque(krut_moment, ForceMode2D.Impulse);
    }
}
