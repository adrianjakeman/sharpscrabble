﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scrabble.UI
{
    /// <summary>
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public Tile()
        {
            InitializeComponent();

        }

        public Tile(string letter, int score) : this()
        {
            Letter = letter;
            Score = score;
            Redraw();
        }

        public void Redraw()
        {
            DisplayLetter.Text = Letter;
            DisplayScore.Text = Score.ToString();
        }

        //drag/drop code
        private Point ddMouseStart;
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            ddMouseStart = e.GetPosition(null);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Get the current position
            Point mousePos = e.GetPosition(null);
            Vector diff = ddMouseStart - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                DataObject thisTileData = new DataObject("scTile", this);
                DragDrop.DoDragDrop(this, thisTileData, DragDropEffects.Move);
            }
        }


        public string Letter { get; set; }
        public int Score { get; set; }
    }
}
