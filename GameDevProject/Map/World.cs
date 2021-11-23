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

        private char[,] worldTemplate;

        private List<Rectangle> tileRectangles; //List of all rectangles

        private Tile[,] tiles; //The actual world tiles

        private Texture2D tilesheet;


        public World(Texture2D tileset, char[,] worldTemplate)
        {
            this.worldTemplate = worldTemplate;

            this.tilesheet = tileset;

            this.tileRectangles = new List<Rectangle>();

            this.tiles = new Tile[worldTemplate.GetLength(0), worldTemplate.GetLength(1)];

            CreateTiles(136, 136, 8, 8);

            //GetTileTextures(136, 136, 8, 8);

            for (int y = 0; y < worldTemplate.GetLength(0); y++)
            {
                for (int x = 0; x < worldTemplate.GetLength(1); x++)
                {
                    if (worldTemplate[y, x] == 'A')
                    {
                        tiles[y, x] = new Tile(tileRectangles[38], new Vector2(x * 16, y * 16));
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White);
                //spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White, 0f, Vector2.Zero, 5.0f, SpriteEffects.None, 0f);
            }

            //for (int y = 0; y < tiles.GetLength(0); y++)
            //{
            //    for (int x = 0; x < tiles.GetLength(1); x++)
            //    {
            //        Debug.WriteLine(worldTemplate[x, y]);


            //        if(worldTemplate[x,y] == 'A')
            //        {
            //            spriteBatch.Draw(tilesheet, tiles[x, y].Position, tileTextures[1], Color.White);
            //        }
                    
            //    }
            //}
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
                    //tiles.Add(new WorldTile(new Rectangle(x, y, widthOfFrame , heightOfFrame)));
                }
            }

            //for (int y = 0; y < worldTemplate.GetLength(0); y++)
            //{
            //    for (int x = 0; x < worldTemplate.GetLength(1); x++)
            //    {
            //        tiles[y,x] = new Tile(new Rectangle((x * 16), (y * 16), 16, 16));
            //    }
            //}
        }

        //public void GetTileTextures(int width, int height, int numberOfWidthTiles, int numberOfHeightTiles)
        //{
        //    int widthOfFrame = width / numberOfWidthTiles; //17
        //    int heightOfFrame = height / numberOfHeightTiles; //17

        //    for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
        //    {
        //        for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
        //        {
        //            tiles[y / 17, x / 17] = new Tile(new Rectangle(x, y, 16, 16));

        //            //tileTextures.Add(new Texture2D());
        //            //tiles.Add(new WorldTile(new Rectangle(x, y, widthOfFrame , heightOfFrame)));
        //        }
        //    }
        //}

    }
}
