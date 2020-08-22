using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        [Header("Custom Components")]
        public PlayerController controller = null;
    }
}