using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : SingletonBase<CameraFollower>
{
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void Follow()
    {
        float interpolation = PlayerMovement.instance.GetPlayerSpeed() * Time.deltaTime;
        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, PlayerMovement.instance.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, PlayerMovement.instance.transform.position.x, interpolation);
        this.transform.position = position;
    }

    protected override void BehaveSingleton()
    {
        if (PlayerMovement.instance.GetActivated())
        {
            Follow();
        }
    }

    void Update()
    {
        BehaveSingleton();
    }
}
 