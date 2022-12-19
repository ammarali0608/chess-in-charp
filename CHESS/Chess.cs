using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESS
{
    public partial class Chess : Form
    {
         
        Image wR1 = Properties.Resources.wR;
        Image wR2 = Properties.Resources.wR;

        Image wK = Properties.Resources.wK;
        Image wQ = Properties.Resources.wQ;
        Image wB = Properties.Resources.wB;
        Image wP1 = Properties.Resources.wP;
        Image wP2 = Properties.Resources.wP;
        Image wP3 = Properties.Resources.wP;
        Image wP4 = Properties.Resources.wP;
        Image wP5 = Properties.Resources.wP;
        Image wP6 = Properties.Resources.wP;
        Image wP7 = Properties.Resources.wP;
        Image wP8 = Properties.Resources.wP;



        Image wN = Properties.Resources.wN;
        Image bR1 = Properties.Resources.bR;
        Image bR2 = Properties.Resources.bR;

        Image bQ = Properties.Resources.bQ;
        Image bK = Properties.Resources.bK;
        Image bN = Properties.Resources.bN;
        Image bB = Properties.Resources.bB;
        Image bP1 = Properties.Resources.bP;
        Image bP2 = Properties.Resources.bP;
        Image bP3 = Properties.Resources.bP;
        Image bP4 = Properties.Resources.bP;
        Image bP5 = Properties.Resources.bP;
        Image bP6 = Properties.Resources.bP;
        Image bP7 = Properties.Resources.bP;
        Image bP8 = Properties.Resources.bP;


        //Lists for both pieces
        List<Image> whitePieces = new List<Image>();
        List<Image> blackPieces = new List<Image>();
        List<Image> whitePawns = new List<Image>();
        List<Image> blackPawns = new List<Image>();


        //King Location of both
        Button white_king;
        Button black_king;

        // Button both of attacker and defender
        Button attacker = new Button();
        Button defender = new Button();
        Button none = new Button();

        // Boolean move checker true for white and false for black
        bool move = true;

        //Catles triggers;
        bool isWR1Moved = false;
        bool isWR2Moved = false;
        bool isBR1Moved = false;
        bool isBR2Moved = false;
        bool isWKingMoved = false;
        bool isBKingMoved = false;



        // selection checker if any piece is selected for move
        bool attacker_selected = false;
        bool defender_selected = false;

        

        //Box of buttons
        Button[,] box = new Button[8, 8];

        //Valid Moves Array
        //Button[] valid_moves;
        List<Button> valid_moves = new List<Button>();
        List<Button> valid_defenders = new List<Button>();
        //count for valid moves
        bool isW = false;
        bool isB = false;
        List<Button[,]> BlackPlayedMoves = new List<Button[,]>();
        List<Button[,]> WhitePlayedMoves = new List<Button[,]>();



        public Chess()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //White Pieces Set First Row

            this.a70.Image = wR1;
            this.b71.Image = wN;
            this.c72.Image = wB;
            this.d73.Image = wQ;
            this.f75.Image = wB;
            this.g76.Image = wN;
            this.h77.Image = wR2;

            this.e74.Image = wK;



            //White Pieces Set Pawns
            this.a60.Image = wP1;
            this.b61.Image = wP2;
            this.c62.Image = wP3;
            this.d63.Image = wP4;
            this.e64.Image = wP5;
            this.f65.Image = wP6;
            this.g66.Image = wP7;
            this.h67.Image = wP8;


            //Black Pieces Set First Row
            this.a00.Image = bR1;
            this.b01.Image = bN;
            this.c02.Image = bB;
            this.d03.Image = bQ;
            this.f05.Image = bB;
            this.g06.Image = bN;
            this.h07.Image = bR2;

            this.e04.Image = bK;


            //Black Pieces Set Pawns
            this.a10.Image = bP1;
            this.b11.Image = bP2;
            this.c12.Image = bP3;
            this.d13.Image = bP4;
            this.e14.Image = bP5;
            this.f15.Image = bP6;
            this.g16.Image = bP7;
            this.h17.Image = bP8;

            this.bPQ.Image = bQ;
            this.bPR.Image = bR1;
            this.bPN.Image = bN;
            this.bPB.Image = bB;

            this.wPQ.Image = wQ;
            this.wPR.Image = wR1;
            this.wPN.Image = wN;
            this.wPB.Image = wB;


            this.bP.Visible = false;
            this.wP.Visible = false;






            //Imaged Added to recpective list
            this.blackPieces.Add(bP1);
            this.blackPieces.Add(bP2);
            this.blackPieces.Add(bP3);
            this.blackPieces.Add(bP4);
            this.blackPieces.Add(bP5);
            this.blackPieces.Add(bP6);
            this.blackPieces.Add(bP7);
            this.blackPieces.Add(bP8);

            this.blackPieces.Add(bR1);
            this.blackPieces.Add(bR2);

            this.blackPieces.Add(bK);
            this.blackPieces.Add(bQ);
            this.blackPieces.Add(bB);
            this.blackPieces.Add(bN);

            this.whitePieces.Add(wP1);
            this.whitePieces.Add(wP2);
            this.whitePieces.Add(wP3);
            this.whitePieces.Add(wP4);
            this.whitePieces.Add(wP5);
            this.whitePieces.Add(wP6);
            this.whitePieces.Add(wP7);
            this.whitePieces.Add(wP8);

            this.whitePieces.Add(wQ);
            this.whitePieces.Add(wK);
            this.whitePieces.Add(wB);
            this.whitePieces.Add(wN);
            this.whitePieces.Add(wR1);
            this.whitePieces.Add(wR2);


            //Kings Initial Positions
            white_king = e74;
            black_king = e04;

            //Pawns Add in list

            this.blackPawns.Add(bP1);
            this.blackPawns.Add(bP2);
            this.blackPawns.Add(bP3);
            this.blackPawns.Add(bP4);
            this.blackPawns.Add(bP5);
            this.blackPawns.Add(bP6);
            this.blackPawns.Add(bP7);
            this.blackPawns.Add(bP8);


            this.whitePawns.Add(wP1);
            this.whitePawns.Add(wP2);
            this.whitePawns.Add(wP3);
            this.whitePawns.Add(wP4);
            this.whitePawns.Add(wP5);
            this.whitePawns.Add(wP6);
            this.whitePawns.Add(wP7);
            this.whitePawns.Add(wP8);

            //Box Set 
            this.box[0, 0] = a00;
            this.box[0, 1] = b01;
            this.box[0, 2] = c02;
            this.box[0, 3] = d03;
            this.box[0, 4] = e04;
            this.box[0, 5] = f05;
            this.box[0, 6] = g06;
            this.box[0, 7] = h07;

            this.box[1, 0] = a10;
            this.box[1, 1] = b11;
            this.box[1, 2] = c12;
            this.box[1, 3] = d13;
            this.box[1, 4] = e14;
            this.box[1, 5] = f15;
            this.box[1, 6] = g16;
            this.box[1, 7] = h17;

            this.box[2, 0] = a20;
            this.box[2, 1] = b21;
            this.box[2, 2] = c22;
            this.box[2, 3] = d23;
            this.box[2, 4] = e24;
            this.box[2, 5] = f25;
            this.box[2, 6] = g26;
            this.box[2, 7] = h27;

            this.box[3, 0] = a30;
            this.box[3, 1] = b31;
            this.box[3, 2] = c32;
            this.box[3, 3] = d33;
            this.box[3, 4] = e34;
            this.box[3, 5] = f35;
            this.box[3, 6] = g36;
            this.box[3, 7] = h37;

            this.box[4, 0] = a40;
            this.box[4, 1] = b41;
            this.box[4, 2] = c42;
            this.box[4, 3] = d43;
            this.box[4, 4] = e44;
            this.box[4, 5] = f45;
            this.box[4, 6] = g46;
            this.box[4, 7] = h47;

            this.box[5, 0] = a50;
            this.box[5, 1] = b51;
            this.box[5, 2] = c52;
            this.box[5, 3] = d53;
            this.box[5, 4] = e54;
            this.box[5, 5] = f55;
            this.box[5, 6] = g56;
            this.box[5, 7] = h57;


            this.box[6, 0] = a60;
            this.box[6, 1] = b61;
            this.box[6, 2] = c62;
            this.box[6, 3] = d63;
            this.box[6, 4] = e64;
            this.box[6, 5] = f65;
            this.box[6, 6] = g66;
            this.box[6, 7] = h67;


            this.box[7, 0] = a70;
            this.box[7, 1] = b71;
            this.box[7, 2] = c72;
            this.box[7, 3] = d73;
            this.box[7, 4] = e74;
            this.box[7, 5] = f75;
            this.box[7, 6] = g76;
            this.box[7, 7] = h77;






        }

        private void box_selected(object sender, EventArgs e)
        {
            Button button = sender as Button;
            
            if (bP.Visible == true || wP.Visible == true)
            {
                PawnPromotion(button);
                return;
            }



            if (!attacker_selected && move)
            {
                SelectAttackerAsWhite(button);

            }
            else if (!defender_selected && move)
            {

                SelectDefenderAsBlack(button);



            }
            else if (!attacker_selected && !move)
            {
                SelectAttackerAsBlack(button);

            }
            else if (!defender_selected && !move)
            {

                SelectDefenderAsWhite(button);

            }








            if (attacker_selected && defender_selected) {

                moveValidator();

                if (castle())
                {
                    attacker.Enabled = true;
                    AddMoves();

                    return;
                }

                if (!valid_moves.Contains(defender) || PreCheck())
                {
                    attacker_selected = false;
                    defender_selected = false;
                    invertMove();
                    attacker.Enabled = true;

                    attacker = none;
                    defender = none;
                }


                else if (valid_moves.Contains(defender))
                {
                    isW = isAttackerWhite();
                    isB = isAttackerBLack();
                    if (isAttackerBLack() && IsAttackerKing())
                    {
                        black_king = defender;
                        isBKingMoved = true;
                    }
                    else if (isAttackerWhite() && IsAttackerKing())
                    {
                        white_king = defender;
                        isWKingMoved = true;

                    }



                    if (attacker.Image == bR1)
                    {
                        isBR1Moved = true;
                    }
                    else if (attacker.Image == bR2)
                    {
                        isBR2Moved = true;
                    }
                    else if (attacker.Image == wR1)
                    {
                        isWR1Moved = true;
                    }
                    else if (attacker.Image == wR2)
                    {
                        isWR2Moved = true;
                    }





                    defender.Image = attacker.Image;
                    attacker.Image = null;
                     AddMoves();

                    if (blackPawns.Contains(defender.Image) && defender.Name[1] - 48 == 7)
                    {
                        bP.Visible = true;
                        foreach(Button b in box)
                        {
                            b.Enabled = false;
                        }
                        return;
                    }
                    else if(whitePawns.Contains(defender.Image) && defender.Name[1] - 48 == 0)
                    {

                        wP.Visible =true;
                        foreach (Button b in box)
                        {
                            b.Enabled = false;
                        }
                        return;
                    }

                    if (isB && isCheckOnWhite())
                    {

                        if (isWhiteCheckmate())
                        {
                            MessageBox.Show("Black Won By CheckMate");
                            resetBox();

                        }

                    }
                    if (isW && isCheckOnBlack())
                    {

                        if (isBlackCheckmate())
                        {
                            MessageBox.Show("White Won By CheckMate");
                            resetBox();

                        }

                    }
                    if(isW && isBlackStalemate())
                    {
                        MessageBox.Show("Drawn By Stalemate");
                        resetBox();
                    }
                    if (isB && isWhiteStalemate())
                    {
                        MessageBox.Show("Drawn By Stalemate");
                        resetBox();
                    }
                    if (isDrawn())
                    {
                        MessageBox.Show("Drawn By insufficient pieces");
                        resetBox();
                    }




                }
                

                attacker.Enabled = true;

                defender.Enabled = true;

                attacker_selected = false;
                defender_selected = false;
                invertMove();
                

                

            }




        }
        private bool SelectAttackerAsWhite(Button b)
        {
            if (b.Image == null)
            {

                return false;
            }
            if (whitePieces.Contains(b.Image))
            {

                attacker.Enabled = true;

                attacker = b;
                attacker.Enabled = false;

                attacker_selected = true;
                return true;

            }


            return false;
        }
        private bool SelectAttackerAsBlack(Button b)
        {
            if (b.Image == null)
            {

                return false;
            }
            if (blackPieces.Contains(b.Image))
            {

                attacker.Enabled = true;

                attacker = b;
                attacker.Enabled = false;

                attacker_selected = true;
                return true;

            }


            return false;
        }
        private bool SelectDefenderAsBlack(Button b)
        {

            if (blackPieces.Contains(b.Image) || b.Image == null)
            {
                defender = b;
                defender_selected = true;
                return true;

            }
            else if (((whitePieces.Contains(b.Image) && b.Image == wR1) || b == c72) && IsAttackerKing() && !isWKingMoved && !isWR1Moved && b71.Image == null && c72.Image == null && d73.Image == null)
            {

                SelectDefenderAsWhite(b);
                return false;

            }
            else if (((whitePieces.Contains(b.Image) && (b.Image == wR2)) || b == g76) && IsAttackerKing() && !isWKingMoved && !isWR2Moved && f75.Image == null && g76.Image == null)
            {

                SelectDefenderAsWhite(b);
                return false;

            }

            else if (whitePieces.Contains(b.Image))
            {

                SelectAttackerAsWhite(b);
                return false;

            }

            return false;
        }

        private bool SelectDefenderAsWhite(Button b)
        {

            if (whitePieces.Contains(b.Image) || b.Image == null)
            {
                defender = b;
                defender_selected = true;
                return true;

            }
            else if (((blackPieces.Contains(b.Image) && (b.Image == bR1)) || b == c02) && IsAttackerKing() && !isBKingMoved && !isBR1Moved && b01.Image == null && c02.Image == null && d03.Image == null)
            {

                SelectDefenderAsBlack(b);
                return false;

            }
            else if (((blackPieces.Contains(b.Image) && (b.Image == bR2)) || b == g06) && IsAttackerKing() && !isBKingMoved && !isBR2Moved && f05.Image == null && g06.Image == null)
            {
                SelectDefenderAsBlack(b);
                return false;

            }
            else if (blackPieces.Contains(b.Image))
            {
                SelectAttackerAsBlack(b);
                return false;

            }

            return false;
        }
        private void moveValidator()
        {
            if (whitePawns.Contains(attacker.Image) || blackPawns.Contains(attacker.Image))
            {

                PawnValidMoves();
            }
            else if (attacker.Image == wQ || attacker.Image == bQ)
            {
                QueenValidMoves();
            }
            else if (attacker.Image == wR1 || attacker.Image == bR1 || attacker.Image == wR2 || attacker.Image == bR2)
            {
                RookValidMoves();
            }
            else if (attacker.Image == wB || attacker.Image == bB)
            {
                BishopValidMoves();
            }
            else if (attacker.Image == wK || attacker.Image == bK)
            {
                KingValidMoves();
            }
            else if (attacker.Image == wN || attacker.Image == bN)
            {
                KnightValidMoves();
            }

        }
        private void QueenValidMoves()
        {
            valid_moves.Clear();
            int row = attacker.Name[1] - 48;
            int col = attacker.Name[2] - 48;
            //Same Column
            for (int i = row + 1; i < 8; i++)
            {


                if (box[i, col].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;

                    }

                    break;



                }

                valid_moves.Add(box[i, col]);


            }
            for (int i = row - 1; i >= 0; i--)
            {


                if (box[i, col].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;


                    }
                    else if (isAttackerWhite() && isBlack(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;

                    }

                    break;

                }

                valid_moves.Add(box[i, col]);


            }
            //Same Row
            for (int i = col + 1; i < 8; i++)
            {
                if (box[row, i].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;


                    }
                    else if (isAttackerWhite() && isBlack(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;

                    }
                    break;


                }
                valid_moves.Add(box[row, i]);

            }
            for (int i = col - 1; i >= 0; i--)
            {
                if (box[row, i].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;

                    }
                    break;

                }

                valid_moves.Add(box[row, i]);

            }
            //Upper Left Diagonal


            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    break;


                }

                valid_moves.Add(box[i, j]);
                j--;

            }

            //Upper Right Diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    break;


                }

                valid_moves.Add(box[i, j]);
                j++;

            }

            //Lower Left Diagonal


            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    break;



                }

                valid_moves.Add(box[i, j]);
                j--;

            }

            //Lower Right Diagonal
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    break;



                }

                valid_moves.Add(box[i, j]);
                j++;

            }







        }
        private void BishopValidMoves()
        {
            valid_moves.Clear();
            int row = attacker.Name[1] - 48;
            int col = attacker.Name[2] - 48;
            //Upper Left Diagonal


            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[i, j]);
                j--;

            }

            //Upper Right Diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[i, j]);
                j++;

            }

            //Lower Left Diagonal


            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[i, j]);
                j--;

            }

            //Lower Right Diagonal
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++)
            {
                if (box[i, j].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, j].Image))
                    {
                        valid_moves.Add(box[i, j]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[i, j]);
                j++;

            }

        }
        private void RookValidMoves()
        {
            valid_moves.Clear();
            int row = attacker.Name[1] - 48;
            int col = attacker.Name[2] - 48;

            //Same Column
            for (int i = row + 1; i < 8; i++)
            {
                if (box[i, col].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[i, col]);


            }
            for (int i = row - 1; i >= 0; i--)
            {
                if (box[i, col].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;


                    }
                    else if (isAttackerWhite() && isBlack(box[i, col].Image))
                    {
                        valid_moves.Add(box[i, col]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[i, col]);


            }
            //Same Row
            for (int i = col + 1; i < 8; i++)
            {
                if (box[row, i].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;


                    }
                    else if (isAttackerWhite() && isBlack(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;

                    }
                    else
                        break;

                }
                valid_moves.Add(box[row, i]);

            }
            for (int i = col - 1; i >= 0; i--)
            {
                if (box[row, i].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;

                    }
                    else if (isAttackerWhite() && isBlack(box[row, i].Image))
                    {
                        valid_moves.Add(box[row, i]);
                        break;

                    }
                    else
                        break;

                }

                valid_moves.Add(box[row, i]);

            }
        }

        private void KingValidMoves()
        {
            valid_moves.Clear();
            int row = attacker.Name[1] - 48;
            int col = attacker.Name[2] - 48;
            if (isAttackerBLack())
            {
                if (row + 1 < 8)
                {


                    if (isWhite(box[row + 1, col].Image) || box[row + 1, col].Image == null)
                    {
                        valid_moves.Add(box[row + 1, col]);
                    }

                }


                if (row - 1 >= 0)
                {
                    if (isWhite(box[row - 1, col].Image) || box[row - 1, col].Image == null)

                    {
                        valid_moves.Add(box[row - 1, col]);
                    }
                }
                if (col - 1 >= 0)
                {
                    if (isWhite(box[row, col - 1].Image) || box[row, col - 1].Image == null)

                    {
                        valid_moves.Add(box[row, col - 1]);
                    }

                }
                if (col + 1 < 8)
                {
                    if (isWhite(box[row, col + 1].Image) || box[row, col + 1].Image == null)

                    {
                        valid_moves.Add(box[row, col + 1]);
                    }

                }
                //////////////////////////////

                if (row + 1 < 8 && col + 1 < 8)
                {
                    if (isWhite(box[row + 1, col + 1].Image) || box[row + 1, col + 1].Image == null)

                    {
                        valid_moves.Add(box[row + 1, col + 1]);
                    }

                }




                if (row + 1 < 8 && col - 1 >= 0)
                {
                    if (isWhite(box[row + 1, col - 1].Image) || box[row + 1, col - 1].Image == null)

                    {
                        valid_moves.Add(box[row + 1, col - 1]);
                    }
                }

                if (row - 1 >= 0 && col + 1 < 8)
                {
                    if (isWhite(box[row - 1, col + 1].Image) || box[row - 1, col + 1].Image == null)

                    {
                        valid_moves.Add(box[row - 1, col + 1]);
                    }

                }

                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    if (isWhite(box[row - 1, col - 1].Image) || box[row - 1, col - 1].Image == null)

                    {
                        valid_moves.Add(box[row - 1, col - 1]);
                    }

                }

            }

            else if (isAttackerWhite())
            {
                if (row + 1 < 8)
                {
                    if (isBlack(box[row + 1, col].Image) || box[row + 1, col].Image == null)

                    {
                        valid_moves.Add(box[row + 1, col]);
                    }
                }


                if (row - 1 >= 0)
                {
                    if (isBlack(box[row - 1, col].Image) || box[row - 1, col].Image == null)

                    {
                        valid_moves.Add(box[row - 1, col]);
                    }

                }
                if (col - 1 >= 0)
                {
                    if (isBlack(box[row, col - 1].Image) || box[row, col - 1].Image == null)


                    {
                        valid_moves.Add(box[row, col - 1]);
                    }

                }
                if (col + 1 < 8)
                {
                    if (isBlack(box[row, col + 1].Image) || box[row, col + 1].Image == null)

                    {
                        valid_moves.Add(box[row, col + 1]);
                    }

                }
                //////////////////////////////

                if (row + 1 < 8 && col + 1 < 8)
                {
                    if (isBlack(box[row + 1, col + 1].Image) || box[row + 1, col + 1].Image == null)

                    {
                        valid_moves.Add(box[row + 1, col + 1]);
                    }

                }




                if (row + 1 < 8 && col - 1 >= 0)
                {
                    if (isBlack(box[row + 1, col - 1].Image) || box[row + 1, col - 1].Image == null)

                    {
                        valid_moves.Add(box[row + 1, col - 1]);
                    }
                }

                if (row - 1 >= 0 && col + 1 < 8)
                {
                    if (isBlack(box[row - 1, col + 1].Image) || box[row - 1, col + 1].Image == null)

                    {
                        valid_moves.Add(box[row - 1, col + 1]);
                    }

                }

                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    if (isBlack(box[row - 1, col - 1].Image) || box[row - 1, col - 1].Image == null)

                    {
                        valid_moves.Add(box[row - 1, col - 1]);
                    }

                }

            }


        }
        private void PawnValidMoves()
        {

            valid_moves.Clear();
            int row = attacker.Name[1] - 48;
            int col = attacker.Name[2] - 48;



            if (isAttackerBLack())
            {
                if (row == 1)
                {
                    if (row + 2 < 8 && box[row + 2, col].Image == null)
                    {
                        valid_moves.Add(box[row + 2, col]);
                    }
                }
                if (row + 1 < 8 && box[row + 1, col].Image == null)
                {
                    valid_moves.Add(box[row + 1, col]);
                }


                if (row + 1 < 8 && col + 1 < 8 && box[row + 1, col + 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row + 1, col + 1].Image))
                    {
                        valid_moves.Add(box[row + 1, col + 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row + 1, col + 1].Image))
                    {
                        valid_moves.Add(box[row + 1, col + 1]);
                    }
                }
                if (row + 1 < 8 && col - 1 >= 0 && box[row + 1, col - 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row + 1, col - 1].Image))
                    {
                        valid_moves.Add(box[row + 1, col - 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row + 1, col - 1].Image))
                    {
                        valid_moves.Add(box[row + 1, col - 1]);
                    }
                }


            }
            else if (isAttackerWhite())
            {
                if (row == 6)
                {
                    if (row - 2 >= 0 && box[row - 2, col].Image == null)

                    {

                        valid_moves.Add(box[row - 2, col]);
                    }
                }
                if (row - 1 >= 0 && box[row - 1, col].Image == null)
                {
                    valid_moves.Add(box[row - 1, col]);
                }


                if (row - 1 >= 0 && col + 1 < 8 && box[row - 1, col + 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row - 1, col + 1].Image))
                    {
                        valid_moves.Add(box[row - 1, col + 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row - 1, col + 1].Image))
                    {
                        valid_moves.Add(box[row - 1, col + 1]);
                    }
                }
                if (row - 1 >= 0 && col - 1 >= 0 && box[row - 1, col - 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row - 1, col - 1].Image))
                    {
                        valid_moves.Add(box[row - 1, col - 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row - 1, col - 1].Image))
                    {
                        valid_moves.Add(box[row - 1, col - 1]);
                    }
                }

            }

        }
        private void KnightValidMoves()
        {
            valid_moves.Clear();
            int row = attacker.Name[1] - 48;
            int col = attacker.Name[2] - 48;
            //Up Right

            if (row + 2 < 8 && col + 1 < 8)
            {
                if (box[row + 2, col + 1].Image == null)
                    valid_moves.Add(box[row + 2, col + 1]);
                else if (box[row + 2, col + 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row + 2, col + 1].Image))
                    {
                        valid_moves.Add(box[row + 2, col + 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row + 2, col + 1].Image))
                    {
                        valid_moves.Add(box[row + 2, col + 1]);
                    }
                }
            }

            if (row + 1 < 8 && col + 2 < 8)
            {
                if (box[row + 1, col + 2].Image == null)
                    valid_moves.Add(box[row + 1, col + 2]);
                else if (box[row + 1, col + 2].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row + 1, col + 2].Image))
                    {
                        valid_moves.Add(box[row + 1, col + 2]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row + 1, col + 2].Image))
                    {
                        valid_moves.Add(box[row + 1, col + 2]);
                    }
                }
            }

            //Up Left




            if (row + 1 < 8 && col - 2 >= 0)
            {
                if (box[row + 1, col - 2].Image == null)
                    valid_moves.Add(box[row + 1, col - 2]);
                else if (box[row + 1, col - 2].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row + 1, col - 2].Image))
                    {
                        valid_moves.Add(box[row + 1, col - 2]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row + 1, col - 2].Image))
                    {
                        valid_moves.Add(box[row + 1, col - 2]);
                    }
                }
            }

            if (row + 2 < 8 && col - 1 >= 0)
            {
                if (box[row + 2, col - 1].Image == null)
                    valid_moves.Add(box[row + 2, col - 1]);
                else if (box[row + 2, col - 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row + 2, col - 1].Image))
                    {
                        valid_moves.Add(box[row + 2, col - 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row + 2, col - 1].Image))
                    {
                        valid_moves.Add(box[row + 2, col - 1]);
                    }
                }
            }


            //Down Right

            if (row - 2 >= 0 && col + 1 < 8)
            {
                if (box[row - 2, col + 1].Image == null)
                    valid_moves.Add(box[row - 2, col + 1]);
                else if (box[row - 2, col + 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row - 2, col + 1].Image))
                    {
                        valid_moves.Add(box[row - 2, col + 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row - 2, col + 1].Image))
                    {
                        valid_moves.Add(box[row - 2, col + 1]);
                    }
                }
            }

            if (row - 1 >= 0 && col + 2 < 8)
            {
                if (box[row - 1, col + 2].Image == null)
                    valid_moves.Add(box[row - 1, col + 2]);
                else if (box[row - 1, col + 2].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row - 1, col + 2].Image))
                    {
                        valid_moves.Add(box[row - 1, col + 2]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row - 1, col + 2].Image))
                    {
                        valid_moves.Add(box[row - 1, col + 2]);
                    }
                }
            }

            //Down Left




            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (box[row - 2, col - 1].Image == null)
                    valid_moves.Add(box[row - 2, col - 1]);
                else if (box[row - 2, col - 1].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row - 2, col - 1].Image))
                    {
                        valid_moves.Add(box[row - 2, col - 1]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row - 2, col - 1].Image))
                    {
                        valid_moves.Add(box[row - 2, col - 1]);
                    }
                }
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (box[row - 1, col - 2].Image == null)
                    valid_moves.Add(box[row - 1, col - 2]);
                else if (box[row - 1, col - 2].Image != null)
                {
                    if (isAttackerBLack() && isWhite(box[row - 1, col - 2].Image))
                    {
                        valid_moves.Add(box[row - 1, col - 2]);
                    }
                    else if (isAttackerWhite() && isBlack(box[row - 1, col - 2].Image))
                    {
                        valid_moves.Add(box[row - 1, col - 2]);
                    }
                }
            }



        }
        private bool PreCheck()
        {

            Image a = attacker.Image;
            Image b = defender.Image;
            Button bk = black_king;
            Button wk = white_king;


            bool c = false;
            if (IsAttackerKing())
            {
                if (isAttackerBLack())
                {
                    black_king = defender;
                    black_king.Image = bK;
                    attacker.Image = null;

                    c = isCheckOnBlack();


                }
                else if (isAttackerWhite())
                {

                    white_king = defender;
                    white_king.Image = wK;
                    attacker.Image = null;

                    c = isCheckOnWhite();
                }
            }
            else if (!IsAttackerKing())
            {
                if (isAttackerBLack())
                {

                    defender.Image = attacker.Image;
                    attacker.Image = null;

                    c = isCheckOnBlack();

                }
                else if (isAttackerWhite())
                {
                    defender.Image = attacker.Image;
                    attacker.Image = null;
                    if (IsAttackerKing())
                    {

                        white_king = defender;
                    }
                    c = isCheckOnWhite();


                }
            }


            attacker.Image = a;
            defender.Image = b;
            black_king = bk;
            white_king = wk;
            return c;



        }
        private bool isCheckOnWhite()
        {
            int row = white_king.Name[1] - 48;
            int col = white_king.Name[2] - 48;

            for (int i = row + 1; i < 8; i++)
            {

                if (box[i, col].Image != null && (box[i, col].Image == bQ || box[i, col].Image == bR1 || box[i, col].Image == bR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite(box[i, col].Image)))
                {
                    break;
                }
            }
            for (int i = row - 1; i >= 0; i--)
            {
                if (box[i, col].Image != null && (box[i, col].Image == bQ || box[i, col].Image == bR1 || box[i, col].Image == bR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite(box[i, col].Image)))
                {
                    break;
                }
            }

            for (int i = col - 1; i >= 0; i--)
            {

                if (box[row, i].Image != null && (box[row, i].Image == bQ || box[row, i].Image == bR1 || box[row, i].Image == bR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite(box[row, i].Image)))
                    break;
            }

            for (int i = col + 1; i < 8; i++)
            {

                if (box[row, i].Image != null && (box[row, i].Image == bQ || box[row, i].Image == bR1 || box[row, i].Image == bR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite(box[row, i].Image)))
                    break;
            }


            //Diaogonal

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--)
            {


                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;

                j--;

            }

            //Upper Right Diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--)
            {
                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;
                j++;
            }

            //Lower Left Diagonal


            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++)
            {

                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;
                j--;
            }

            //Lower Right Diagonal
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++)
            {
                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;
                j++;

            }



            ///////////////////////////////////
            ///


            if (row + 2 < 8 && col + 1 < 8)
            {
                if (box[row + 2, col + 1].Image != null && box[row + 2, col + 1].Image == bN)
                {
                    return true;
                }
            }

            if (row + 1 < 8 && col + 2 < 8)
            {
                if (box[row + 1, col + 2].Image != null && box[row + 1, col + 2].Image == bN)
                {
                    return true;
                }
            }
            //[row+1,col+2]


            //Up Left




            if (row + 1 < 8 && col - 2 >= 0)
            {
                if (box[row + 1, col - 2].Image != null && box[row + 1, col - 2].Image == bN)
                {
                    return true;
                }
            }
            //[row+1,col-2]

            if (row + 2 < 8 && col - 1 >= 0)
            {
                if (box[row + 2, col - 1].Image != null && box[row + 2, col - 1].Image == bN)
                {
                    return true;
                }
            }
            //[row+2,col-1]

            //DobN Right

            if (row - 2 >= 0 && col + 1 < 8)
            {
                if (box[row - 2, col + 1].Image != null && box[row - 2, col + 1].Image == bN)
                {
                    return true;
                }
            }
            //[row-2,col+1]

            if (row - 1 >= 0 && col + 2 < 8)
            {
                if (box[row - 1, col + 2].Image != null && box[row - 1, col + 2].Image == bN)
                {
                    return true;
                }
            }

            //[row-1,col+2]
            //DobN Left




            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (box[row - 2, col - 1].Image != null && box[row - 2, col - 1].Image == bN)
                {
                    return true;
                }
            }

            //[row-2,col-1]

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (box[row - 1, col - 2].Image != null && box[row - 1, col - 2].Image == bN)
                {
                    return true;
                }
            }
            //[row-1,col-2]

            if (row - 1 >= 0 && col + 1 < 8)
            {
                if (box[row - 1, col + 1].Image != null && blackPawns.Contains(box[row - 1, col + 1].Image))
                {
                    return true;
                }
            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (box[row - 1, col - 1].Image != null && blackPawns.Contains(box[row - 1, col - 1].Image))
                {
                    return true;
                }
            }

            if (row + 1 < 8 && col - 1 >= 0)
            {
                if (box[row + 1, col - 1].Image != null && box[row + 1, col - 1].Image == bK)
                {
                    return true;
                }

            }
            if (row + 1 < 8 && col + 1 < 8)
            {
                if (box[row + 1, col + 1].Image != null && box[row + 1, col + 1].Image == bK)
                {
                    return true;
                }

            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (box[row - 1, col - 1].Image != null && box[row - 1, col - 1].Image == bK)
                {
                    return true;
                }

            }
            if (row - 1 >= 0 && col + 1 < 8)
            {
                if (box[row - 1, col + 1].Image != null && box[row - 1, col + 1].Image == bK)
                {
                    return true;
                }

            }
            if (row - 1 >= 0)
            {
                if (box[row - 1, col].Image != null && box[row - 1, col].Image == bK)
                {
                    return true;
                }

            }
            if (row + 1 < 8)
            {
                if (box[row + 1, col].Image != null && box[row + 1, col].Image == bK)
                {
                    return true;
                }

            }
            if (col - 1 >= 0)
            {
                if (box[row, col - 1].Image != null && box[row, col - 1].Image == bK)
                {
                    return true;
                }

            }
            if (col + 1 < 8)
            {
                if (box[row, col + 1].Image != null && box[row, col + 1].Image == bK)
                {
                    return true;
                }

            }

            return false;
        }
        private bool isCheckOnBlack()
        {

            int row = black_king.Name[1] - 48;
            int col = black_king.Name[2] - 48;

            for (int i = row + 1; i < 8; i++)
            {
                if (box[i, col].Image != null && (box[i, col].Image == wQ || box[i, col].Image == wR1 || box[i, col].Image == wR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite((box[i, col].Image))))
                    break;
            }
            for (int i = row - 1; i >= 0; i--)
            {
                if (box[i, col].Image != null && (box[i, col].Image == wQ || box[i, col].Image == wR1 || box[i, col].Image == wR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite((box[i, col].Image))))
                    break;
            }

            for (int i = col - 1; i >= 0; i--)
            {
                if (box[row, i].Image != null && (box[row, i].Image == wQ || box[row, i].Image == wR1 || box[row, i].Image == wR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite(box[row, i].Image)))
                    break;
            }

            for (int i = col + 1; i < 8; i++)
            {
                if (box[row, i].Image != null && (box[row, i].Image == wQ || box[row, i].Image == wR1 || box[row, i].Image == wR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite((box[row, i].Image))))
                    break; ;
            }


            //Diaogonal

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--)
            {


                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j--;
            }

            //Upper Right Diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--)
            {
                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j++;
            }

            //Lower Left Diagonal


            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++)
            {

                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j--;
            }

            //Lower Right Diagonal
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++)
            {
                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j++;

            }



            ///////////////////////////////////
            ///


            if (row + 2 < 8 && col + 1 < 8)
            {
                if (box[row + 2, col + 1].Image != null && box[row + 2, col + 1].Image == wN)
                {
                    return true;
                }
            }

            if (row + 1 < 8 && col + 2 < 8)
            {
                if (box[row + 1, col + 2].Image != null && box[row + 1, col + 2].Image == wN)
                {
                    return true;
                }
            }
            //[row+1,col+2]


            //Up Left




            if (row + 1 < 8 && col - 2 >= 0)
            {
                if (box[row + 1, col - 2].Image != null && box[row + 1, col - 2].Image == wN)
                {
                    return true;
                }
            }
            //[row+1,col-2]

            if (row + 2 < 8 && col - 1 >= 0)
            {
                if (box[row + 2, col - 1].Image != null && box[row + 2, col - 1].Image == wN)
                {
                    return true;
                }
            }
            //[row+2,col-1]

            //Down Right

            if (row - 2 >= 0 && col + 1 < 8)
            {
                if (box[row - 2, col + 1].Image != null && box[row - 2, col + 1].Image == wN)
                {
                    return true;
                }
            }
            //[row-2,col+1]

            if (row - 1 >= 0 && col + 2 < 8)
            {
                if (box[row - 1, col + 2].Image != null && box[row - 1, col + 2].Image == wN)
                {
                    return true;
                }
            }

            //[row-1,col+2]
            //Down Left




            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (box[row - 2, col - 1].Image != null && box[row - 2, col - 1].Image == wN)
                {
                    return true;
                }
            }

            //[row-2,col-1]

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (box[row - 1, col - 2].Image != null && box[row - 1, col - 2].Image == wN)
                {
                    return true;
                }
            }
            //[row-1,col-2]

            if (row + 1 < 8 && col + 1 < 8)
            {
                if (box[row + 1, col + 1].Image != null && whitePawns.Contains(box[row + 1, col + 1].Image))
                {
                    return true;
                }
            }
            if (row + 1 < 8 && col - 1 >= 0)
            {
                if (box[row + 1, col - 1].Image != null && whitePawns.Contains(box[row + 1, col - 1].Image))
                {
                    return true;
                }
            }

            //KIng
            if (row + 1 < 8 && col - 1 >= 0)
            {
                if (box[row + 1, col - 1].Image != null && box[row + 1, col - 1].Image == wK)
                {
                    return true;
                }

            }
            if (row + 1 < 8 && col + 1 < 8)
            {
                if (box[row + 1, col + 1].Image != null && box[row + 1, col + 1].Image == wK)
                {
                    return true;
                }

            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (box[row - 1, col - 1].Image != null && box[row - 1, col - 1].Image == wK)
                {
                    return true;
                }

            }
            if (row - 1 >= 0 && col + 1 < 8)
            {
                if (box[row - 1, col + 1].Image != null && box[row - 1, col + 1].Image == wK)
                {
                    return true;
                }

            }
            if (row - 1 >= 0)
            {
                if (box[row - 1, col].Image != null && box[row - 1, col].Image == wK)
                {
                    return true;
                }

            }
            if (row + 1 < 8)
            {
                if (box[row + 1, col].Image != null && box[row + 1, col].Image == wK)
                {
                    return true;
                }

            }
            if (col - 1 >= 0)
            {
                if (box[row, col - 1].Image != null && box[row, col - 1].Image == wK)
                {
                    return true;
                }

            }
            if (col + 1 < 8)
            {
                if (box[row, col + 1].Image != null && box[row, col + 1].Image == wK)
                {
                    return true;
                }

            }





            return false;
        }
        private bool isBlackCheckmate()
        {
            bool c = false;
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;
            Button wk = white_king;
            Button bk = black_king;
            Button a = attacker;
            Button d = defender;
            Image dI = defender.Image;
            Image aI = attacker.Image;




            attacker = black_king;
            black_king.Image = bkI;
            KingValidMoves();
            attacker = a;
            attacker.Image = aI;
            if (valid_moves.Contains(defender))
            {
                defender.Image = bkI;
                black_king = defender;

                c = isCheckOnBlack();
                if (!c)
                {
                    defender.Image = dI;
                    black_king = bk;
                    black_king.Image = bkI;
                    return false;
                }
                defender.Image = dI;
                black_king = bk;
                black_king.Image = bkI;
            }
            black_king = bk;
            black_king.Image = bkI;

            if (canBlackAttackChecker())
            {
                return false;
            }
            if (canBlackGoAnywhere())
            {
                return false;
            }
            validateDefenders();

            if (canBlackDefend())
                return false;



            return true;
        }
        private bool isWhiteCheckmate()
        {

            bool c = false;
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;
            Button wk = white_king;
            Button bk = black_king;
            Button a = attacker;
            Button d = defender;
            Image dI = defender.Image;
            Image aI = attacker.Image;




            attacker = white_king;
            white_king.Image = wkI;
            KingValidMoves();
            attacker = a;
            attacker.Image = aI;
            if (valid_moves.Contains(defender))
            {
                defender.Image = wkI;
                white_king = defender;

                c = isCheckOnWhite();
                if (!c)
                {
                    defender.Image = dI;
                    white_king = wk;
                    white_king.Image = wkI;
                    return false;
                }
                defender.Image = dI;
                white_king = wk;
                white_king.Image = wkI;
            }
            white_king = wk;
            white_king.Image = wkI;

            if (canWhiteAttackChecker())
            {
                return false;
            }

            if (canWhiteGoAnywhere())
            {

                return false;
            }
            validateDefenders();
            if (canWhiteDefend())
                return false;







            return true;

        }
        private bool canWhiteAttackChecker()
        {



            int row = defender.Name[1] - 48;
            int col = defender.Name[2] - 48;

            for (int i = row + 1; i < 8; i++)
            {
                if (box[i, col].Image != null && (box[i, col].Image == wQ || box[i, col].Image == wR1 || box[i, col].Image == wR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite((box[i, col].Image))))
                    break;
            }
            for (int i = row - 1; i >= 0; i--)
            {
                if (box[i, col].Image != null && (box[i, col].Image == wQ || box[i, col].Image == wR1 || box[i, col].Image == wR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite((box[i, col].Image))))
                    break;
            }

            for (int i = col - 1; i >= 0; i--)
            {
                if (box[row, i].Image != null && (box[row, i].Image == wQ || box[row, i].Image == wR1 || box[row, i].Image == wR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite(box[row, i].Image)))
                    break;
            }

            for (int i = col + 1; i < 8; i++)
            {
                if (box[row, i].Image != null && (box[row, i].Image == wQ || box[row, i].Image == wR1 || box[row, i].Image == wR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite((box[row, i].Image))))
                    break; ;
            }


            //Diaogonal

            for (int i = row - 1, j = col; i >= 0 && j >= 0; i--)
            {


                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j--;
            }

            //Upper Right Diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--)
            {
                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j++;
            }

            //Lower Left Diagonal


            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++)
            {

                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j--;
            }

            //Lower Right Diagonal
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++)
            {
                if (box[i, j].Image != null && (box[i, j].Image == wQ || box[i, j].Image == wB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite((box[i, j].Image))))
                    break;
                j++;

            }



            ///////////////////////////////////
            ///


            if (row + 2 < 8 && col + 1 < 8)
            {
                if (box[row + 2, col + 1].Image != null && box[row + 2, col + 1].Image == wN)
                {
                    return true;
                }
            }

            if (row + 1 < 8 && col + 2 < 8)
            {
                if (box[row + 1, col + 2].Image != null && box[row + 1, col + 2].Image == wN)
                {
                    return true;
                }
            }
            //[row+1,col+2]


            //Up Left




            if (row + 1 < 8 && col - 2 >= 0)
            {
                if (box[row + 1, col - 2].Image != null && box[row + 1, col - 2].Image == wN)
                {
                    return true;
                }
            }
            //[row+1,col-2]

            if (row + 2 < 8 && col - 1 >= 0)
            {
                if (box[row + 2, col - 1].Image != null && box[row + 2, col - 1].Image == wN)
                {
                    return true;
                }
            }
            //[row+2,col-1]

            //Down Right

            if (row - 2 >= 0 && col + 1 < 8)
            {
                if (box[row - 2, col + 1].Image != null && box[row - 2, col + 1].Image == wN)
                {
                    return true;
                }
            }
            //[row-2,col+1]

            if (row - 1 >= 0 && col + 2 < 8)
            {
                if (box[row - 1, col + 2].Image != null && box[row - 1, col + 2].Image == wN)
                {
                    return true;
                }
            }

            //[row-1,col+2]
            //Down Left




            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (box[row - 2, col - 1].Image != null && box[row - 2, col - 1].Image == wN)
                {
                    return true;
                }
            }

            //[row-2,col-1]

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (box[row - 1, col - 2].Image != null && box[row - 1, col - 2].Image == wN)
                {
                    return true;
                }
            }
            //[row-1,col-2]

            if (row + 1 < 8 && col + 1 < 8)
            {
                if (box[row + 1, col + 1].Image != null && whitePawns.Contains(box[row + 1, col + 1].Image))
                {
                    return true;
                }
            }
            if (row + 1 < 8 && col - 1 >= 0)
            {
                if (box[row + 1, col - 1].Image != null && whitePawns.Contains(box[row + 1, col - 1].Image))
                {
                    return true;
                }
            }





            return false;
        }
        private bool canBlackAttackChecker()
        {
            int row = defender.Name[1] - 48;
            int col = defender.Name[2] - 48;
            for (int i = row + 1; i < 8; i++)
            {

                if (box[i, col].Image != null && (box[i, col].Image == bQ || box[i, col].Image == bR1 || box[i, col].Image == bR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite(box[i, col].Image)))
                {
                    break;
                }
            }
            for (int i = row - 1; i >= 0; i--)
            {
                if (box[i, col].Image != null && (box[i, col].Image == bQ || box[i, col].Image == bR1 || box[i, col].Image == bR2))
                {
                    return true;
                }
                else if (box[i, col].Image != null && (isBlack(box[i, col].Image) || isWhite(box[i, col].Image)))
                {
                    break;
                }
            }

            for (int i = col - 1; i >= 0; i--)
            {

                if (box[row, i].Image != null && (box[row, i].Image == bQ || box[row, i].Image == bR1 || box[row, i].Image == bR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite(box[row, i].Image)))
                    break;
            }

            for (int i = col + 1; i < 8; i++)
            {

                if (box[row, i].Image != null && (box[row, i].Image == bQ || box[row, i].Image == bR1 || box[row, i].Image == bR2))
                {
                    return true;
                }
                else if (box[row, i].Image != null && (isBlack(box[row, i].Image) || isWhite(box[row, i].Image)))
                    break;
            }


            //Diaogonal

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--)
            {


                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;

                j--;

            }

            //Upper Right Diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--)
            {
                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;
                j++;
            }

            //Lower Left Diagonal


            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++)
            {

                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;
                j--;
            }

            //Lower Right Diagonal
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++)
            {
                if (box[i, j].Image != null && (box[i, j].Image == bQ || box[i, j].Image == bB))
                {
                    return true;
                }
                else if (box[i, j].Image != null && (isBlack(box[i, j].Image) || isWhite(box[i, j].Image)))
                    break;
                j++;

            }



            ///////////////////////////////////
            ///


            if (row + 2 < 8 && col + 1 < 8)
            {
                if (box[row + 2, col + 1].Image != null && box[row + 2, col + 1].Image == bN)
                {
                    return true;
                }
            }

            if (row + 1 < 8 && col + 2 < 8)
            {
                if (box[row + 1, col + 2].Image != null && box[row + 1, col + 2].Image == bN)
                {
                    return true;
                }
            }
            //[row+1,col+2]


            //Up Left




            if (row + 1 < 8 && col - 2 >= 0)
            {
                if (box[row + 1, col - 2].Image != null && box[row + 1, col - 2].Image == bN)
                {
                    return true;
                }
            }
            //[row+1,col-2]

            if (row + 2 < 8 && col - 1 >= 0)
            {
                if (box[row + 2, col - 1].Image != null && box[row + 2, col - 1].Image == bN)
                {
                    return true;
                }
            }
            //[row+2,col-1]

            //DobN Right

            if (row - 2 >= 0 && col + 1 < 8)
            {
                if (box[row - 2, col + 1].Image != null && box[row - 2, col + 1].Image == bN)
                {
                    return true;
                }
            }
            //[row-2,col+1]

            if (row - 1 >= 0 && col + 2 < 8)
            {
                if (box[row - 1, col + 2].Image != null && box[row - 1, col + 2].Image == bN)
                {
                    return true;
                }
            }

            //[row-1,col+2]
            //DobN Left




            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (box[row - 2, col - 1].Image != null && box[row - 2, col - 1].Image == bN)
                {
                    return true;
                }
            }

            //[row-2,col-1]

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (box[row - 1, col - 2].Image != null && box[row - 1, col - 2].Image == bN)
                {
                    return true;
                }
            }
            //[row-1,col-2]

            if (row - 1 >= 0 && col + 1 < 8)
            {
                if (box[row - 1, col + 1].Image != null && blackPawns.Contains(box[row - 1, col + 1].Image))
                {
                    return true;
                }
            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (box[row - 1, col - 1].Image != null && blackPawns.Contains(box[row - 1, col - 1].Image))
                {
                    return true;
                }
            }
            return false;


        }
        private bool canWhiteGoAnywhere()
        {
            int row = white_king.Name[1] - 48;
            int col = white_king.Name[2] - 48;
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;
            Button wk = white_king;
            Button bk = black_king;
            bool c = false;
            Image dI = defender.Image;
            if (row + 1 < 8)
            {
                Image i = box[row + 1, col].Image;
                white_king = box[row + 1, col];

                if (box[row + 1, col].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row + 1, col].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row + 1, col].Image = i;
                white_king = wk;
                white_king.Image = wkI;


            }


            if (row - 1 >= 0)
            {
                Image i = box[row - 1, col].Image;
                white_king = box[row - 1, col];

                if (box[row - 1, col].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row - 1, col].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row - 1, col].Image = i;
                white_king = wk;
                white_king.Image = wkI;
            }
            if (col - 1 >= 0)
            {
                Image i = box[row, col - 1].Image;
                white_king = box[row, col - 1];

                if (box[row, col - 1].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row, col - 1].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row, col - 1].Image = i;
                white_king = wk;
                white_king.Image = wkI;

            }
            if (col + 1 < 8)
            {
                Image i = box[row, col + 1].Image;
                white_king = box[row, col + 1];

                if (box[row, col + 1].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row, col + 1].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row, col + 1].Image = i;
                white_king = wk;
                white_king.Image = wkI;

            }
            //////////////////////////////

            if (row + 1 < 8 && col + 1 < 8)
            {
                Image i = box[row + 1, col + 1].Image;
                white_king = box[row + 1, col + 1];

                if (box[row + 1, col + 1].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row + 1, col + 1].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row + 1, col + 1].Image = i;
                white_king = wk;
                white_king.Image = wkI;

            }




            if (row + 1 < 8 && col - 1 >= 0)
            {
                Image i = box[row + 1, col - 1].Image;
                white_king = box[row + 1, col - 1];

                if (box[row + 1, col - 1].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row + 1, col - 1].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row + 1, col - 1].Image = i;
                white_king = wk;
                white_king.Image = wkI;
            }

            if (row - 1 >= 0 && col + 1 < 8)
            {
                Image i = box[row - 1, col + 1].Image;
                white_king = box[row - 1, col + 1];

                if (box[row - 1, col + 1].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row - 1, col + 1].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row - 1, col + 1].Image = i;
                white_king = wk;
                white_king.Image = wkI;

            }

            if (row - 1 >= 0 && col - 1 >= 0)
            {
                Image i = box[row - 1, col - 1].Image;
                white_king = box[row - 1, col - 1];

                if (box[row - 1, col - 1].Image == null || isBlack(i))
                {
                    white_king.Image = wkI;

                    if (!isCheckOnWhite())
                    {
                        box[row - 1, col - 1].Image = i;
                        white_king = wk;
                        white_king.Image = wkI;
                        return true;
                    }



                }
                box[row - 1, col - 1].Image = i;
                white_king = wk;
                white_king.Image = wkI;

            }


            return false;
        }
        private bool canBlackGoAnywhere()
        {
            int row = black_king.Name[1] - 48;
            int col = black_king.Name[2] - 48;
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;
            Button wk = white_king;
            Button bk = black_king;
            bool c = false;
            Image dI = defender.Image;
            if (row + 1 < 8)
            {
                Image i = box[row + 1, col].Image;
                black_king = box[row + 1, col];

                if (box[row + 1, col].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row + 1, col].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row + 1, col].Image = i;
                black_king = bk;
                black_king.Image = bkI;


            }


            if (row - 1 >= 0)
            {
                Image i = box[row - 1, col].Image;
                black_king = box[row - 1, col];

                if (box[row - 1, col].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row - 1, col].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row - 1, col].Image = i;
                black_king = bk;
                black_king.Image = bkI;
            }
            if (col - 1 >= 0)
            {
                Image i = box[row, col - 1].Image;
                black_king = box[row, col - 1];

                if (box[row, col - 1].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row, col - 1].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row, col - 1].Image = i;
                black_king = bk;
                black_king.Image = bkI;

            }
            if (col + 1 < 8)
            {
                Image i = box[row, col + 1].Image;
                black_king = box[row, col + 1];

                if (box[row, col + 1].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row, col + 1].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row, col + 1].Image = i;
                black_king = bk;
                black_king.Image = bkI;

            }
            //////////////////////////////

            if (row + 1 < 8 && col + 1 < 8)
            {
                Image i = box[row + 1, col + 1].Image;
                black_king = box[row + 1, col + 1];

                if (box[row + 1, col + 1].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row + 1, col + 1].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row + 1, col + 1].Image = i;
                black_king = bk;
                black_king.Image = bkI;

            }




            if (row + 1 < 8 && col - 1 >= 0)
            {
                Image i = box[row + 1, col - 1].Image;
                black_king = box[row + 1, col - 1];

                if (box[row + 1, col - 1].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row + 1, col - 1].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row + 1, col - 1].Image = i;
                black_king = bk;
                black_king.Image = bkI;
            }

            if (row - 1 >= 0 && col + 1 < 8)
            {
                Image i = box[row - 1, col + 1].Image;
                black_king = box[row - 1, col + 1];

                if (box[row - 1, col + 1].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row - 1, col + 1].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row - 1, col + 1].Image = i;
                black_king = bk;
                black_king.Image = bkI;

            }

            if (row - 1 >= 0 && col - 1 >= 0)
            {
                Image i = box[row - 1, col - 1].Image;
                black_king = box[row - 1, col - 1];

                if (box[row - 1, col - 1].Image == null || isWhite(i))
                {
                    black_king.Image = bkI;

                    if (!isCheckOnBlack())
                    {
                        box[row - 1, col - 1].Image = i;
                        black_king = bk;
                        black_king.Image = bkI;
                        return true;
                    }



                }
                box[row - 1, col - 1].Image = i;
                black_king = bk;
                black_king.Image = bkI;

            }


            return false;
        }
        private void validateDefenders()
        {

            Image dI = defender.Image;
            valid_defenders.Clear();
            if (isCheckOnBlack())
            {
                int row = black_king.Name[1] - 48;
                int col = black_king.Name[2] - 48;
                int drow = defender.Name[1] - 48;
                int dcol = defender.Name[2] - 48;

                if (dI == wQ)
                {
                    if (row == drow && col < dcol)
                    {
                        for (int i = col + 1; i < dcol; i++)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (row == drow && col > dcol)
                    {
                        for (int i = col - 1; i > dcol; i--)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (col == dcol && row > drow)
                    {
                        for (int i = row - 1; i > drow; i--)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }
                    else if (col == dcol && row < drow)
                    {
                        for (int i = row + 1; i < drow; i++)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }



                    else if (col > dcol && row > drow)
                    {
                        for (int i = row - 1, j = col - 1; i > drow && j > dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col > dcol && row < drow)
                    {
                        
                        for (int i = row + 1, j = col - 1; i < drow && j > dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col < dcol && row > drow)
                    {
                        for (int i = row - 1, j = col + 1; i > drow && j < dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }
                    else if (col < dcol && row < drow)
                    {
                        for (int i = row + 1, j = col + 1; i < drow && j < dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }


                }
                else if (dI == wR1 || dI == wR2)
                {
                    if (row == drow && col < dcol)
                    {
                        for (int i = col + 1; i < dcol; i++)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (row == drow && col > dcol)
                    {
                        for (int i = col - 1; i > dcol; i--)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (col == dcol && row > drow)
                    {
                        for (int i = row - 1; i > drow; i--)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }
                    else if (col == dcol && row < drow)
                    {
                        for (int i = row + 1; i < drow; i++)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }

                }
                else if (dI == wB)
                {
                    if (col > dcol && row > drow)
                    {
                        for (int i = row - 1, j = col - 1; i > drow && j > dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col > dcol && row < drow)
                    {
                        
                        for (int i = row + 1, j = col - 1; i < drow && j > dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col < dcol && row > drow)
                    {
                        for (int i = row - 1, j = col + 1; i > drow && j < dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }
                    else if (col < dcol && row < drow)
                    {
                        for (int i = row + 1, j = col + 1; i < drow && j < dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }
                }
            }
            else if (isCheckOnWhite())
            {
                int row = white_king.Name[1] - 48;
                int col = white_king.Name[2] - 48;
                int drow = defender.Name[1] - 48;
                int dcol = defender.Name[2] - 48;

                if (dI == bQ)
                {
                    if (row == drow && col < dcol)
                    {
                        for (int i = col + 1; i < dcol; i++)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (row == drow && col > dcol)
                    {
                        for (int i = col - 1; i > dcol; i--)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (col == dcol && row > drow)
                    {
                        for (int i = row - 1; i > drow; i--)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }
                    else if (col == dcol && row < drow)
                    {
                        for (int i = row + 1; i < drow; i++)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }



                    else if (col > dcol && row > drow)
                    {
                        for (int i = row - 1, j = col - 1; i > drow && j > dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col > dcol && row < drow)
                    {
                        
                        for (int i = row + 1, j = col - 1; i < drow && j > dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col < dcol && row > drow)
                    {
                        for (int i = row - 1, j = col + 1; i > drow && j < dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }
                    else if (col < dcol && row < drow)
                    {
                        for (int i = row + 1, j = col + 1; i < drow && j < dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }


                }
                else if (dI == bR1 || dI == bR2)
                {
                    if (row == drow && col < dcol)
                    {
                        for (int i = col + 1; i < dcol; i++)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (row == drow && col > dcol)
                    {
                        for (int i = col - 1; i > dcol; i--)
                        {
                            valid_defenders.Add(box[row, i]);
                        }
                    }
                    else if (col == dcol && row > drow)
                    {
                        for (int i = row - 1; i > drow; i--)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }
                    else if (col == dcol && row < drow)
                    {
                        for (int i = row + 1; i < drow; i++)
                        {
                            valid_defenders.Add(box[i, col]);
                        }
                    }

                }
                else if (dI == bB)
                {
                    if (col > dcol && row > drow)
                    {
                        for (int i = row - 1, j = col - 1; i > drow && j > dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col > dcol && row < drow)
                    {
                        
                        for (int i = row + 1, j = col - 1; i < drow && j > dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j--;
                        }
                    }
                    else if (col < dcol && row > drow)
                    {
                        for (int i = row - 1, j = col + 1; i > drow && j < dcol; i--)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }
                    else if (col < dcol && row < drow)
                    {
                        for (int i = row + 1, j = col + 1; i < drow && j < dcol; i++)
                        {
                            valid_defenders.Add(box[i, j]);
                            j++;
                        }
                    }
                }
            }
        }
        private bool canWhiteDefend()
        {
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;
            Button wk = white_king;
            Button bk = black_king;
            white_king.Image = null;
            bool c = false;
            if (defender.Image == bN || blackPawns.Contains(defender.Image))
                return false;
            foreach (Button b in valid_defenders.ToArray())
            {
                Image bI = b.Image;
                black_king = b;
                black_king.Image = bkI;
                c = isCheckOnBlack();

                black_king = bk;
                black_king.Image = bkI;
                b.Image = bI;
                white_king.Image = wkI;
                if (c)
                    return true;


            }
           white_king.Image = wkI;


            return false;

        }
        private bool canBlackDefend()
        {
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;
            Button wk = white_king;
            Button bk = black_king;
            black_king.Image= null;
            bool c = false;
            if (defender.Image == wN || whitePawns.Contains(defender.Image))
                return false;
            foreach (Button b in valid_defenders.ToArray())
            {
                Image bI = b.Image;
                white_king = b;
                white_king.Image = wkI;
                c = isCheckOnWhite();

                white_king = wk;
                white_king.Image = wkI;
                b.Image = bI;
                black_king.Image = bkI;

                if (c)
                    return true;


            }
            black_king.Image = bkI;

            return false;

        }
        private bool isDrawn()
        {
            bool c1 = kingWithKnights();
            bool c2 = kingWithOneBishop();
            if (threeSameMoves())
            {
                MessageBox.Show("Drawn By Repetetive Moves");
                resetBox();
                return false;
                
            }

            return c1 || c2 ;

        }
        private bool threeSameMoves()
        {
            int i = WhitePlayedMoves.Count;
            int j = BlackPlayedMoves.Count;
            bool c = false;
            if(i<4 && j<4)
                return false;
            for(int k = i-1; k > i - 4; k--)
            {
                Button[,] b1 = WhitePlayedMoves[k];
                Button[,] b2 = WhitePlayedMoves[k-1];
                if(b1[0,0] != b2[0,1] && b1[0, 1] != b2[0, 0])
                    return false;
                continue;


            }
            for (int k = j - 1; k > j - 4; k--)
            {
                Button[,] b1 = BlackPlayedMoves[k];
                Button[,] b2 = BlackPlayedMoves[k - 1];
                if (b1[0, 0] != b2[0, 1] && b1[0, 1] != b2[0, 0])
                    return false;
                continue;


            }

            return true;
        }
        private bool kingWithOneBishop()
        {
            int c1 = 0;
            int c2 = 0;

            foreach (Button b in box)
            {
                if (b.Image == null || b.Image == wK || b.Image == bK || b.Image == wB || b.Image == bB)
                {
                    if (b.Image == wB)
                        c1++;
                    if (b.Image == bB)
                        c2++;
                    continue;
                }
                if (b.Image != wK || b.Image != bK)
                {

                    return false;

                }
            }
            if (c1 <= 1 && c2 <= 1)
                return true;
            else
                return false ;
        }
        private bool kingWithKnights()
        {
            foreach (Button b in box)
            {
                if (b.Image == null || b.Image == wK || b.Image == bK || b.Image == wN || b.Image == bN)
                {
                    continue;
                }
                if (b.Image != wK || b.Image != bK)
                {

                    return false;

                }
            }
            return true;
        }
        private bool isBlackStalemate()
        {
            foreach(Button b in box)
            {
                if (b.Image == null)
                    continue;
                if (blackPieces.Contains(b.Image) && b.Image !=bK)
                {
                    return false;
                }

            }
            if (!isCheckOnBlack())
            {
                return isBlackCheckmate();
            }
            return false;
        }
        private bool isWhiteStalemate()
        {
            foreach (Button b in box)
            {
                if (whitePieces.Contains(b.Image) && b.Image != wK)
                {
                    return false;
                }

            }
            if (!isCheckOnWhite())
            {
                return isWhiteCheckmate();
            }
            return false;
        }
        private void PawnPromotion(Button button)
        {
            defender.Image = button.Image;
            bP.Visible = wP.Visible = false;
            foreach (Button b in box)
            {
                b.Enabled = true;
            }
            if (isB && isCheckOnWhite())
            {

                if (isWhiteCheckmate())
                {
                    MessageBox.Show("Black Won By CheckMate");
                    resetBox();

                }


            }
            if (isW && isCheckOnBlack())
            {

                if (isBlackCheckmate())
                {
                    MessageBox.Show("White Won By CheckMate");
                    resetBox();

                }

            }


            if (isW && isBlackStalemate())
            {
                MessageBox.Show("Drawn By Stalemate");
                resetBox();
            }
            if (isB && isWhiteStalemate())
            {
                MessageBox.Show("Drawn By Stalemate");
                resetBox();
            }
            if (isDrawn())
            {
                MessageBox.Show("Drawn By insufficient pieces");
                resetBox();
            }

            
            attacker_selected = false;
            defender_selected = false;

            invertMove();

            
        }
        private bool castle()
        {
            Image wkI = white_king.Image;
            Image bkI = black_king.Image;

            Button bk = black_king;
            Button wk = white_king;
            bool c = false;
            if (isAttackerBLack() && IsAttackerKing() && (defender.Image == bR1 || defender == c02) && !isBKingMoved && !isBR1Moved)
            {
                black_king = d03;
                d03.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {
                    black_king = bk;
                    d03.Image = null;
                    return false;
                }
                d03.Image = null;

                black_king = c02;
                c02.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {

                    black_king = bk;

                    c02.Image = null;
                    return false;
                }
                c02.Image = null;

                black_king = b01;
                b01.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {

                    black_king = bk;
                    b01.Image = null;
                    return false;
                }
                b01.Image = null;

                black_king = a00;
                Image A00 = a00.Image;
                a00.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {

                    black_king = bk;
                    a00.Image = A00;
                    return false;
                }
                a00.Image = A00;


                black_king = bk;

                c02.Image = bkI;
                black_king = c02;

                d03.Image = a00.Image;
                a00.Image = null;
                isBKingMoved = true;
                isBR1Moved = true;

                attacker.Image = null;

                attacker_selected = false;
                defender_selected = false;

                invertMove();
                return true;
            }
            else if (isAttackerBLack() && IsAttackerKing() && (defender.Image == bR2 || defender == g06) && !isBKingMoved && !isBR2Moved)
            {

                black_king = f05;
                f05.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {

                    black_king = bk;
                    f05.Image = null;
                    return false;
                }
                f05.Image = null;

                black_king = g06;
                g06.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {

                    black_king = bk;
                    g06.Image = null;
                    return false;
                }
                g06.Image = null;

                black_king = h07;
                Image H07 = h07.Image;
                h07.Image = attacker.Image;
                c = isCheckOnBlack();
                if (c)
                {

                    black_king = bk;
                    h07.Image = H07;
                    return false;
                }
                h07.Image = H07;


                black_king = bk;
                g06.Image = bkI;
                black_king = g06;
                f05.Image = h07.Image;
                h07.Image = null;
                isBKingMoved = true;
                isBR2Moved = true;

                attacker.Image = null;

                attacker_selected = false;
                defender_selected = false;
                invertMove();
                return true;

            }
            else if (isAttackerWhite() && IsAttackerKing() && (defender.Image == wR1 || defender == c72) && !isWKingMoved && !isWR1Moved)
            {

                white_king = d73;
                d73.Image = attacker.Image;
                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    d73.Image = null;
                    return false;
                }
                d73.Image = null;

                white_king = c72;
                c72.Image = attacker.Image;
                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    c72.Image = null;
                    return false;
                }
                c72.Image = null;

                white_king = b71;
                b71.Image = attacker.Image;
                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    b71.Image = null;
                    return false;
                }
                b71.Image = null;

                white_king = a70;
                Image A70 = a70.Image;
                a70.Image = attacker.Image;
                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    a70.Image = A70;
                    return false;
                }
                a70.Image = A70;

                white_king = wk;
                c72.Image = wkI;
                white_king = c72;
                d73.Image = a70.Image;
                a70.Image = null;
                isWKingMoved = true;
                isWR1Moved = true;

                attacker.Image = null;

                attacker_selected = false;
                defender_selected = false;
                invertMove();
                return true;

            }
            else if (isAttackerWhite() && IsAttackerKing() && (defender.Image == wR2 || defender == g76) && !isWKingMoved && !isWR2Moved)
            {

                white_king = f75;
                f75.Image = attacker.Image;

                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    f75.Image = null;
                    return false;
                }
                f75.Image = null;

                white_king = g76;
                g76.Image = attacker.Image;
                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    g76.Image = null;
                    return false;
                }
                g76.Image = null;

                white_king = h77;
                Image H7 = h77.Image;
                h77.Image = attacker.Image;
                c = isCheckOnWhite();
                if (c)
                {

                    white_king = wk;
                    h77.Image = H7;

                    return false;
                }
                h77.Image = H7;



                white_king = wk;

                g76.Image = wkI;
                white_king = g76;
                f75.Image = h77.Image;
                h77.Image = null;
                isWKingMoved = true;
                isWR2Moved = true;
                attacker.Image = null;

                attacker_selected = false;
                defender_selected = false;
                invertMove();
                return true;

            }
            return false;

        }
        private bool isAttackerBLack()
        {
            return blackPieces.Contains(attacker.Image);
        }
        private bool isAttackerWhite()
        {
            return whitePieces.Contains(attacker.Image);
        }
        private bool isWhite(Image i)
        {
            return whitePieces.Contains(i);

        }
        private bool isBlack(Image i)
        {
            return blackPieces.Contains(i);

        }
        private void AddMoves()
        {
            Button[,] buttons = new Button[1, 2];
            buttons[0, 0] = attacker;
            buttons[0, 1] = defender;

            if (move)
            {
                WhitePlayedMoves.Add(buttons);
            }
            else if (!move)
            {
                BlackPlayedMoves.Add(buttons);

            }


        }
        private void invertMove()
        {
            if (move)
                move = false;
            else if (!move)
                move = true;
        }
        private bool IsAttackerKing()
        {
            return attacker.Image == wK || attacker.Image == bK;
        }

        private void resetBox()
        {
            foreach (Button b in box)
            {
                b.Image = null;
            }
            //White Pieces Set First Row
            this.a70.Image = wR1;
            this.b71.Image = wN;
            this.c72.Image = wB;
            this.d73.Image = wQ;
            this.e74.Image = wK;
            this.f75.Image = wB;
            this.g76.Image = wN;
            this.h77.Image = wR2;

            //White Pieces Set Pawns
            this.a60.Image = wP1;
            this.b61.Image = wP2;
            this.c62.Image = wP3;
            this.d63.Image = wP4;
            this.e64.Image = wP5;
            this.f65.Image = wP6;
            this.g66.Image = wP7;
            this.h67.Image = wP8;


            //Black Pieces Set First Row
            this.a00.Image = bR1;
            this.b01.Image = bN;
            this.c02.Image = bB;
            this.d03.Image = bQ;
            this.e04.Image = bK;
            this.f05.Image = bB;
            this.g06.Image = bN;
            this.h07.Image = bR2;

            //Black Pieces Set Pawns
            this.a10.Image = bP1;
            this.b11.Image = bP2;
            this.c12.Image = bP3;
            this.d13.Image = bP4;
            this.e14.Image = bP5;
            this.f15.Image = bP6;
            this.g16.Image = bP7;
            this.h17.Image = bP8;
            //Kings Initial Positions
            white_king = e74;
            black_king = e04;
            move = false;


        }

    }

}
