/********************************************************
 *  PROGRAM : Assignment5                               *
 *                                                      *
 *  PROGRAMMERS : Josue Ballona and Dominykas Karalius  *
 *  ZID : Z1832823 and Z1809478                         *
 *                                                      *
 *  DATE : 11/14/2019 Thursday, November 14th 2019      *
 *                                                      *
 *                                                      *
 * Tetris                                               *
 *******************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;


namespace Assignment5
{
    //Shape logic, includes shape type, color, and rotations
    class Shape
    {
        public delegate void TouchDownEventHandler(Shape sender);
        public event TouchDownEventHandler TouchDown;

        //Definitions for the shape types
        private Point[][] shapeType =
        {
            new Point[]{new Point(6, -1),new Point(6, -2),new Point(6, -3),new Point(7, -2)}, //T-Shape
            new Point[]{new Point(4, -1),new Point(4, -2),new Point(5, -2),new Point(6, -2)}, //L-Shape
            new Point[]{new Point(4, -1),new Point(4, -2),new Point(5, -1),new Point(6, -1)}, //Inverted L-Shape
            new Point[]{new Point(4, -2),new Point(5, -1),new Point(5, -2),new Point(6, -1)}, //Z-Shape
            new Point[]{new Point(4, -1),new Point(5, -1),new Point(5, -2),new Point(6, -2)}, //Inverted Z-Shape
            new Point[]{new Point(4, -1),new Point(4, -2),new Point(4, -3),new Point(4, -4)}, //Line-Shape
            new Point[]{new Point(4, -1),new Point(4, -2),new Point(5, -1),new Point(5, -2)} //Square-Shape
        };

        //Declaring Dictionary of rotations
        private Dictionary<int, Point[][]> rotationOffsets = new Dictionary<int, Point[][]>();

        private int type;
        private string shapeColor;
        private Point[] currentPoints;
        private int rotationIndex = 0;

        //Public properties
        public string ShapeColor { get => shapeColor; }
        public Point[] CurrentPoints { get => currentPoints; }
        public int RotationIndex { get => rotationIndex; set => rotationIndex = value; }

        //Constructor
        public Shape(int type, string shapeColor)
        {
            this.type = type;
            this.shapeColor = shapeColor;
            this.currentPoints = shapeType[type];

            //Rotation definitions
            rotationOffsets.Add(0, new[]
            {
                new Point[]{new Point(0, -1),new Point(1, 1),new Point(1, 1),new Point(1, 0)},
                new Point[]{new Point(0, 0),new Point(0, 0),new Point(0, 0),new Point(-1, -1)},
                new Point[]{new Point(0, 1),new Point(0, 0),new Point(0, 0),new Point(1, 2)},
                new Point[]{new Point(0, 0),new Point(-1, -1),new Point(-1, -1),new Point(-1, -1)}
        });

            rotationOffsets.Add(1, new[]
            {
                new Point[]{new Point(0, -2),new Point(1, -1),new Point(0, 0),new Point(-1, 1)},
                new Point[]{new Point(0, 2),new Point(0, 2),new Point(1, 1),new Point(1, -1)},
                new Point[]{new Point(0, 0),new Point(-1, -1),new Point(-2, -2),new Point(-1, 1)},
                new Point[]{new Point(0, 0),new Point(0, 0),new Point(1, 1),new Point(1, -1)}
        });

            rotationOffsets.Add(2, new[]
            {
                new Point[]{new Point(0, 0),new Point(0, 0),new Point(-1, -2),new Point(-1, -2)},
                new Point[]{new Point(0, -1),new Point(1, 0),new Point(2, 2),new Point(1, 1)},
                new Point[]{new Point(0, 1),new Point(0, 1),new Point(-1, -1),new Point(-1, -1)},
                new Point[]{new Point(0, 0),new Point(-1, -1),new Point(0, 1),new Point(1, 2)}
        });

            rotationOffsets.Add(3, new[]
            {
                new Point[]{new Point(0, 1),new Point(-1, -1),new Point(0, 0),new Point(-1, -2)},
                new Point[]{new Point(0, -1),new Point(1, 1),new Point(0, 0),new Point(1, 2)},
                new Point[]{new Point(0, 1),new Point(-1, -1),new Point(0, 0),new Point(-1, -2)},
                new Point[]{new Point(0, -1),new Point(1, 1),new Point(0, 0),new Point(1, 2)}
        });

            rotationOffsets.Add(4, new[]
            {
                new Point[]{new Point(0, -1),new Point(-1, -2),new Point(0, 1),new Point(-1, 0)},
                new Point[]{new Point(0, 1),new Point(1, 2),new Point(0, -1),new Point(1, 0)},
                new Point[]{new Point(0, -1),new Point(-1, -2),new Point(0, 1),new Point(-1, 0)},
                new Point[]{new Point(0, 1),new Point(1, 2),new Point(0, -1),new Point(1, 0)}
        });

            rotationOffsets.Add(5, new[]
            {
                new Point[]{new Point(0, 0),new Point(1, 1),new Point(2, 2),new Point(3, 3)},
                new Point[]{new Point(0, 0),new Point(-1, -1),new Point(-2, -2),new Point(-3, -3)},
                new Point[]{new Point(0, 0),new Point(1, 1),new Point(2, 2),new Point(3, 3)},
                new Point[]{new Point(0, 0),new Point(-1, -1),new Point(-2, -2),new Point(-3, -3)}
        });
        }

        //Move down logic
        public string[][] moveDown(string[][] grid)
        {
            Point[] pts = CurrentPoints;
            foreach (Point p in CurrentPoints)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = "";
                }
            }
            if (canMoveDown(CurrentPoints, grid))
            {
                for (int x = 0; x < CurrentPoints.Count(); x++)
                {
                    CurrentPoints[x].Y += 1;
                    Point p = CurrentPoints[x];
                    if (p.Y >= 0)
                    {
                        grid[p.Y][p.X] = ShapeColor;
                    }
                }
            }
            else
            {
                foreach (Point p in pts)
                {
                    if (p.Y >= 0)
                    {
                        grid[p.Y][p.X] = ShapeColor;
                    }
                }
            }
            return grid;
        }
        private bool canMoveDown(Point[] pts, string[][] grid)
        {
            foreach (Point p in pts)
            {
                if (p.Y + 1 > 14)
                {
                    if (TouchDown != null)
                    {
                        TouchDown(this);
                        return false;
                    }
                }
                if (p.Y >= 0)
                {
                    if (!string.IsNullOrEmpty(grid[p.Y + 1][p.X]))
                    {
                        if (TouchDown != null)
                        {
                            TouchDown(this);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //Move left logic
        public string[][] moveLeft(string[][] grid)
        {
            foreach (Point p in CurrentPoints)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = "";
                }
            }
            Point[] pts = CurrentPoints;
            if (canMoveLeft(CurrentPoints, grid))
            {
                for (int x = 0; x < CurrentPoints.Count(); x++)
                {
                    if (CurrentPoints[x].X > 0)
                    {
                        CurrentPoints[x].X -= 1;
                        Point p = CurrentPoints[x];
                        grid[p.Y][p.X] = ShapeColor;
                    }
                }
            }
            else
            {
                foreach (Point p in pts)
                {
                    if (p.Y >= 0)
                    {
                        grid[p.Y][p.X] = ShapeColor;
                    }
                }
            }
            return grid;
        }
        private bool canMoveLeft(Point[] pts, string[][] grid)
        {
            if (pts.Any((p) => p.Y == -1))
            {
                return false;
            }
            foreach (Point p in pts)
            {
                if (p.X - 1 < 0)
                {
                    return false;
                }
                if (p.Y >= 0 && (p.X > 0 && p.X < 9))
                {
                    if (!string.IsNullOrEmpty(grid[p.Y][p.X - 1]))
                    {
                        return false;
                    }
                }
                else if (p.X < 0 || p.X > 9)
                {
                    return false;
                }
            }
            return true;
        }

        //Move right logic
        public string[][] moveRight(string[][] grid)
        {
            foreach (Point p in CurrentPoints)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = "";
                }
            }
            Point[] pts = CurrentPoints;
            if (canMoveRight(CurrentPoints, grid))
            {
                for (int x = 0; x < CurrentPoints.Count(); x++)
                {
                    if (CurrentPoints[x].X < 9)
                    {
                        CurrentPoints[x].X += 1;
                        Point p = CurrentPoints[x];
                        grid[p.Y][p.X] = ShapeColor;
                    }
                }
            }
            else
            {
                foreach (Point p in pts)
                {
                    if (p.Y >= 0)
                    {
                        grid[p.Y][p.X] = ShapeColor;
                    }
                }
            }
            return grid;
        }
        private bool canMoveRight(Point[] pts, string[][] grid)
        {
            if (pts.Any((p) => p.Y == -1))
            {
                return false;
            }
            foreach (Point p in pts)
            {
                if (p.X + 1 > 9)
                {
                    return false;
                }
                if (p.Y >= 0 && (p.X > 0 && p.X < 9))
                {
                    if (!string.IsNullOrEmpty(grid[p.Y][p.X + 1]))
                    {
                        return false;
                    }
                }
                else if (p.X < 0 || p.X > 9)
                {
                    return false;
                }
            }
            return true;
        }

        //Rotate logic
        public string[][] rotateShape(string[][] grid)
        {
            if (type == 6)
            {
                return grid;
            }

            foreach (Point p in CurrentPoints)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = "";
                }
            }
            if (RotationIndex == 4)
            {
                RotationIndex = 0;
            }
            Point[] pts = (Point[])CurrentPoints.Clone();

            for (int x = 0; x < pts.Count(); x++)
            {
                pts[x].Offset(rotationOffsets[type][RotationIndex][x]);
            }
            if (canRotate(pts, grid))
            {
                currentPoints = pts;
                RotationIndex += 1;
            }
            foreach (Point p in CurrentPoints)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
            return grid;
        }
        private bool canRotate(Point[] pts, string[][] grid)
        {
            foreach (Point p in pts)
            {
                if (p.Y >= 0)
                {
                    if (p.X < 0 || p.X > 9)
                    {
                        return false;
                    }
                    if (!string.IsNullOrEmpty(grid[p.Y][p.X]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    //ShapePreview, empty datagridview, will be populated later
    class ShapePreview : DataGridView
    {
    }

    //General game logic
    class Game : DataGridView
    {
        //Timers that are used in shifting blocks down and deleting full rows
        private System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer { Interval = 1000 };
        private System.Windows.Forms.Timer deletetmr = new System.Windows.Forms.Timer { Interval = 125 };

        //Counters for rows,level, and moves
        private int rowCounter = 0;
        private int levelCounter = 1;
        private int moveCounter = 0;

        //Random generator for shape color and shape type
        private Random rand = new Random();

        //Delete timer variables
        private int deleteCounter = 1;
        private int deleteRow;
        private bool missATick = false;

        //Variables that hold information about the shape and grid
        private string[][] gameGrid; //Points use on the grid
        private Shape currentShape; //The current shape in play
        private List<Shape> listShapes = new List<Shape>(); //List of shapes that currently exist

        //Event handlers
        public delegate void IncrementScoreEventHandler(int newPoints);
        public delegate void IncrementLineEventHandler(int newLines);
        public delegate void LevelUpEventHandler(int newLevel);
        public event IncrementScoreEventHandler IncrementScore;
        public event IncrementLineEventHandler IncrementLines;
        public event LevelUpEventHandler LevelUp;
        public delegate void ShapeChangedEventHandler(Point[] shapePoints, string shapeColor);
        public event ShapeChangedEventHandler ShapeChanged;

        //Constructor
        public Game()
        {
            this.DoubleBuffered = true;
            tmr.Tick += tmr_Tick;
            deletetmr.Tick += deletetmr_Tick;
        }

        //Clears the grid and creates a new game
        public void newGame()
        {
            tmr.Stop(); //Stops the tmr
            tmr.Interval = 1000; //Default value of 1 second (Blocks drop 1 row per second)
            listShapes.Clear(); //Clears the list of shapes
            moveCounter = 0; //Sets the counter of moves to 0

            gameGrid = new string[15][]; //15 Rows
            for (int x = 1; x <= 15; x++)
            {
                string[] row = new string[10];
                gameGrid[x - 1] = (string[])row.Clone();
            }
            newShape();
            currentShape = listShapes[0];

            if (ShapeChanged != null)
            {
                ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
            }
            rowCounter = 0;

            //Start timers
            tmr.Start();
            deletetmr.Start();
        }

        //Simple method that stops the tmr timer to prevent blocks from moving down
        public void pauseGame()
        {
            tmr.Stop();
        }

        //Simple method that starts the tmr timer again, to let the blocks continue moving
        public void resumeGame()
        {
            tmr.Start();
        }

        //Method that creates a new falling shape
        private void newShape()
        {
            string[] colors = { "R", "G", "B", "Y", "P", "C", "T" }; //All available color choices

            //Create a new random shape, with random shape type and shape color
            Shape newShape = new Shape(rand.Next(0, 7), colors[rand.Next(0, 7)]);

            //Adds the new shape to the list of current shapes
            listShapes.Add(newShape);

            newShape.TouchDown += currentShape_TouchDown;
            HasChanged(gameGrid, false, -1);
        }

        //Method for when 'A' is clicked
        public void moveLeft()
        {
            //If no shape, just return
            if (currentShape == null)
            {
                return;
            }

            //Else, call moveLeft method
            gameGrid = currentShape.moveLeft(gameGrid);
            HasChanged(gameGrid, false, -1);
        }

        //Method for when 'D' arrow is clicked
        public void moveRight()
        {
            //If no shape, just return
            if (currentShape == null)
            {
                return;
            }

            //Else, call moveRight method
            gameGrid = currentShape.moveRight(gameGrid);
            HasChanged(gameGrid, false, -1);
        }

        //Method for when 'S' arrow is clicked
        public void moveDown()
        {
            do
            {
                for (int x = 0; x < listShapes.Count; x++)
                {
                    if (x > listShapes.Count - 1)
                    {
                        goto Continue;
                    }
                    gameGrid = listShapes[x].moveDown(gameGrid);
                    HasChanged(gameGrid, false, -1);
                }
                break;
            Continue:;
            } while (true);
            moveCounter += 1;
        }

        //Method for when 'W' arrow is clicked
        public void rotateShape()
        {
            //If no shape, just return
            if (currentShape == null)
            {
                return;
            }
            //Else, call rotateShape method
            gameGrid = currentShape.rotateShape(gameGrid);
            HasChanged(gameGrid, false, -1);
        }

        //Every tick on tmr, moves down the block by 1 row
        private void tmr_Tick(object sender, EventArgs e)
        {
            if (missATick)
            {
                return;
            }
            //If overflows the edge?
            if (moveCounter >= 27)
            {
                moveCounter = 0;

                newShape();
                if (listShapes.Count == 1)
                {
                    currentShape = listShapes[0];
                    if (ShapeChanged != null)
                    {
                        ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
                    }
                }
            }
            moveDown();
        }

        //Method for when the block hits another block or the bottom of the board
        private void currentShape_TouchDown(Shape sender)
        {
            if (sender.CurrentPoints.Any((p) => p.Y < 0))
            {
                tmr.Stop();
            }
            currentShape.TouchDown -= currentShape_TouchDown;
            listShapes.Remove(sender);

            if (listShapes.Count < 1)
            {
                currentShape = null;
                moveCounter = 27;
            }
            else
            {
                currentShape = listShapes[0];
                if (ShapeChanged != null)
                {
                    ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
                }
            }
        }

        //Deletes full rows and rewards points and possible level up
        private void deletetmr_Tick(object sender, EventArgs e)
        {

            switch (deleteCounter)
            {
                case 1:
                    deleteRow = findFullRow();
                    if (deleteRow > -1)
                    {
                        deleteCounter = 2;
                        HasChanged(gameGrid, true, deleteRow);
                    }
                    break;
                case 2:
                    deleteCounter = 3;
                    HasChanged(gameGrid, false, -1);
                    break;
                case 3:
                    deleteCounter = 4;
                    HasChanged(gameGrid, true, deleteRow);
                    break;
                case 4:
                    List<string[]> newGrid = new List<string[]>(gameGrid);
                    if (listShapes.Count == 0) { return; }
                    foreach (Point p in listShapes.Last().CurrentPoints)
                    {
                        if (p.Y > -1)
                        {
                            newGrid[p.Y][p.X] = "";
                        }
                    }

                    string[] newRow = new string[10];
                    newGrid.RemoveAt(deleteRow);
                    newGrid.Insert(0, newRow);

                    missATick = true;
                    gameGrid = newGrid.ToArray();
                    deleteCounter = 1;
                    moveDown();

                    HasChanged(gameGrid, false, -1);
                    missATick = false;

                    rowCounter += 1;
                    IncrementLines(rowCounter);

                    //Initial phase of game (Level 1)
                    if(rowCounter < 5)
                    {
                        IncrementScore(200);
                    }
                    //If user has 10 or more  but no more than 19, reward more points and go faster (Level 2)
                    if(rowCounter >= 5 && rowCounter <= 10)
                    {
                        if(levelCounter == 1)
                        {
                            levelCounter += 1; //Add 1 to level, make it level 2
                            LevelUp(levelCounter);
                            IncrementScore(400);
                            tmr.Interval = 750; //Change interval at which blocks fall
                        }
                        if(levelCounter == 2)
                        {
                            IncrementScore(400);
                        }
                    }
                    //Level 3
                    if (rowCounter > 10 && rowCounter <= 15)
                    {
                        if (levelCounter == 2)
                        {
                            levelCounter += 1; //Add 1 to level, make it level 3
                            LevelUp(levelCounter);
                            IncrementScore(800);
                            tmr.Interval = 500; //Change interval at which blocks fall
                        }
                        if (levelCounter == 3)
                        {
                            IncrementScore(800);
                        }
                    }
                    //Level 4
                    if(rowCounter > 15 && rowCounter <= 20)
                    {
                        if (levelCounter == 3)
                        {
                            levelCounter += 1; //Add 1 to level, make it level 4
                            LevelUp(levelCounter);
                            IncrementScore(1600);
                            tmr.Interval = 400; //Change interval at which blocks fall
                        }
                        if (levelCounter == 4)
                        {
                            IncrementScore(1600);
                        }
                    }
                    //Level 5, max level
                    if (rowCounter > 20)
                    {
                        if (levelCounter == 5)
                        {
                            levelCounter += 1; //Add 1 to level, make it level 5
                            LevelUp(levelCounter);
                            IncrementScore(3200);
                            tmr.Interval = 250; //Change interval at which blocks fall
                        }
                        if (levelCounter == 5)
                        {
                            IncrementScore(3200);
                        }
                    }
                    break;
            }
        }

        //Method that finds a full row in the game
        private int findFullRow()
        {
            //Iterates through every row on the board
            for (int x = 14; x >= 0; x--)
            {
                if (gameGrid[x].All((s) => !string.IsNullOrEmpty(s)))
                {
                    return x;
                }
            }
            return -1;
        }

        //This method handles coloring in the cells with the current block
        private void HasChanged(string[][] grid, bool delete, int deleteRow)
        {
            //Dictionary that holds available colors
            Dictionary<string, Color> colors = new Dictionary<string, Color>()
            {
                {"R", Color.Red},{"G", Color.Green},{"B", Color.Blue},{"Y", Color.Yellow},{"P", Color.Purple},{"C", Color.Cyan},{"T", Color.Teal}
            };
            //Iterate through the rows
            for (int y = 0; y <= 14; y++)
            {
                //Iterator through the columns
                for (int x = 0; x <= 9; x++)
                {
                    //If the cell is empty, set the color to Dark Gray(the default color of grid)
                    if (string.IsNullOrEmpty(grid[y][x]))
                    {
                        this.Rows[y].Cells[x].Style.BackColor = Color.DarkGray;
                    }
                    else
                    {   //Else, set the color of the cell to be the color of the shape
                        if (!delete || (delete && !(deleteRow == y)))
                        {
                            this.Rows[y].Cells[x].Style.BackColor = colors[grid[y][x]];
                        }
                    }
                }
            }
        }
    }

    //Main Form Logic
    public partial class Form1 : Form
    {
        //Counter variables for score,lines, and level
        private int score = 0;
        private int lineCount = 0;
        private int level = 0;

        //Timers
        public static System.Timers.Timer everySecond;
        public static Stopwatch theTime;

        public Form1()
        {
            InitializeComponent();
            timer.Text = "0:00";

            //Initialize timer for how long user as played
            theTime = new Stopwatch();
            everySecond = new System.Timers.Timer(1000);
            everySecond.Elapsed += IncrementTime;
            everySecond.AutoReset = true;

            //Add event handlers
            this.Shown += Form1_Shown;
            this.Paint += Form1_Paint;
            this.Button1.Click += Button1_Click; //New Game
            this.Button2.Click += Button2_Click; //How to play
            this.Button3.Click += Button3_Click; //Pause/Resume
            this.game.IncrementScore += game_IncrementScore;
            this.game.IncrementLines += game_IncrementLines;
            this.game.LevelUp += game_LevelUp;
            this.game.ShapeChanged += game_ShapeChanged;
            this.game.KeyDown += keyEventHandler;
        }

        //Event handler when the user presses the arrow keys or the WASD keys
        private void keyEventHandler(object sender, KeyEventArgs e)
        {
            //If user presses arrow keys, supress them so it won't focus cells
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
            //Else if user presses WASD
            if (e.KeyCode == Keys.A)
            {
                game.moveLeft();
            }
            if (e.KeyCode == Keys.D)
            {
                game.moveRight();
            }
            if (e.KeyCode == Keys.S)
            {
                game.moveDown();
            }
            if (e.KeyCode == Keys.W)
            {
                game.rotateShape();
            }
        }

        //Increments the timer so the user can see how long they've been playing
        public void IncrementTime(object sender, ElapsedEventArgs e)
        {
            timer.Text = String.Format("{0:#0}:{1:00}", theTime.Elapsed.Minutes, theTime.Elapsed.Seconds);
        }

        //Creates the grid that the user will play on and see block previews
        private void Form1_Load(object sender, EventArgs e)
        {
            game.CurrentCell = null;
            //Create 10 columns in the grid, the classic number of columns in Tetris
            for (int x = 1; x <= 10; x++)
            {
                game.Columns.Add(new DataGridViewTextBoxColumn());
                game.Columns[x - 1].Width = 30; //Width of 30 pixels

                //Create 6 columns for the block preview
                if (x < 7)
                {
                    shapePreview.Columns.Add(new DataGridViewTextBoxColumn());
                    shapePreview.Columns[x - 1].Width = 30; //Width of 30 pixels
                }
            }
            //Create 6 rows for the block preview
            shapePreview.Rows.Add(6);
            //Create 15 rows for the grid
            game.Rows.Add(15);

            //Iterate 15 times(since 15 rows)
            for (int x = 1; x <= 15; x++)
            {
                //Set the height of rows to be 30 pixels
                game.Rows[x - 1].Height = 30;

                //Set height of all block preview rows to also be 30 pixels
                if (x < 7)
                {
                    shapePreview.Rows[x - 1].Height = 30;
                }
            }
        }
        
        //Removes the initial selected cell when you start the game
        private void Form1_Shown(object sender, EventArgs e)
        {
            shapePreview.CurrentCell = null;
            game.CurrentCell = null;
            game.ClearSelection();
        }
        
        //Draws the outline of the grid that the user will play the game on
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] points = { game.Location, new Point(game.Left, game.Bottom), new Point(game.Right, game.Bottom), new Point(game.Right, game.Top) };
            Pen outline = new Pen(Color.Black, 2);
            e.Graphics.DrawLines(outline, points);
            int[] cellLines = { 1, 2, 9, 10, 13, 14 };
        }

        //When user clicks on "New game". Starts a new game!
        private void Button1_Click(object sender, EventArgs e)
        {
            //Resets score and time
            score = 0;
            theTime.Reset();
            timer.Text = "0:00";
            scoreLabel.Text = score.ToString("000000");
            lines.Text = "0";

            //Restarts the timer, starts a new game, and enables pause button
            theTime.Start();
            everySecond.Enabled = true;
            game.newGame();
            Button3.Enabled = true;
        }

        //When user clicks on "How To Play", teaches user how to play
        private void Button2_Click(object sender, EventArgs e)
        {
            string message = "The rules are simple! I mean it is a classic game..." + "There are 5 levels!\n\n" +
                "Level 1 - 1 second interval, 200 points per row\n" + 
                "Level 2 - .75 second interval, 400 points per row\n" + 
                "Level 3 - .50 second interval, 800 points per row\n" + 
                "Level 4 - .40 second interval, 1,600 points per row\n" + 
                "Level 5 - .25 second interval, 3,200 points per row";
            string caption = "How to Play";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        //When user clicks on "Pause/Resume"
        private void Button3_Click(object sender, EventArgs e)
        {
            if(Button3.Text == "Pause")
            {
                Button3.Text = "Resume";
                theTime.Stop(); //Pauses the timer
                game.pauseGame(); //Pause the game
                return;
            }
            if(Button3.Text == "Resume")
            {
                Button3.Text = "Pause";
                theTime.Start(); //Resumes the timer
                game.resumeGame(); //Resume the game
                game.Focus(); //Sets focus back to the game, so user doesn't have to click on it
                game.ClearSelection(); //A black cell appears when you re-focus, so this clears that cell
                return;
            }
        }

        //When user scores points, update the scores label
        private void game_IncrementScore(int newPoints)
        {
            score += newPoints;
            scoreLabel.Text = score.ToString("000000");
        }

        //When the user clears a row, update the lines label
        private void game_IncrementLines(int newLines)
        {
            lineCount = newLines;
            lines.Text = lineCount.ToString();
        }

        //When the user levels up
        private void game_LevelUp(int newLevel)
        {
            level = newLevel;
        }

        //When the current block is placed, update the preview to show the next block
        private void game_ShapeChanged(Point[] shapePoints, string shapeColor)
        {
            Point[] pts = (Point[])shapePoints.Clone();

            for (int y = 0; y <= 4; y++)
            {
                for (int x = 0; x <= 4; x++)
                {
                    shapePreview.Rows[y].Cells[x].Style.BackColor = Color.DarkGray;
                }
            }
            int minX = pts.Min((p) => p.X);
            int minY = pts.Min((p) => p.Y);
            for (int x = 0; x <= pts.GetUpperBound(0); x++)
            {
                pts[x].Offset(-minX, -minY);
            }
            int w = pts.Max((p) => p.X) - pts.Min((p) => p.X);
            int h = pts.Max((p) => p.Y) - pts.Min((p) => p.Y);
            int offSetX = Convert.ToInt32(Math.Floor((4 - w) / 2.0));
            int offSetY = Convert.ToInt32(Math.Floor((4 - h) / 2.0));
            
            //Dictionary of colors
            Dictionary<string, Color> colors = new Dictionary<string, Color>()
            {
                {"R", Color.Red},{"G", Color.Green},{"B", Color.Blue},{"Y", Color.Yellow},{"P", Color.Purple},{"C", Color.Cyan},{"T", Color.Teal}
            };

            for (int x = 0; x <= pts.GetUpperBound(0); x++)
            {
                pts[x].Offset(offSetX, offSetY);
                shapePreview.Rows[pts[x].Y].Cells[pts[x].X].Style.BackColor = colors[shapeColor];
            }
            game.Focus(); //Sets focus to the game
            game.CurrentCell = null; //Clears selected cell (Prevents a black cell from appearing)
        }
    }
}
