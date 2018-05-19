using UnityEngine;

namespace Assets.Scripts
{
    public class DragCamera : MonoBehaviour
    {
        public float DragStrength = 0.05f;

        private Vector3 _positionOnScreen;

	    private void Update ()
	    {
	        if (Input.GetMouseButtonDown(0))
	            _positionOnScreen = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            else if (Input.GetMouseButton(0))
	        {
	            transform.position += (_positionOnScreen - new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y)) * DragStrength;
	            _positionOnScreen = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
	        }
        }
    }
}
