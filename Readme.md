# Add em up

## Description

This is .Net console app, its focus is to add up the scores of a card game that deals random cards to players and then the score must be calculated. The dealing of the cards is out of scope for this project.

> NOTE: This project is a coding assesment project completed per the request of an possible employer.

## Running

1. Clone this repo.
2. Open terminal and cd to the project.
3. Create a file with content similar to this and name it `abc.txt`:
```txt
Player1:3D,5D,6S,AS,3H
Player2:9S,6D,9D,AH,2C
Player3:6C,3C,7S,JH,3S
Player4:7C,6D,AS,7S,QS
Player5:4D,KS,3C,8H,10D
Player6:2D,QD,9D,7H,9H
```
3. Run 'dotnet build && dotnet run --in abc.txt --out xyx.txt'

The result of the score calculation will be written to the '--out' file.

