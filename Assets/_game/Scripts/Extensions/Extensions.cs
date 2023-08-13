using UnityEngine;

namespace _game._Extentions
{
    public static class Extensions
    {
        public static int MaskToInt(this LayerMask mask)
        {
            var bitmask = mask.value;
            int result = bitmask > 0 ? 0 : 31;
            while (bitmask > 1)
            {
                bitmask = bitmask >> 1;
                result++;
            }
            return result;
        } 
        
        public static float Remap (this float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
        
        
    }
}