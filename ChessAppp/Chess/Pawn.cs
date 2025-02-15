﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class Pawn : Figure
    { public bool usedAlreadyItsFirstRight { get; set; } = false;
        public bool isSelected { get; set; }= false;
        public Pawn(string name,Image bgImg) : base(name,bgImg)
        {
            
        }

        public override void CapturedByOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void CaptureOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void Move(Check button)
        {
            usedAlreadyItsFirstRight = true;
            (this.Parent as Check).isFull = false;
            button.Controls.Clear();
            
            button.Controls.Add(this);
            button.isFull = true;





        }


        public override List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons)
        {
            List<Coordinate> availableCoordinates = new();
            int limit = 0;
            if (usedAlreadyItsFirstRight)
            {
                limit = 1;

            }
            else
            {
                limit = 2;
            }
            if(this.Team == Team.Black)
            {
                if (row == 7)
                {
                    limit = 0;
                }
                //Normal gediş
                for (int i = row + 1; i <= row + limit; i++)
                {
                    if (buttons[i, column].isFull == false)
                    {
                        availableCoordinates.Add(new(i, column));
                    }
                }  
                   
                //Rəqibin daşını yemək üçün 
                
                for(int i = row + 1; i <= row + 1; i++)
                {

                    int colLimit = column < 6 ? column + 1 : column;
                    for (int j = column > 0 ? column - 1 : column + 1; j <= colLimit; j += 2)
                    {


                        if (buttons[i, j].isFull)
                        {
                            Figure figure = (Figure)buttons[i, j].Controls[0];
                            if (figure.Team != this.Team)
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                        }

                    }
                }



                }
            
            else
            {
                if (row == 0)
                {
                    limit = 0;
                }
                for(int i = row - 1; i >= row - limit; i--)
                {
                    if (buttons[i, column].isFull == false)
                    {
                        availableCoordinates.Add(new(i, column));
                    }
                }
            }
            
            return availableCoordinates;
        }
    }
}
