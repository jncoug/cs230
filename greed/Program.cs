﻿
/// <summary>
/// The program's entry point.
/// </summary>
class Program
{
    private static int FRAME_RATE = 12;
    private static int MAX_X = 900;
    private static int MAX_Y = 600;
    private static int CELL_SIZE = 15;
    private static int FONT_SIZE = 15;
    private static int COLS = 60;
    private static int ROWS = 40;
    private static string CAPTION = "Robot Finds Kitten";
    private static string DATA_PATH = "Data/messages.txt";
    private static Color WHITE = new Color(255, 255, 255);
    private static int DEFAULT_ARTIFACTS = 10;


    /// <summary>
    /// Starts the program using the given arguments.
    /// </summary>
    /// <param name="args">The given arguments.</param>
    static void Main(string[] args)
    {
        // create the cast
        Cast cast = new Cast();

        // create the banner
         // create the banner
        Actor banner = new Actor();
        banner.SetText("score:");
        banner.SetFontSize(20);
        banner.SetColor(WHITE);
        banner.SetPosition(new Point(CELL_SIZE, 0));
        cast.AddActor("banner", banner);

        // create the robot
        Actor robot = new Actor();
        robot.SetText("#");
        robot.SetFontSize(FONT_SIZE);
        robot.SetColor(WHITE);
        robot.SetPosition(new Point(MAX_X / 2, MAX_Y+390));
        cast.AddActor("robot", robot);

    

        // create the artifacts
        Random random = new Random();
            for (int i = 0; i < DEFAULT_ARTIFACTS; i++)
            {
                string text = "*";
                

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                Point velocity = new Point(0, 1);
                velocity = velocity.Scale(CELL_SIZE);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetVelocity(velocity);
                
                cast.AddActor("artifacts", artifact);
            }

            for (int i = 0; i < DEFAULT_ARTIFACTS; i++)
            {
                string text = "o";
                

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                Point velocity = new Point(0, 1);
                velocity = velocity.Scale(CELL_SIZE);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetVelocity(velocity);
                artifact.SetPoints(-25);
                cast.AddActor("artifacts", artifact);
            
        }


        // start the game
        KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
        VideoService videoService 
            = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
        Director director = new Director(keyboardService, videoService);
        director.StartGame(cast);

        // test comment for later use
    }
}
