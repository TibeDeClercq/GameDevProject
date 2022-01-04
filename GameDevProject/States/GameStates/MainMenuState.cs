using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.MainMenu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States.GameStates
{
    class MainMenuState : IGameState
    {
        private SpriteFont font;

        private List<SelectLevelButton> buttons;

        public bool CanClick;
        public MainMenuState(SpriteFont font)
        {
            this.font = font;

            this.buttons = new List<SelectLevelButton>();
            this.buttons.Add(new SelectLevelButton(new Vector2(20, 50), new Vector2(45, 10), "Level 1"));
            this.buttons.Add(new SelectLevelButton(new Vector2(120, 50), new Vector2(45, 10), "Level 2"));
        }
        public void Update(Level level, GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Released)
            {
                CanClick = true;
            }
            foreach (SelectLevelButton button in buttons)
            {
                if (mouse.X / Game1.scale >= button.Position.X && mouse.X / Game1.scale <= button.Position.X + button.Size.X)
                {
                    if (mouse.Y / Game1.scale >= button.Position.Y && mouse.Y / Game1.scale <= button.Position.Y + button.Size.Y)
                    {
                        if(mouse.LeftButton == ButtonState.Pressed && CanClick)
                        {
                            if(button == buttons[0])
                            {
                                Game1.State = State.Level1;
                            }
                            else if (button == buttons[1])
                            {
                                Game1.State = State.Level2;
                            }
                        }
                    }
                }
            }
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, "Main menu", new Vector2(70, 10), Color.Black);

            foreach (SelectLevelButton button in buttons)
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
