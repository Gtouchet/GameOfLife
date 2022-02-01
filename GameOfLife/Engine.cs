using System;
using System.Linq;

namespace GameOfLife
{
    public class Engine
    {
        public byte[,] World { get; private set; }
        private int Height;
        private int Width;

        private Engine(byte[,] world)
        {
            this.World = world;
            this.Height = world.GetLength(0);
            this.Width = world.GetLength(1);

            this.Display();
        }

        private Engine(int height, int width)
        {
            this.World = this.GenerateWorld(height, width);
            this.Height = height;
            this.Width = width;

            this.Display();
        }

        private Engine(int length, bool random)
        {
            int size = (int)Math.Ceiling(Math.Sqrt(length));
            this.World = this.GenerateWorld(size, size, random);
            this.Height = size;
            this.Width = size;

            this.Display();
        }

        public static Engine Of(byte[,] world)
        {
            return new Engine(world);
        }

        public static Engine Of(int height, int width)
        {
            return new Engine(height, width);
        }

        public static Engine Of(int length, bool random = false)
        {
            return new Engine(length, random);
        }

        private byte[,] GenerateWorld(int height, int width, bool random = false)
        {
            byte[,] world = new byte[height, width];

            Random rng = new Random();
            for (int i = 0; i < height; i += 1)
            {
                for (int j = 0; j < width; j += 1)
                {
                    world[i, j] = random ? (byte)rng.Next(2) : (byte)0;
                }
            }

            return world;
        }

        public byte[,] ProcessNewGeneration()
        {
            byte[,] newWorld = new byte[this.Height, this.Width];

            for (int i = 0; i < this.Height; i += 1)
            {
                for (int j = 0; j < this.Width; j += 1)
                {
                    int neighbors = this.GetAliveNeighbors(i, j);

                    if (this.World[i, j] == 1)
                    {
                        if (neighbors == 2 || neighbors == 3)
                        {
                            newWorld[i, j] = 1;
                        }
                        else
                        {
                            newWorld[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            newWorld[i, j] = 1;
                        }
                    }
                }
            }

            this.World = newWorld;

            this.Display();

            return this.World;
        }

        private int GetAliveNeighbors(int x, int y)
        {
            int neighbors = 0;

            for (int i = x - 1; i < x + 2; i += 1)
            {
                for (int j = y - 1; j < y + 2; j += 1)
                {
                    if (!((i < 0 || j < 0) || (i >= this.Height || j >= this.Width)))
                    {
                        if ((i != x || j != y) && this.World[i, j] == 1)
                        {
                            neighbors += 1;
                        }
                    }
                }
            }

            return neighbors;
        }

        public void Display()
        {
            for (int i = 0; i < this.Height; i += 1)
            {
                for (int j = 0; j < this.Width; j += 1)
                {
                    Console.Write(" " + this.World[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void AddNeighborToCell(int posX, int posY)
        {
            if (!Enumerable.Range(0, this.Width).Contains(posX) || !Enumerable.Range(0, this.Height).Contains(posY))
            {
                return;
            }

            for (int i = posX - 1; i <= posX + 1; i += 1)
            {
                for (int j = posY - 1; j <= posY + 1; j += 1)
                {
                    if ((i == posX && j == posY) || (i < 0 || i > this.Width - 1) || (j < 0 || j > this.Height - 1))
                    {
                        continue;
                    }

                    if (this.World[i, j] == 0)
                    {
                        this.World[i, j] = 1;
                        return;
                    }
                }
            }
        }
    }
}
