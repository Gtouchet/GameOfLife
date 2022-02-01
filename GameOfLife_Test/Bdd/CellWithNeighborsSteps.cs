using FluentAssertions;
using GameOfLife;
using System;
using TechTalk.SpecFlow;

namespace GameOfLife_Test.Bdd
{
    [Binding]
    public class AliveCellWithNeighborsSteps
    {
        private Engine Engine;
        private int CellPositionX, CellPositionY;

        [Given(@"a big enough world for (.*) cell(?:s)?")]
        public void GivenABigEnoughWorldForCells(int totalCellCount)
        {
            this.Engine = Engine.Of(totalCellCount);
        }

        [Given(@"1 alive cell 'A' with (.*) alive neighbor(?:s)?")]
        public void GivenAliveCellWithAliveNeighbor(int totalNeighborCount)
        {
            this.CellPositionX = (int)Math.Floor((double)this.Engine.World.GetLength(0) / 2);
            this.CellPositionY = (int)Math.Floor((double)this.Engine.World.GetLength(1) / 2);
            this.Engine.World[this.CellPositionX, this.CellPositionY] = 1;

            for (int i = 0; i < totalNeighborCount; i += 1)
            {
                this.Engine.AddNeighborToCell(this.CellPositionX, this.CellPositionY);
            }
        }

        [Given(@"1 dead cell 'A' with (.*) alive neighbor(?:s)?")]
        public void GivenDeadCellWithAliveNeighbor(int totalNeighborCount)
        {
            this.CellPositionX = (int)Math.Floor((double)this.Engine.World.GetLength(0) / 2);
            this.CellPositionY = (int)Math.Floor((double)this.Engine.World.GetLength(1) / 2);

            for (int i = 0; i < totalNeighborCount; i += 1)
            {
                this.Engine.AddNeighborToCell(this.CellPositionX, this.CellPositionY);
            }
        }

        [When(@"the world advances to the next generation")]
        public void WhenTheWorldAdvancesToTheNextGeneration()
        {
            this.Engine.ProcessNewGeneration();
        }

        [Then(@"the cell 'A' should be dead")]
        public void ThenTheCellShouldBeDead()
        {
            this.Engine.World[this.CellPositionX, this.CellPositionY].Should().Be(0);
        }

        [Then(@"the cell 'A' should remain alive")]
        public void ThenTheCellShouldRemainAlive()
        {
            this.Engine.World[this.CellPositionX, this.CellPositionY].Should().Be(1);
        }

        [Then(@"the cell 'A' should remain dead")]
        public void ThenTheCellShouldRemainDead()
        {
            this.Engine.World[this.CellPositionX, this.CellPositionY].Should().Be(0);
        }

        [Then(@"the cell 'A' should be alive")]
        public void ThenTheCellShouldBeAlive()
        {
            this.Engine.World[this.CellPositionX, this.CellPositionY].Should().Be(1);
        }
    }
}
