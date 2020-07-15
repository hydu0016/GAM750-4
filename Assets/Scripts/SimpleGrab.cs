using UnityEngine;

public class SimpleGrab : MonoBehaviour
{
    private PlayerInput playerInput;
    private GameObject cube;
    private Rigidbody cubeRigidbody;
    private Grabbable grabbable;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }


    void Update()
    {
        if (cube != null && !playerInput.Grabbing)
        {
            grabbable.Grabbed = false;
            cube.transform.parent = null;
            cubeRigidbody.useGravity = true;
            cubeRigidbody.isKinematic = false;
            cubeRigidbody = null;
            cube = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cube == null)
        {
            Debug.Log("Grabbing");
            var grabbableCheck = other.GetComponent<Grabbable>();
            if (grabbableCheck != null)
            {
                grabbable = grabbableCheck;

                if (playerInput.Grabbing && grabbable.Grabbed == false)
                {
                    cube = other.gameObject;
                    cubeRigidbody = cube.GetComponent<Rigidbody>();
                    grabbable.Grabbed = true;
                    cube.transform.parent = transform;
                    cubeRigidbody.useGravity = false;
                    cubeRigidbody.isKinematic = true;
                }
            }
        }
    }
}
