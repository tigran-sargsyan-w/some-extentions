using UnityEngine;
using UnityEngine.UI;

namespace Extensions
{
    public static class ImageExtension
    {
        /// <summary>
        /// Sets alpha for Image.
        /// </summary>
        public static void Fade(this Image image, float alpha)
        {
            var color = image.color;
            color.a = alpha;
            image.color = color;
        }
        
        public static void EvaluateColor(this Image image, Gradient gradient, float percent) => 
            image.color = gradient.Evaluate(percent);
    }
}