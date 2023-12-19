using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PaddleController : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;

    private float maxLeft;
    private float maxRight;

    
    void Start()
    {
        cam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    
    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = cam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                offset = touchPos - transform.position;
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                
                transform.position = new Vector3(touchPos.x - offset.x, transform.position.y, 0);
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                
                transform.position = new Vector3(touchPos.x - offset.x, transform.position.y, 0);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), transform.position.y, 0);
        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = cam.ViewportToWorldPoint(new Vector2(0.07f, 0)).x;
        maxRight = cam.ViewportToWorldPoint(new Vector2(0.93f, 0)).x;
    }
}
