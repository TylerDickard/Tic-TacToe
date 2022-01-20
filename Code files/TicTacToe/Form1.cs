//
//Author: Tyler Dickard
//Description: This file initializes the form and starts the game.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //
        // Initializing the game object
        //
        public Game g;
        //
        //Function Name: Form1()
        //Description: Default Constructor for the form, it initializes the form and starts the game object.
        //Parameters: NA
        //Returns: NA
        //
        public Form1()
        {
            InitializeComponent();
            g = new Game();
        }
        //
        //Function Name: mnuExit_Click()
        //Description: Closes the form
        //Parameters: object sender and EventArgs e
        //Returns: NA
        //
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //
        //Function Name: mnuReset_Click()
        //Description: Resets the form
        //Parameters: object sender and EventArgs e
        //Returns: NA
        //
        private void mnuReset_Click(object sender, EventArgs e)
        {
            lblResult.Left = 120;
            lblResult.Text = g.NewGame();
            Invalidate();
        }
        //
        //Function Name: Form1_Paint()
        //Description: This function draws the grid for the game
        //Parameters: object sender and PaintEventArgs pe
        //Returns: NA
        //
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            Pen e = new Pen(Color.Black, 2);
            //Horizontal Line 1
            g.DrawLine(e, 65, 125, 215, 125);
            //Horizontal Line 2
            g.DrawLine(e, 65, 175, 215, 175);
            //Vertical Line 1
            g.DrawLine(e, 115, 75, 115, 225);
            //Vertical Line 2
            g.DrawLine(e, 165, 75, 165, 225);
            //dispose of objects
            e.Dispose();
            g.Dispose();
        }
        //
        //Function Name: Form1_Load()
        //Description: This function sets the label to O's Turn and creats the graphics object
        //Parameters: object sender and EventArgs e
        //Returns: NA
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            lblResult.Text = "O's Turn";
            Shape.g = this.CreateGraphics();
        }
        //
        //Function Name: Form1_MouseClick()
        //Description: Whenever the left mouse button is pressed it will create a object where the user clicked, either an X or O
        //Parameters: object sender and MouseEventArgs me
        //Returns: NA
        //
        private void Form1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs me)
        {
            if (me.Button != MouseButtons.Right)
            {
                if (me.X > 65 && me.X < 215 && me.Y > 74 && me.Y < 226)
                {
                    if (lblResult.Left == 50)
                    {
                        lblResult.Left = 120;
                    }
                    lblResult.Text = g.NextMove(me.X, me.Y);
                    if (lblResult.Text == "Square Taken, Choose Another")
                    {
                        lblResult.Left = 50;
                    }
                }
            }
        }
    }
}
