using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Hitboxes
{
    class HitboxManager
    {
        public List<IHitbox> items;
        public List<Hitbox> hitboxes;

        public void DrawHitboxes(SpriteBatch spriteBatch)
        {
            foreach (Hitbox hitbox in hitboxes)
            {
                spriteBatch.Draw(hitbox.Texture, hitbox.Position, Color.White);
            }
        }

        //in hitbox manager.
        private void CreateHitboxes(GraphicsDeviceManager graphics)
        {
            foreach (IHitbox item in items)
            {
                int itemWidth = item.HitboxRectangle.Width;
                int itemHeight = item.HitboxRectangle.Height;
                Vector2 position = new Vector2(item.HitboxRectangle.X, item.HitboxRectangle.Y);

                Texture2D texture = new Texture2D(graphics.GraphicsDevice, itemWidth, itemHeight);
                int pixels = itemWidth * itemHeight;
                Color[] outline = new Color[pixels];

                for (int i = 0; i < pixels; i++)
                {
                    if (i < itemWidth || i % itemWidth == 0 || i % itemWidth == itemWidth - 1 || i > pixels - itemWidth)
                    {
                        outline[i] = Color.White;
                    }
                    else
                    {
                        outline[i] = Color.Transparent;
                    }
                }

                texture.SetData(outline);

                hitboxes.Add(new Hitbox(texture, position));
            }
        }

        public void AddWantedHitboxes(List<Entity> entities, World world, GraphicsDeviceManager graphics)
        {
            this.hitboxes = new List<Hitbox>();
            this.items = new List<IHitbox>();

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
    }
}
