//using UnityEngine;

//public class MoveAndScale : MonoBehaviour
//{
//    public float moveSpeed = 0.1f;
//    public float scaleIncrease = 0.1f;
//    public float smoothTime = 0.5f;
//    Vector3 targetPosition;
//    Vector3 velocity;

//    void Update()
//    {
//        targetPosition = new Vector3(Input.GetAxis("Horizontal") * 0.0f, -10.0f, 0.0f);

//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            // Перемещение объекта влево
//            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
//        }

//        if (Input.GetKeyDown(KeyCode.UpArrow))
//        {
//            // Увеличение размера объекта
//            transform.localScale *= (1.0f + scaleIncrease);
//        }
//    }
//}


//using UnityEngine;

//public class MoveAndScale : MonoBehaviour
//{
//    public float moveSpeed = 0.1f;
//    public float scaleIncrease = 0.1f;
//    public float smoothTime = 0.5f;
//    Vector3 targetPosition;
//    Vector3 velocity;

//    void Update()
//    {
//        targetPosition = new Vector3(Input.GetAxis("Horizontal") * 2.0f, 0.0f, 0.0f);

//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            // Перемещение объекта влево
//            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

//            // Увеличение размера объекта
//            transform.localScale *= (1.0f + scaleIncrease);
//        }

//        //if (Input.GetKeyDown(KeyCode.UpArrow))
//        //{
//        //    // Увеличение размера объекта
//        //    transform.localScale *= (1.0f + scaleIncrease);
//        //}
//    }
//}