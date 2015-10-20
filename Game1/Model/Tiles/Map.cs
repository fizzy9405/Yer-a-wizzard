namespace RPG.Model.Tiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using RPG.Controller;
    using RPG.Model.Enumerations;
    using RPG.View.UI;

    public class Map
    {
        public Map()
        {
            this.EnemyCounter = 0;
        }

        public List<Tile> TileMap { get; set; }

        public int TileSize { get; set; }

        public int EnemyCounter { get; set; }

        public void LoadContent(StreamReader reader)
        {
            this.TileSize = 53;
            this.TileMap = new List<Tile>();
            int x = 0;
            while (!reader.EndOfStream)
            {
                string row = reader.ReadLine();
                string[] rowTiles = row.Split(' ');

                int y = 0;
                foreach (string mapTile in rowTiles)
                {
                    if (mapTile == "1")
                    {
                        this.TileMap.Add(
                            new GrassTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));
                    }
                    else if (mapTile == "2")
                    {
                        this.TileMap.Add(
                            new RockTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));
                    }
                    else if (mapTile == "3")
                    {
                        this.TileMap.Add(
                            new PathTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));
                    }
                    else if (mapTile == "B")
                    {
                        this.TileMap.Add(
                            new GoToBlueTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));
                    }
                    else if (mapTile == "R")
                    {
                        this.TileMap.Add(
                            new GoToRedTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));
                    }
                    else if (mapTile == "G")
                    {
                        this.TileMap.Add(
                            new GoToGreenTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));
                    }
                    else if (mapTile == "F")
                    {
                        this.TileMap.Add(
                            new RedEnemyTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));

                        this.EnemyCounter++;
                    }
                    else if (mapTile == "I")
                    {
                        this.TileMap.Add(
                            new BlueEnemyTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));

                        this.EnemyCounter++;
                    }
                    else if (mapTile == "P")
                    {
                        this.TileMap.Add(
                            new GreenEnemyTile(
                                new Vector2(x, y),
                            new Rectangle(
                                x * this.TileSize,
                                y * this.TileSize,
                                this.TileSize,
                                this.TileSize)));

                        this.EnemyCounter++;
                    }

                    y++;
                }

                x++;
            }
        }
    }
}
