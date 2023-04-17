using UnityEngine;

namespace Extensions
{
    public static class SpriteRendererExtension
    {
        /// <summary>
        /// Sets alpha for SpriteRenderer.
        /// </summary>
        public static void Fade(this SpriteRenderer renderer, float alpha)
        {
            Color color = renderer.color;
            color.a = alpha;
            renderer.color = color;
        }

        public static void EvaluateColor(this SpriteRenderer renderer, Gradient gradient, float percent) => 
            renderer.color = gradient.Evaluate(percent);
    }
}