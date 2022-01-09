using GameDevProject.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class LevelManager
    {
        public string[,] GetMainMenuMap()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C2", "C3", "C1", "C2", "C2", "C2", "C2", "C2", "C3", "C1", "C2", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "A1", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "C1", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };
            return map;
        }

        public string[,] GetLevel1Map()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "E2", "E1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "A6", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "E8", "D7", "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "B6", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "E2", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "C6", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "D5", "F8", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "D2", "D2", "D2", "D2", "D3", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "E8", "D7", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3", "D5", "F8", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "E1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "D5", "D6", "D7", "A1", "A2", "A2", "F2", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "E8", "D7", "B1", "B3", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "D1", "D2", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A3", "D5", "D6", "D6", "D7", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "D1", "D2", "D3", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "E3", "E3", "E3", "B3", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "A1", "A3", "G1", "G1", "G1", "B1", "E3", "E3", "E3", "B3", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "B1", "B3", "F4", "F4", "F4", "B1", "E3", "E3", "E3", "F1", "A2", "A2", "A2", "A2", "F2", "B3", "F4", "F4", "F4", "B1", "E3", "E3", "E3", "B3", "F4", "F4", "F4", "F4", "F4", "F4", "F4", "F4", "F4", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "F2", "F1", "A2", "A2", "A2", "F2", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "F1", "A2", "A2", "A2", "F2", "E3", "E3", "E3", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };

            return map;
        }

        public List<Enemy> GetLevel1Enemies(Player player, List<Texture2D> type1EnemyTextures, List<Texture2D> type2EnemyTextures)
        {
            List<Enemy> enemies = new List<Enemy>();

            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(17, 18)));
            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(4, 10)));
            enemies.Add(new Type2Enemy(type2EnemyTextures, player, new Vector2(26, 11)));

            return enemies;
        }

        public List<Coin> GetLevel1Coins(List<Texture2D> coinTextures)
        {
            List<Coin> coins = new List<Coin>();

            coins.Add(new Coin(coinTextures, new Vector2(11, 15)));
            coins.Add(new Coin(coinTextures, new Vector2(11, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(14, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(17, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(16, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(17, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(18, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(19, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(26, 16)));
            coins.Add(new Coin(coinTextures, new Vector2(28, 16)));
            coins.Add(new Coin(coinTextures, new Vector2(35, 14)));
            coins.Add(new Coin(coinTextures, new Vector2(38, 11)));
            coins.Add(new Coin(coinTextures, new Vector2(33, 7)));

            return coins;
        }


        public string[,] GetLevel2Map()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "A5", "B1", "B3"},
                                { "B1", "B3", "F4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "C5", "B1", "B3"},
                                { "B1", "B3", "D5", "F8", "G1", "G1", "G1", "G1", "G1", "G1", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "D1", "D2", "D2", "D2", "D2", "D3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "D1", "D3", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "A1", "A3", "G1", "G1", "G1", "G1", "G1", "G1", "E8", "D7", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "F4", "F4", "F4", "F4", "F4", "F4", "F4", "F4", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "E8", "D7", "D1", "D2", "D2", "C3", "D5", "D6", "D7", "D1", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D3", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "F4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "D5", "D6", "D6", "D6", "D7", "D1", "D2", "D2", "D2", "D2", "D2", "D3", "D5", "F8", "G1", "G1", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A3", "D5", "F8", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "E3", "E3", "E3", "B3", "G1", "G1", "G1", "G1", "A1", "A3", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "F4", "G1", "G1", "G1", "F4", "B4", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "F4", "B1", "E3", "E3", "E3", "B3", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D2", "D3", "D5", "D6", "D7", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "D1", "D2", "D2", "D2", "D2", "D2", "D3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "A1", "A3", "D5", "D6", "D7", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "A1", "A2", "A3", "D5", "G1", "G1", "G1", "A1", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "B1", "E3", "B3", "F4", "F4", "F4", "F4", "B1", "E3", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "F4", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3", "F4", "F4", "F4", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "F2", "E3", "F1", "A2", "A2", "A2", "A2", "F2", "E3", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "F1", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };

            return map;
        }

        public List<Enemy> GetLevel2Enemies(Player player, List<Texture2D> type1EnemyTextures, List<Texture2D> type2EnemyTextures)
        {
            List<Enemy> enemies = new List<Enemy>();

            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(29, 19)));
            enemies.Add(new Type2Enemy(type2EnemyTextures, player, new Vector2(28, 13)));
            enemies.Add(new Type2Enemy(type2EnemyTextures, player, new Vector2(14, 13)));
            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(11, 13)));
            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(4, 10)));
            enemies.Add(new Type2Enemy(type2EnemyTextures, player, new Vector2(9, 7)));
            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(19, 7)));
            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(22, 7)));
            enemies.Add(new Type1Enemy(type1EnemyTextures, player, new Vector2(22, 7)));

            return enemies;
        }

        public List<Coin> GetLevel2Coins(List<Texture2D> coinTextures)
        {
            List<Coin> coins = new List<Coin>();

            coins.Add(new Coin(coinTextures, new Vector2(10, 16)));
            coins.Add(new Coin(coinTextures, new Vector2(13, 16)));
            coins.Add(new Coin(coinTextures, new Vector2(21, 16)));
            coins.Add(new Coin(coinTextures, new Vector2(25, 16)));
            coins.Add(new Coin(coinTextures, new Vector2(21, 19)));
            coins.Add(new Coin(coinTextures, new Vector2(22, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(23, 19)));
            coins.Add(new Coin(coinTextures, new Vector2(24, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(25, 19)));
            coins.Add(new Coin(coinTextures, new Vector2(36, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(37, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(38, 18)));
            coins.Add(new Coin(coinTextures, new Vector2(37, 12)));
            coins.Add(new Coin(coinTextures, new Vector2(25, 10)));
            coins.Add(new Coin(coinTextures, new Vector2(22, 11)));
            coins.Add(new Coin(coinTextures, new Vector2(10, 12)));
            coins.Add(new Coin(coinTextures, new Vector2(10, 13)));
            coins.Add(new Coin(coinTextures, new Vector2(9, 12)));
            coins.Add(new Coin(coinTextures, new Vector2(9, 13)));
            coins.Add(new Coin(coinTextures, new Vector2(6, 12)));
            coins.Add(new Coin(coinTextures, new Vector2(5, 12)));
            coins.Add(new Coin(coinTextures, new Vector2(4, 12)));
            coins.Add(new Coin(coinTextures, new Vector2(6, 13)));
            coins.Add(new Coin(coinTextures, new Vector2(5, 13)));
            coins.Add(new Coin(coinTextures, new Vector2(4, 13)));
            coins.Add(new Coin(coinTextures, new Vector2(4, 3)));
            coins.Add(new Coin(coinTextures, new Vector2(4, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(8, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(9, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(10, 4)));
            coins.Add(new Coin(coinTextures, new Vector2(8, 5)));
            coins.Add(new Coin(coinTextures, new Vector2(9, 5)));
            coins.Add(new Coin(coinTextures, new Vector2(10, 5)));
            coins.Add(new Coin(coinTextures, new Vector2(8, 6)));
            coins.Add(new Coin(coinTextures, new Vector2(9, 6)));
            coins.Add(new Coin(coinTextures, new Vector2(10, 6)));
            coins.Add(new Coin(coinTextures, new Vector2(19, 6)));
            coins.Add(new Coin(coinTextures, new Vector2(22, 6)));
            coins.Add(new Coin(coinTextures, new Vector2(20, 3)));
            coins.Add(new Coin(coinTextures, new Vector2(21, 3)));
            coins.Add(new Coin(coinTextures, new Vector2(27, 6)));
            coins.Add(new Coin(coinTextures, new Vector2(30, 5)));
            coins.Add(new Coin(coinTextures, new Vector2(34, 4)));

            return coins;
        }

        public string[,] GetGameOverMap()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C3", "B1", "E4", "E4", "E4", "E4", "E4", "E4", "E4", "B3", "C1", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "A1", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A2", "A3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "C1", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };

            return map;
        }
        public string[,] GetLevelCompletedMap()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C3", "B1", "E4", "E4", "E4", "E4", "E4", "E4", "E4", "B3", "C1", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "A1", "A2", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A2", "A3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "C1", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };

            return map;
        }
    }
}
