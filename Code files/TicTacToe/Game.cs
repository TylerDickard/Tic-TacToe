//
//Author: Tyler Dickard
//Description: Class file for the Tic-Tac-Toe Game
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe
{
    //
    //Class Name: Game
    //Purpose: This class runs the game and detects when it is over
    //
    public class Game
    {
        //
        //Defining Base Variables
        //
        private int userTurn = 0;
        private Shape[,] grid;
        private Coordinates[,] coord;
        public int Moves { get; set; }
        //
        //Function Name: Game()
        //Description: Default Constructor, also defines the coordinates for each hitbox for the user to click in
        //Parameters: NA
        //Returns: NA
        //
        public Game()
        {
            grid = new Shape[3, 3];
            coord = new Coordinates[3, 3];

            coord[0, 0] = new Coordinates(65, 115, 75, 125);
            coord[0, 1] = new Coordinates(116, 165, 75, 125);
            coord[0, 2] = new Coordinates(166, 215, 75, 125);
            coord[1, 0] = new Coordinates(65, 115, 126, 175);
            coord[1, 1] = new Coordinates(116, 165, 126, 175);
            coord[1, 2] = new Coordinates(166, 215, 126, 175);
            coord[2, 0] = new Coordinates(65, 115, 176, 225);
            coord[2, 1] = new Coordinates(116, 165, 176, 225);
            coord[2, 2] = new Coordinates(166, 215, 176, 225);
        }
        //
        //Function Name: NextMove()
        //Description: This function draws either an X or O depending on the click and returns who wins or if its a tie
        //Parameters: int x and int y from the Form1_MouseClick event
        //Returns: a string
        //
        public string NextMove(int x, int y)
        {
            string result = "";
            if (userTurn == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if(x >= coord[i,j].getX1() && x <= coord[i,j].getX2())
                        {
                            if(y >= coord[i,j].getY1() && y <= coord[i,j].getY2())
                            {
                                if (grid[i, j] == null)
                                {
                                    Ohs tempOh = new Ohs();
                                    grid[i, j] = tempOh;
                                    tempOh.Draw(coord[i, j].getX1(), coord[i, j].getX2(), coord[i, j].getY1(), coord[i, j].getY2());
                                    ++userTurn;
                                    ++Moves;
                                    result ="X's Turn";
                                }
                                else
                                {
                                    result ="Square Taken, Choose Another";
                                }
                            }
                        }
                    }
                }
            } 
            else if (userTurn == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (x >= coord[i, j].getX1() && x <= coord[i, j].getX2())
                        {
                            if (y >= coord[i, j].getY1() && y <= coord[i, j].getY2())
                            {
                                if (grid[i, j] == null)
                                {
                                    Exes tempX = new Exes();
                                    grid[i, j] = tempX;
                                    tempX.Draw(coord[i, j].getX1(), coord[i, j].getX2(), coord[i, j].getY1(), coord[i, j].getY2());
                                    --userTurn;
                                    ++Moves;
                                    result = "O's Turn";
                                }
                                else
                                {
                                    result = "Square Taken, Choose Another";
                                }
                            }
                        }
                    }
                }
            }
            if (isWin() == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (grid[i, 0] != null && grid[i, 1] != null && grid[i, 2] != null)
                    {
                        if (grid[i, 0].mShape == "X" && grid[i, 1].mShape == "X" && grid[i, 2].mShape == "X")
                        {
                            userTurn = 3;
                            result = "X's Win";
                        }
                        else if (grid[i, 0].mShape == "O" && grid[i, 1].mShape == "O" && grid[i, 2].mShape == "O")
                        {
                            userTurn = 3;
                            result = "O's Win";
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (grid[0, i] != null && grid[1, i] != null && grid[2, i] != null)
                    {
                        if (grid[0, i].mShape == "X" && grid[1, i].mShape == "X" && grid[2, i].mShape == "X")
                        {
                            userTurn = 3;
                            result = "X's Win";
                        }
                        else if (grid[0, i].mShape == "O" && grid[1, i].mShape == "O" && grid[2, i].mShape == "O")
                        {
                            userTurn = 3;
                            result = "O's Win";
                        }
                    }
                }
                if (grid[0, 0] != null && grid[1, 1] != null && grid[2, 2] != null)
                {
                    if (grid[0, 0].mShape ==  "X" && grid[1, 1].mShape == "X" && grid[2, 2].mShape == "X")
                    {
                        userTurn = 3;
                        result = "X's Win";
                    } 
                    else if (grid[0, 0].mShape == "O" && grid[1, 1].mShape == "O" && grid[2, 2].mShape == "O")
                    {
                        userTurn = 3;
                        result = "O's Win";
                    }
                }
                 
                if (grid[2, 0] != null && grid[1, 1] != null && grid[0, 2] != null)
                {
                    if (grid[2, 0].mShape == "X" && grid[1, 1].mShape == "X" && grid[0, 2].mShape == "X")
                    {
                        userTurn = 3;
                        result = "X's Win";
                    }
                    else if(grid[2, 0].mShape == "O" && grid[1, 1].mShape == "O" && grid[0, 2].mShape == "O")
                    {
                        userTurn = 3;
                        result = "O's Win";
                    }
                }
                
            }
            if (Moves == 9 )
            {
                if (result == "O's Win")
                {
                    result = "O's Win";
                } 
                else if (result == "X's Win")
                {
                    result = "X's Win";
                } 
                else
                {
                    result = "It's a Tie";
                }
                
            }
            return result;
        }
        //
        //Function Name: resetGrid()
        //Description: Clears the grid object making all positions null
        //Parameters: NA
        //Returns: NA
        //
        private void resetGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i,j] != null)
                    {
                        grid[i, j] = null;
                    }
                }
            }
        }
        //
        //Function Name: NewGame()
        //Description: When called this function calls resetGrid to reset the grid and then it resets the base variables.
        //Parameters: NA
        //Returns: "O's Turn"
        //
        public string NewGame()
        {
            resetGrid();
            userTurn = 0;
            Moves = 0;
            return "O's Turn";
        }
        //
        //Function Name: isWin()
        //Description: This function checks for if the game is won and if it is won in some way it returns true else it returns false
        //Parameters: NA
        //Returns: a bool variable
        //
        private bool isWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] != null && grid[i, 1] != null && grid[i, 2] != null)
                {
                    if (grid[i, 0].mShape == grid[i, 1].mShape && grid[i, 1].mShape == grid[i, 2].mShape)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (grid[0, i] != null && grid[1, i] != null && grid[2, i] != null)
                {
                    if (grid[0, i].mShape == grid[1, i].mShape && grid[1, i].mShape == grid[2, i].mShape)
                    {
                        return true;
                    }
                }
            }

            if (grid[0, 0] != null && grid[1, 1] != null && grid[2, 2] != null)
            {
                if (grid[0, 0].mShape == grid[1, 1].mShape && grid[1, 1].mShape == grid[2, 2].mShape)
                {
                    return true;
                }
            } 
            if (grid[2, 0] != null && grid[1, 1] != null && grid[0, 2] != null)
            {
                if (grid[2, 0].mShape == grid[1, 1].mShape && grid[1, 1].mShape == grid[0, 2].mShape)
                {
                    return true;
                }
            }

            if (Moves == 9)
            {
                return true;
            }
                return false;
        }

    }
    //
    //Class Name: Shape
    //Purpose: This class is the base class for the objects drawn on the form
    //
    public abstract class Shape
    {
        //base variables
        public string mShape { get; set; }
        public static Graphics g;
        //
        //Function Name: Shape()
        //Description: Base Constructor
        //Parameters: NA
        //Returns: NA
        //
        public Shape()
        {
            mShape = "";
        }
        //
        //Function Name: Draw
        //Description: This is a function prototype for the draw function
        //Parameters: int x1, int x2, int y1, int y2
        //Returns: NA
        //
        public abstract void Draw(int x1, int x2, int y1, int y2);
    }
    //
    //Class Name: Exes
    //Purpose: This class inherits from the Shape class, it sets the objects mShape to X and then draws an X
    //
    public class Exes : Shape
    {
        //
        //Function Name: Exes()
        //Description: defualt constructor
        //Parameters: NA
        //Returns: NA
        //
        public Exes()
        {
            mShape = "X";
        }
        //
        //Function Name: Draw()
        //Description: This function draws an X within the boundries of that grid
        //Parameters: int x1, int x2, int y1, int y2 
        //Returns: NA
        //
        public override void Draw(int x1, int x2, int y1, int y2)
        {
            Pen e = new Pen(Color.FromArgb(255, 115, 0), 3);
            g.DrawLine(e, x1 +5, y1 + 5, x2 -5, y2 -5);
            g.DrawLine(e, x1 +5, y2 -5, x2 -5, y1 +5);
            e.Dispose();
        }
    }
    //
    //Class Name: Ohs
    //Purpose: This class inherits from the Shape class, it sets the objects mShape to O and then draws an O
    //
    public class Ohs : Shape
    {
        //
        //Function Name: Ohs()
        //Description: defualt constructor
        //Parameters: NA
        //Returns: NA
        //
        public Ohs()
        {
            mShape = "O";
        }
        //
        //Function Name: Draw()
        //Description: This function draws an O within the boundries of that grid
        //Parameters: int x1, int x2, int y1, int y2 
        //Returns: NA
        //
        public override void Draw(int x1, int x2, int y1, int y2)
        {
            Pen e = new Pen(Color.FromArgb(79, 44, 29), 3);
            g.DrawEllipse(e, x1 +5, y1 +5, x2 -x1 -10, y2 -y1 - 10);
            e.Dispose();
        }
    }
    //
    //Class Name: Coordinates
    //Purpose: This class stores the coordinates of each hitbox a user can click on
    //
    public class Coordinates
    {
        //
        //default variables
        //
        private Rectangle cords;
        //
        //Function Name: Coordinates()
        //Description: Default Constructor
        //Parameters: NA
        //Returns: NA
        //
        public Coordinates()
        {
            cords = new Rectangle();
        }
        //
        //Function Name: Coordinates()
        //Description: Overloaded Constructor
        //Parameters: int x1, int x2, int y1, int y2
        //Returns: NA
        //
        public Coordinates(int x1, int x2, int y1, int y2)
        {
            cords = new Rectangle(x1, y1, x2, y2);
        }
        //
        //Function Name: getX1()
        //Description: Returns the x1 value
        //Parameters: NA
        //Returns: x1
        //
        public int getX1()
        {
            return this.cords.X;
        }
        //
        //Function Name: getY1()
        //Description: Returns the y1 value
        //Parameters: NA
        //Returns: y1
        //
        public int getY1()
        {
            return this.cords.Y;
        }
        //
        //Function Name: getX2()
        //Description: Returns the x2 value
        //Parameters: NA
        //Returns: x2
        //
        public int getX2()
        {
            return this.cords.Width;
        }
        //
        //Function Name: getY2()
        //Description: Returns the y2 value
        //Parameters: NA
        //Returns: y2
        //
        public int getY2()
        {
            return this.cords.Height;
        }
    }
}
