using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public void Follow()
    {
        float interpolation = player.GetComponent<PlayerController>().GetPlayerSpeed() * Time.deltaTime;
        Vector3 position = this.transform.position;
        position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        this.transform.position = position;
    }

    public void Behave()
    {
        if (InputHandler.input.inputDetected())
        {
            Follow();
        }
    }

    void Update()
    {
        Behave();
    }
}
