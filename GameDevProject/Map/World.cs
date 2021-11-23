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
        #region Properties
        private string name;
        private int id;

        private string[,] worldTemplate;

        private List<Rectangle> tileRectangles; //List of all rectangles

        private Tile[,] tiles; //The actual world tiles

        private Texture2D tilesheet;
        #endregion

        #region Constructor
        public World(Texture2D tileset, string[,] worldTemplate)
        {
            this.worldTemplate = worldTemplate;

            this.tilesheet = tileset;

            this.tileRectangles = new List<Rectangle>();

            this.tiles = new Tile[worldTemplate.GetLength(0), worldTemplate.GetLength(1)];

            CreateTiles(136, 136, 8, 8);            
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White);
                //spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White, 0f, Vector2.Zero, 5.0f, SpriteEffects.None, 0f);
            }
        }

        private void CreateTiles(int width, int height, int numberOfWidthTiles, int numberOfHeightTiles)
        {
            int widthOfFrame = width / numberOfWidthTiles; //17
            int heightOfFrame = height / numberOfHeightTiles; //17

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    tileRectangles.Add(new Rectangle(x, y, 16, 16));
                    //tileTextures.Add(new Texture2D());
                }
            }

            //niewe methode?
            for (int y = 0; y < worldTemplate.GetLength(0); y++)
            {
                for (int x = 0; x < worldTemplate.GetLength(1); x++)
                {
                    if (worldTemplate[y, x] == "A1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[0], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[1], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[2], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[3], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[4], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[5], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[6], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "A8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[7], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[8], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[9], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[10], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[11], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[12], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[13], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[14], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "B8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[15], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[16], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[17], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[18], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[19], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[20], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[21], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[22], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "C8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[23], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[24], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[25], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[26], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[27], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[28], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[29], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[30], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "D8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[31], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[32], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[33], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[34], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[35], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[36], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[37], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[38], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "E8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[39], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[40], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[41], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[42], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[43], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[44], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[45], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[46], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "F8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[47], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G1")
                    {
                        tiles[y, x] = new Tile(tileRectangles[48], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G2")
                    {
                        tiles[y, x] = new Tile(tileRectangles[49], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G3")
                    {
                        tiles[y, x] = new Tile(tileRectangles[50], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G4")
                    {
                        tiles[y, x] = new Tile(tileRectangles[51], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G5")
                    {
                        tiles[y, x] = new Tile(tileRectangles[52], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G6")
                    {
                        tiles[y, x] = new Tile(tileRectangles[53], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G7")
                    {
                        tiles[y, x] = new Tile(tileRectangles[54], new Vector2(x * 16, y * 16));
                    }
                    if (worldTemplate[y, x] == "G8")
                    {
                        tiles[y, x] = new Tile(tileRectangles[55], new Vector2(x * 16, y * 16));
                    }
                }
            }
        }
        #endregion
    }
}
