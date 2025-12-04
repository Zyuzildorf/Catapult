using UnityEngine;

namespace Source.Scripts
{
    public class InputReader
    {
        public bool IsShootKeyPressed() => Input.GetKey(KeyCode.Space);
        public bool IsReloadKeyPressed() => Input.GetKey(KeyCode.R);
        public bool IsSwingKeyPressed() => Input.GetKey(KeyCode.S);
    }
}