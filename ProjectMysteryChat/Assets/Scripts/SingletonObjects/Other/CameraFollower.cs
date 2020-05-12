using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : SingletonBase<CameraFollower>
{
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void Follow()
    {
        float interpolation = PlayerController.instance.GetPlayerSpeed() * Time.deltaTime;
        Vector3 position = this.transform.position;
        position.z = Mathf.Lerp(this.transform.position.z, PlayerController.instance.transform.position.z, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, PlayerController.instance.transform.position.x, interpolation);
        this.transform.position = position;
    }

    protected override void BehaveSingleton()
    {
        if (PlayerController.instance.GetActivated())
        {
            Follow();
        }
    }

    void Update()
    {
        BehaveSingleton();
    }
}
 