using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] private DataShipDisplay defaultDataShipDisplay;
        [SerializeField] private SpaceShipDisplay display;        
        [SerializeField] private float speed = 5f;
        [SerializeField] private BoxCollider2D rectMoveArea;

        private DataShipDisplay dataDisplay;

        private void Awake()
        {
            SetDataShipDisplay(defaultDataShipDisplay);
        }

        public void SetDataShipDisplay(DataShipDisplay dataShipDisplay)
        {
            this.dataDisplay = dataShipDisplay;

            //destroy old display
            if (this.display != null)
            {
                Destroy(this.display.gameObject);
            }

            this.display = Instantiate(dataShipDisplay.SpaceShipDisplay, transform);
        }

        public void SetMoveDirection(Vector2 direction)
        {
            transform.Translate(direction * Time.deltaTime * speed);

            //get the bound from rectMoveArea
            Bounds area = rectMoveArea.bounds;

            //clamp the spaceship position in area
            Vector2 position = transform.position;
            position.x = Mathf.Clamp(position.x, area.min.x, area.max.x);
            position.y = Mathf.Clamp(position.y, area.min.y, area.max.y);
            transform.position = position;
        }

        public void PlayGameover()
        {
            display.PlayDeathAnimation();
        }
    }

}