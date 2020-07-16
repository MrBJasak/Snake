using UnityEngine;
using UnityEngine.UI;

namespace SA
{
    public class GameManager : MonoBehaviour
    {
        public int height = 15;
        public int width = 17;

        public Color color1;
        public Color color2;

        SpriteRenderer mapRenderer;
        GameObject mapObject;
        private void Start()
        {
            CreateMap();
        }

        void CreateMap()
        {
            mapObject = new GameObject("Map");
            mapRenderer = mapObject.AddComponent<SpriteRenderer>();

            Texture2D texture = new Texture2D(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    #region Visual
                    if (x%2!=0)
                    {
                        if (y%2!=0)
                        {
                            texture.SetPixel(x, y, color1); 
                        }
                        else
                        {
                            texture.SetPixel(x, y, color2);
                        }
                    }
                    else
                    {
                        if (y%2!=0)
                        {
                            texture.SetPixel(x, y, color2);
                        }
                        else
                        {
                            texture.SetPixel(x, y, color1);
                        }
                        
                    }
                    #endregion 
                }
            }

            texture.filterMode = FilterMode.Point;

            texture.Apply();
            Rect rect = new Rect(0, 0, width, height);
            Sprite sprite = Sprite.Create(texture, rect, Vector2.one * .5f, 1, 0, SpriteMeshType.FullRect);
            mapRenderer.sprite = sprite;
        }
    }
}