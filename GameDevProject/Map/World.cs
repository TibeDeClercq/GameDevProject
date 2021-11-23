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

        private char[,] worldTilesTemplate;

        private List<WorldTile> tiles; //List with all different textures
        private WorldTile[,] worldTiles; //The actual world tiles

        private Texture2D texture;

        public World(char[,] worldTilesTemplate)
        {
            this.worldTilesTemplate = worldTilesTemplate;

            GetTilesFromTexture(136, 136, 8, 8);

            for (int row = 0; row < worldTilesTemplate.GetLength(0); row++)
            {
                for (int tile = 0; tile < worldTilesTemplate.GetLength(1); tile++)
                {
                    //if(worldTilesTemplate[row, tile] == 'A')
                    //{
                    //    worldTiles[row, tile] = tiles[1];
                    //}
                    worldTiles[row, tile] = tiles[1];
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < worldTilesTemplate.GetLength(0); row++)
            {
                for (int tile = 0; tile < worldTilesTemplate.GetLength(1); tile++)
                {
                    Debug.WriteLine(worldTilesTemplate[row, tile]);
                    spriteBatch.Draw(texture, new Vector2(10,10), worldTiles[row, tile].SourceRectangle, Color.White);
                }
            }
        }

        public void GetTilesFromTexture(int width, int height, int numberOfWidthTiles, int numberOfHeightTiles)
        {
            int widthOfFrame = width / numberOfWidthTiles;
            int heightOfFrame = height / numberOfHeightTiles;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    tiles.Add(new WorldTile(new Rectangle(x, y, widthOfFrame , heightOfFrame)));
                }
            }
        }

    }
}
