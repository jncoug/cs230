﻿void main() {

    GameManager gm = new GameManager();
    gm.startGame();

}

main();

public class GameManager {

    List<Player> players = new List<Player>();
    bool gameOver = false;


    public GameManager()
    {
    }

    public int getPlayers() {

        Console.WriteLine("How many players would you like?");

        int numPlayers = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numPlayers; i++) {
            Console.WriteLine($"Enter name for Player {i}:");
            string playerName = Console.ReadLine();
            players.Add(new Player(playerName));
        }

        return numPlayers;
    }

    public int getEndScore() {

        Console.WriteLine("What score would you like to play to?");
        int endScore = int.Parse(Console.ReadLine());

        return endScore;

    }

    public void startGame() {
        Console.WriteLine("Welcome to the Hi-Low Game!");
        Console.WriteLine("*************************");
        
        Card card = new Card();

        int endScore = getEndScore();
        int numPlayers = getPlayers();
        int playersFinished = 0;

      
        bool nextIsHigher;

        while(!gameOver) {

            card.getNextCard();
            if (card.nextCard > card.currentCard) {
                nextIsHigher = true;
            }
            else {
                nextIsHigher = false;
            }
            Console.WriteLine($"The card is: {card.currentCard}");

            foreach(Player player in players) {

                if (player.isPlaying) {

                    if ((numPlayers-1 == playersFinished && numPlayers != 1) || (numPlayers == playersFinished)) {
                        gameOver = true;
                        
                    }

                    else {
                        
                        Console.WriteLine($"{player.name} ({player.score} points): Higher or Lower? (h/l)");
                        player.guess(nextIsHigher);
                        
                        if (player.score <= 0) {
                            gameOver = true;
                            player.score = 0;
                            player.endGame();
                            playersFinished++;
                        }

                        else if (player.score >= endScore) {
                            gameOver = true;
                            Console.WriteLine($"The card is: {card.nextCard}");
                            
                        }
                        
                    }
                }
            }
        }
        endGame();
    }

    public void endGame() {
        string winnerName = "";
        int winnerScore = 0;

        foreach(Player player in players) {
            
            if (player.score > winnerScore) {
                winnerScore = player.score;
                winnerName = player.name;
            }
        }

        Console.WriteLine($"The winner is {winnerName} with a score of {winnerScore}!");
    }
}


public class Player {

    public int score;
    public bool isPlaying = true;
    public string name;

    public Player(string playerName) 
    {
        name = playerName;
        score = 300;
    }

    public void guess(bool nextIsHigher) {
        
        int points;
        string input = Console.ReadLine();

        if (input == "h") {
            if (nextIsHigher) {
                points = 100;
            }
            else {
                points = -75;
            }
        }
        else { 
            if (nextIsHigher) {
                points = -75;
            }
            else {
                points = 100;
            }
        }

        score += points;
    }
    
    public void endGame() {
        if (score == 0) {
            Console.WriteLine("You finished the game with 0 points.");
        }
        else {
            Console.WriteLine($"You finished the game with {score} points.");
        }
        isPlaying = false;
    }

}

public class Card {
    public int currentCard;
    public int nextCard;
    Random random = new Random();
    

    public Card()
    {
        nextCard = random.Next(1,13);

    }
    
    public void getNextCard() {
        currentCard = nextCard;
        while (nextCard == currentCard) {
            nextCard = random.Next(1,13);
        }

    }
}
