﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Base
{
    public static class UIHelper
    {
        private static PointerEventData eventDataCurrentPosition;

        private static List<RaycastResult> results;

        public static bool IsMouseOverUI() {
            eventDataCurrentPosition = new PointerEventData(EventSystem.current) {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
            };
            results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}