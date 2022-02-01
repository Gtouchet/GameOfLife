Feature: Dead cell with neighbors

@[NOK]UnsuitableBirthConditions
Scenario: 1 dead cell has 0 neighbor
	Given a big enough world for 1 cell
	And 1 dead cell 'A' with 0 alive neighbor
	When the world advances to the next generation
	Then the cell 'A' should remain dead

@[NOK]UnsuitableBirthConditions
Scenario: 1 dead cell has 1 neighbor
	Given a big enough world for 2 cells
	And 1 dead cell 'A' with 1 alive neighbor
	When the world advances to the next generation
	Then the cell 'A' should remain dead

@[NOK]UnsuitableBirthConditions
Scenario: 1 dead cell has 2 neighbors
	Given a big enough world for 3 cells
	And 1 dead cell 'A' with 2 alive neighbors
	When the world advances to the next generation
	Then the cell 'A' should remain dead

@[OK]SuitableBirthConditions
Scenario: 1 dead cell has 3 neighbors
	Given a big enough world for 4 cells
	And 1 dead cell 'A' with 3 alive neighbors
	When the world advances to the next generation
	Then the cell 'A' should be alive

@[NOK]UnsuitableBirthConditions
Scenario: 1 dead cell has 4 neighbors
	Given a big enough world for 5 cells
	And 1 dead cell 'A' with 4 alive neighbors
	When the world advances to the next generation
	Then the cell 'A' should remain dead