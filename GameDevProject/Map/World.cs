using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Map
{
    class World : Interfaces.IDrawable //op betere locatie zetten?
    {
        private string name;
        private int id;

        private char[,] worldTiles;

        private List<WorldTile> tiles;

        public World(char[,] worldTiles)
        {
            this.worldTiles = worldTiles;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < worldTiles.GetLength(0); row++)
            {
                for (int tile = 0; tile < worldTiles.GetLength(1); tile++)
                {
                    Debug.WriteLine(worldTiles[row, tile]);

                }
            }
        }

        public void GetTilesFromTextureProperties(int width, int height, int numberOfWidthTiles, int numberOfHeightTiles)
        {
            int widthOfFrame = width / numberOfWidthTiles;
            int heightOfFrame = height / numberOfHeightTiles;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    tiles.Add(new WorldTile(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }

    }
}
