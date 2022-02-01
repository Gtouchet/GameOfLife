using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = Engine.Of(new byte[,]
            {
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 },
            });

            engine.ProcessNewGeneration();
        }
    }
}
