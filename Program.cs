using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Declaring all libraries needed



//The Train class 
public class Train
{
        //set the value for the property StationName
        public string StationName
        {
        get;
        set;
        } = string.Empty;

        //set the value for the property StationStop
        public bool StationStop
        {
        get;
        set;
        }

    //This method used to input how many stops into stopping sequence including stationName and stationStop
    public static void TrainListPassing(List<Train> stations)
    {
        //Inform how many stops needed
        Console.WriteLine("How many stations for this stopping sequence? Please input a number greater than 1 ");
        int stops = Int32.Parse(Console.ReadLine());
        string stationName = "";
        string stationStop = "";

        //This loop used to input value stationName and stationStop
        for (int i = 0; i < stops; i++)
        {
            Console.WriteLine("Please enter station name");
            stationName = Console.ReadLine();
            Console.WriteLine("Is this train stopping at the station (y) or running express through the station (n) ? y/n");
            stationStop = Console.ReadLine();

            if (stationStop == "y")
            {
                stations.Add(new Train { StationName = stationName, StationStop = true });
            }
            else
            {
                stations.Add(new Train { StationName = stationName, StationStop = false }); ;
            }
        }

        //This used to print out all stations in the sequence
        Console.WriteLine(" ");
        for (int i = 0; i < stations.Count; i++)
        {
            Console.WriteLine(stations[i].StationName + " " + stations[i].StationStop);
        }
        Console.WriteLine(" ");

    }

    //the second public method for class Train
    public static string TrainListGenerator(List<Train> stations)
    {
        //declare the pattern string for informing to the public
        string pattern = "";

        //create the list of arrays used to separate into 2 arrays if there are 2 express sections
        int stationNumber = stations.Count;
        List<int> stationStopNumber = new List<int>();
        List<int> stationStopNumber1 = new List<int>();
        List<int> stationStopNumber2 = new List<int>();
        int gap = 0;

        //extract all express stations 
        for (int i = 1; i < stationNumber-1; i++)
        {
            if (stations[i].StationStop == false)
                stationStopNumber.Add(i);
        }
        for (int i = 1; i < stationStopNumber.Count; i++)
        {
            if(stationStopNumber[i]- stationStopNumber[i-1]>2)
            {
                gap = i;
            }
        }
        //first express section
        for (int i = 0; i < gap; i++)
        {
            stationStopNumber1.Add(stationStopNumber[i]);
        }
        //second express section
        for (int i = gap; i < stationStopNumber.Count; i++)
        {
                stationStopNumber2.Add(stationStopNumber[i]);
        }


//        Console.WriteLine("[{0}]", string.Join(", ", stationStopNumber));
//        Console.WriteLine("[{0}]", string.Join(", ", stationStopNumber1));
//        Console.WriteLine("[{0}]", string.Join(", ", stationStopNumber2));
//        Console.WriteLine("");

        //pattern showed if only one stops
        if (stationNumber < 2)
        {
            pattern = "Train stopping sequence is invalid";
        }

        //This pattern will be returned if only 2 stations in the stop sequence 
        if (stationNumber == 2)
        {

            pattern = "This train stops at " + stations[0].StationName + " and " + stations[1].StationName + " only";

        }
        else
        {
        //when the stop sequence has more than 2 stations, only one express station before the last stopping station
            if (stationStopNumber.Count == 1)
            {
                //when there is one express stop in the sequence
                pattern = "This train stops at all stations except "+ stations[stationStopNumber[0]].StationName;
            }

            else
            {

                if(stationStopNumber.Count > 1)
                {

                    //if the stopping sequence has only one express section
                    if(stationStopNumber1.Count == 0)
                    {

                        pattern = "This train runs express from " + stations[stationStopNumber2[0]].StationName;
                        int station2 = stationStopNumber2[0];
                        pattern = pattern + " to " + stations[stationStopNumber2.Last()].StationName;

                        foreach (int i in stationStopNumber2)
                        {
                            if (station2 != i)
                            {
                                pattern = pattern + ", stopping only at " + stations[station2].StationName;
                                break;
                            }
                            station2++;
                        }

                    }


                    //if the stopping sequence has only two express sections
                    if (stationStopNumber1.Count > 0)
                    {

                        pattern = "This train runs express from " + stations[stationStopNumber1[0]].StationName;
                        int station1 = stationStopNumber1[0];
                        pattern = pattern + " to " + stations[stationStopNumber1.Last()].StationName;

                        foreach (int i in stationStopNumber1)
                        {
                            if (station1 != i)
                            {
                                pattern = pattern + ", stopping only at " + stations[station1].StationName;
                                break;
                            }
                            station1++;
                        }    
                    }

                    if ( ( stationStopNumber2.Count > 0) && (stationStopNumber1.Count > 0))
                    {
                        pattern = pattern +" then express from "+ stations[stationStopNumber2[0]].StationName;
                        int station2 = stationStopNumber2[0];
                        pattern = pattern + " to " + stations[stationStopNumber2.Last()].StationName;

                        foreach (int i in stationStopNumber2)
                        {
                            if (station2 != i)
                            {
                                pattern = pattern + ", stopping only at " + stations[station2].StationName;
                                break;
                            }
                            station2++;
                        }
                    }





                }
                else
                {

                //if there is no express section
                pattern = "This train stops at all stations";
                }

            }

        }
        return pattern;
    }        

}

namespace TrainController
{
public class Test 
{ 

    //This is the main method to call the above Train class and two methods
    static void Main(string[] args)
    {
        Console.WriteLine("This is program to generate the pattern text to the public");

            //This is a data sample used to test
            List<Train> trainSequence = new List<Train>
            {
                new Train{ StationName = "Fortitude Valley", StationStop = false },
                new Train{ StationName = "Bowen Hills", StationStop = true },
                new Train{ StationName = "Eagle Junction", StationStop = true },
                new Train{ StationName = "Park Road", StationStop = false },
                new Train{ StationName = "Buranda", StationStop = false },
                new Train{ StationName = "Wynnum", StationStop = true },
                new Train{ StationName = "Wynnum Central", StationStop = false },
                new Train{ StationName = "Manly", StationStop = false },
                new Train{ StationName = "Pietrie", StationStop = false },
                new Train{ StationName = "Bray Park", StationStop = true },
                new Train{ StationName = "Sunshine", StationStop = true },
                new Train{ StationName = "Northgate", StationStop = false },
                new Train{ StationName = "Altandi", StationStop = false },
                new Train{ StationName = "Kuraby", StationStop = true },
                new Train{ StationName = "Woodridge", StationStop = false },
                new Train{ StationName = "Loganlea", StationStop = true }
            };


            //to print out the stopping sequence sample
            for (int i=0; i<trainSequence.Count; i++)
            {
                Console.WriteLine(trainSequence[i].StationName + " " + trainSequence[i].StationStop);
            }
            Console.WriteLine(" ");

            //This is an instruction ask for using the data sample or input a new list 
            Console.WriteLine("Would you like use the above sample to test? y/n");
            string answer1 = Console.ReadLine();
            if(answer1 == "y")
            {
                Console.WriteLine(Train.TrainListGenerator(trainSequence));
            }
            if (answer1 == "n")
            {
                Console.WriteLine("Are you sure to empty the list and input again? y/n");
                string answer2 = Console.ReadLine();
                if (answer2 == "n")
                {
                    Console.WriteLine(Train.TrainListGenerator(trainSequence));
                }
                if (answer2 == "y")
                {
                    trainSequence.Clear();
                    Train.TrainListPassing(trainSequence);
                    Console.WriteLine(Train.TrainListGenerator(trainSequence));
                }
            }




        }
}
}






