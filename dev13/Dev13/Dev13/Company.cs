﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev13
{
    class Company
    {
        public ICriterion criterionSelectWorkers { private get; set; }
        private int[][] existingProfessions;
        private string[] professionsNames;
        private string pathToExistingProfessionsFile;
        private int[] lastFormedTeam;

        public Company ( ICriterion criterion )
        {
            this.criterionSelectWorkers = criterion;
            pathToExistingProfessionsFile = @"f:\Test\TAT-tasks\dev13\Dev13\Dev13\Workers.txt";
            FormingParametersFromFile();
        }

        private void FormingParametersFromFile()
        {
            try
            {
                string[] readData = File.ReadAllLines ( pathToExistingProfessionsFile );

                int numOfProfessions = Convert.ToInt32 ( readData [ readData.Length - 1 ] );
                existingProfessions = new int [ numOfProfessions ][];
                professionsNames = new string [ numOfProfessions ];

                for ( int i = 0 ; i < numOfProfessions ; i++ )
                {
                    int[] positionParams = new int [ 2 ] ;
                    string nameOfPosition = readData [ i ]. Substring ( 0 , readData [ i ].IndexOf ( ' ' ) );

                    string salary = readData [ i ].Substring ( readData [ i ].IndexOf ( ' ' ) + 1,
                                               readData [ i ].IndexOf ( ' ', readData [ i ].IndexOf ( ' ' ) + 1) - 
                                               ( readData [ i ].IndexOf ( ' ' ) + 1 ) );

                    string productivity = readData [ i ].Substring ( readData [ i ].IndexOf ( ' ' , readData [ i ].IndexOf ( ' ' ) + 1 ) + 1,
                                                readData [ i ].Length - ( readData [ i ].IndexOf ( ' ' , readData [ i ].IndexOf(' ') + 1) + 1));

                    positionParams [ 0 ] = Convert.ToInt32 ( salary );
                    positionParams [ 1 ] = Convert.ToInt32 ( productivity );

                    existingProfessions [ i ] = positionParams;
                    professionsNames [ i ] = nameOfPosition;
                }
            }
            catch
            {
                Console.WriteLine ( "Something goes wrong. Check file format." );
            }
        }

        public void FormTeam ( int budgetOfProgect , int productivity )
        {
            lastFormedTeam = criterionSelectWorkers.SelectTeam ( existingProfessions , productivity , budgetOfProgect );
            return;
        }

        public void PrintLastFormedTeam()
        {
            if ( lastFormedTeam.Max() == 0 )
            {
                Console.WriteLine ( "You is very poor for such progect. Please contact the Indian programmers. " );
            }
            else
            {
                Console.WriteLine ( "Team for progect:" );
                for ( int i = 0 ; i < existingProfessions.GetLength ( 0 ) ; i++ )
                {
                    Console.WriteLine ( " Count of {0}s is {1}. ", professionsNames [ i ] , lastFormedTeam [ i ] );
                }
            }
        }
    }
}
