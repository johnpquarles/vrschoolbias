using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XiaoStudio
{
    public class DoorController : MonoBehaviour
    {
        private Boolean isDoorOpen = false;

        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Open()
        {
            isDoorOpen = true;
            if (animator)
            {
                animator.SetBool("IsOpen", isDoorOpen);
            }
        }

        public void Close()
        {
            isDoorOpen = false;
            if (animator)
            {
                animator.SetBool("IsOpen", isDoorOpen);
            }
        }

        public void Toggle()
        {
            isDoorOpen = !isDoorOpen;
            if (animator)
            {
                animator.SetBool("IsOpen", isDoorOpen);
            }
        }
    }
}
