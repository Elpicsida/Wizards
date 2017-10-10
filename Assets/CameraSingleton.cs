using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleton : MonoBehaviour
{
    public new Camera camera;
    private GameObject CurrentTarget;
    private bool IsMoving;
    public static CameraSingleton Instance { get; private set; }
    public float transitionDuration = 5f;

    public void WatchObject(GameObject gameObject)
    {
        CurrentTarget = gameObject;
        IsMoving = true;
        StopAllCoroutines();
        StartCoroutine(Transition());
    }
    
    private IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = camera.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);

            camera.transform.position = Vector3.Slerp(startingPos, new Vector3(CurrentTarget.transform.position.x, CurrentTarget.transform.position.y, startingPos.z), t);
            yield return 0;
        }
        IsMoving = false;

    }

    public void Update ()
    {
        if (!IsMoving)
        {
            camera.transform.position = new Vector3(CurrentTarget.transform.position.x, CurrentTarget.transform.position.y, camera.transform.position.z);
        }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
