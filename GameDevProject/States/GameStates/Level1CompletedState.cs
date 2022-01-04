using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States.GameStates
{
    class Level1CompletedState : IGameState
    {
        private SpriteFont font;

        private List<Button> buttons;
        public Level1CompletedState(SpriteFont font)
        {
            this.font = font;

            this.buttons = new List<Button>();
            this.buttons.Add(new Button(new Vector2(20, 50), new Vector2(75, 10), "Next level"));
            this.buttons.Add(new Button(new Vector2(110, 50), new Vector2(75, 10), "Main Menu"));
        }

        public void Update(Level level, GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            foreach (Button button in buttons)
            {
                if (mouse.X / Game1.scale >= button.Position.X && mouse.X / Game1.scale <= button.Position.X + button.Size.X)
                {
                    if (mouse.Y / Game1.scale >= button.Position.Y && mouse.Y / Game1.scale <= button.Position.Y + button.Size.Y)
                    {
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            if (button == buttons[0])
                            {
                                Game1.State = State.Level2;
                            }
                            else if (button == buttons[1])
                            {
                                Game1.State = State.MainMenu;
                            }
                        }
                    }
                }
            }
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, "Completed Level 1", new Vector2(70, 10), Color.Black);

            foreach (Button button in buttons)
            {
                spriteBatch.DrawString(this.font, button.Text, button.Position, Color.Black);
            }
        }

        public int GetWindowHeight(Level level)
        {
            return 100;
        }

        public int GetWindowWidth(Level level)
        {
            return 200;
        }
    }
}
