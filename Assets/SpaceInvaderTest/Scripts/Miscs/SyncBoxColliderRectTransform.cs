using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceInvaderTest
{
    [RequireComponent(typeof(RectTransform), typeof(BoxCollider2D))]
    [ExecuteInEditMode]
    public class SyncBoxColliderRectTransform : MonoBehaviour
    {
        private void Awake()
        {
            //disable in play mode
            if (Application.isPlaying)
            {
                enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //if transform changed, change box collider size to match rect size
            if (transform.hasChanged)
            {
                //get the rect transform
                var rectTransform = GetComponent<RectTransform>();

                //get the box collider
                var boxCollider = GetComponent<BoxCollider2D>();

                //set the box collider size to the rect size
                boxCollider.size = rectTransform.rect.size;

                //set the box collider offset to the rect offset
                boxCollider.offset = rectTransform.rect.center;
            }
        }
    }

}