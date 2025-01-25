using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XiaoStudio;

namespace XiaoStudio
{
    public class FirstPersonCamera : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float sensitivity = 2f;
        public float minYAngle = -90f;
        public float maxYAngle = 90f;

        private float rotationX = 0f;
        private float rotationY = 180f;

        //private float initRotationY = 0f;

        private CharacterController controller;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();

            // Debug.Log(transform.localRotation.y);
            // rotationY = transform.localRotation.y;
        }

        private void Update()
        {
            // 获取鼠标输入
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // 旋转摄像机
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);
            rotationY += mouseX;

            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
            //transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

            // 获取键盘输入
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");


            // 移动摄像机
            Vector3 moveTowardOnGround = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * verticalInput
                + Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * horizontalInput;

            controller.SimpleMove(moveTowardOnGround * moveSpeed);

            updateInteraction();
        }

        private void updateInteraction()
        {
            if (!Input.GetKeyDown(KeyCode.F))
            {
                return;
            }

            Camera mainCamera = Camera.main;

            RaycastHit hit;
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = mainCamera.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out hit))
            {
                DoorController doorController = hit.collider.transform.GetComponent<DoorController>();



                Debug.Log(" hit.collider" + hit.collider.name);
                Debug.Log(hit.collider);
                Debug.Log("doorController");
                Debug.Log(doorController);

                if (doorController == null && hit.collider.transform.parent)
                {
                    Debug.Log("__");
                    Debug.Log(hit.collider.transform.parent);
                    doorController = hit.collider.transform.parent.GetComponentInParent<DoorController>();
                }

                if (doorController != null)
                {
                    doorController.Toggle();
                }
            }
        }

    }
}