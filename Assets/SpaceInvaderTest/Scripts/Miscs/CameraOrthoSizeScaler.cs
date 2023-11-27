using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    [ExecuteInEditMode, RequireComponent(typeof(Camera))]
    public class CameraOrthoSizeScaler : MonoBehaviour
    {

        [SerializeField] private float targetOrthoSize = 5f;
        [SerializeField] private float targetOrthoRatio = 0.75f;

        private Camera cam;

        private void Awake()
        {
            cam = GetComponent<Camera>();
        }

        private void Update()
        {
            RecalculateOrthoSize();
        }

        private void RecalculateOrthoSize()
        {
            //get current width and height of screen
            float currentWidth = Screen.width;
            float currentHeight = Screen.height;

            if (currentWidth / currentHeight < targetOrthoRatio)
            {
                cam.orthographicSize = targetOrthoSize / currentWidth * currentHeight * targetOrthoRatio;
            }
            else
            {
                cam.orthographicSize = targetOrthoSize;
            }
        }
    }
}