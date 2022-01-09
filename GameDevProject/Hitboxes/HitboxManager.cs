using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameDevProject.Hitboxes
{
    class HitboxManager
    {
        public List<IHitbox> items;
        public List<Hitbox> hitboxes;
        private List<Texture2D> textures;

        public void DrawHitboxes(SpriteBatch spriteBatch)
        {
            foreach (Hitbox hitbox in hitboxes)
            {
                spriteBatch.Draw(hitbox.Texture, hitbox.Position, Color.White);
            }
        }

        private void CreateHitboxes(GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < items.Count; i++)
            {
                int itemWidth = items[i].HitboxRectangle.Width;
                int itemHeight = items[i].HitboxRectangle.Height;
                Vector2 position = new Vector2(items[i].HitboxRectangle.X, items[i].HitboxRectangle.Y);

                this.textures.Add(new Texture2D(graphics.GraphicsDevice, itemWidth, itemHeight));
                int pixels = itemWidth * itemHeight;
                Color[] outline = new Color[pixels];

                for (int j = 0; j < pixels; j++)
                {
                    if (j < itemWidth || j % itemWidth == 0 || j % itemWidth == itemWidth - 1 || j > pixels - itemWidth)
                    {
                        outline[j] = Color.White;
                    }
                    else
                    {
                        outline[j] = Color.Transparent;
                    }
                }

                textures[i].SetData(outline);

                hitboxes.Add(new Hitbox(textures[i], position));
            }
        }

        public void AddWantedHitboxes(List<Entity> entities, World world, GraphicsDeviceManager graphics)
        {
            this.hitboxes = new List<Hitbox>();
            this.items = new List<IHitbox>();
            this.CreateNewTextures();

            if(entities != null)
            {
                foreach (IHitbox entity in entities)
                {
                    items.Add(entity);
                }
                foreach (IHitbox tile in world.GetTiles())
                {
                    Tile Tile = (Tile)tile;
                    if (Tile.IsTopCollide || Tile.IsRightCollide || Tile.IsLeftCollide || Tile.IsBottomCollide || Tile.IsFinishCollide)
                    {
                        items.Add(tile);
                    }
                }
            }

            this.CreateHitboxes(graphics);
        }

        private void CreateNewTextures()
        {
            if(textures != null)
            {
                foreach (Texture2D texture in textures)
                {
                    texture.Dispose();
                }
            }
            this.textures = new List<Texture2D>();
        }
    }
}
