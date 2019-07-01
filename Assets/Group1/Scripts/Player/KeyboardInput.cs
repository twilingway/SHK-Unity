using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{
    public float Speed = 5f;
    public bool Timer = true;
    public float Time = 20f;

    void Update()
    {
        TakeTime();
        Mover();
    }

    private void TakeTime()
    {
        if (Timer)
        {
            Time -= UnityEngine.Time.deltaTime;
            if (Time < 0)
            {
                Timer = false;
                Speed /= 2;
            }
        }
    }

    public void AddSpeed(float speed)
    {
        Speed *= speed;
    }
    public void AddTime(float time)
    {
        Time += time;
    }
    public void SetTimer(bool timer)
    {
        Timer = timer;
    }

    private void Mover()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, Speed * UnityEngine.Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -Speed * UnityEngine.Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Speed * UnityEngine.Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Speed * UnityEngine.Time.deltaTime, 0, 0);
    }
}
