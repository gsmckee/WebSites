using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Profile
/// </summary>
public class Profile
{
    public string Position, Mascot, First, Last;
    public int Age, Height, Weight, JNumber;
    public bool InjuredReserve, Active;
    public Profile(string pos, string mascot, string first, string last,
        int age, int height, int weight, int jerNum, bool injRes, bool active)// Player constructor
    {
        //
        // TODO: Add constructor logic here
        Position = pos;
        Mascot = mascot;
        First = first;
        Last = last;
        Age = age;
        Height = height;
        Weight = weight;
        JNumber = jerNum;
        InjuredReserve = injRes;
        Active = active;
        //
    }
    public string City, State;
    public int Championships;
    public Profile(string city, string mascot, string state, int champ)// Team constructor
    {
        //
        // TODO: Add constructor logic here
        City = city;
        Mascot = mascot;
        State = state;
        Championships = champ;
        //
    }
    public int Year, Wins, Losses, Ties;
    public Profile(int year, string mascot, int wins, int losses, int ties)// Record constructor
    {
        //
        // TODO: Add constructor logic here
        Year = year;
        Mascot = mascot;
        Wins = wins;
        Losses = losses;
        Ties = ties;
        //
    }

}