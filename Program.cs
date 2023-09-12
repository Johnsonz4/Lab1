/**
*--------------------------------------------------------------------
* File name: ssLab1
* Project name: Review Lab
*--------------------------------------------------------------------
* Author’s names and emails:  Zoe Johnson, johnsonz3@etsu.edu 
* Course-Section: CSCI-2910-001
* Creation Date: 9/10/23
* -------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sspLab1;
class Program
{

    static void Main(string[] args)
    {
        // STEP 1 
        string filePath = @"/Users/zoe/Projects/videogames.csv";

        List<VideoGame> videoGames = new List<VideoGame>();

        //STEP 2
        try
        {
            
            string[] lines = File.ReadAllLines(filePath);

            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                
                if (values.Length >= 8)
                {
                   
                    VideoGame game = new VideoGame
                    {
                        Name = values[0],
                        Platform = values[1],
                        Year = int.Parse(values[2]),
                        Genre = values[3],
                        Publisher = values[4],
                        NASales = double.Parse(values[5]),
                        JPSales = double.Parse(values[6]),
                        OtherSales = double.Parse(values[7]),
                        GlobalSales = double.Parse(values[8])
                    };

                    
                    videoGames.Add(game);
                }
                else
                {
                    Console.WriteLine($"Skipping line {i + 1}: Insufficient data.");
                }
            }

            foreach (var game in videoGames)
            {
                Console.WriteLine($"Title: {game.Name}, Year: {game.Year}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // STEP 3
        // publisher 
        string selectedPublisher = "Nintendo";

      
        var nintendoGames = videoGames.Where(game => game.Publisher == selectedPublisher).ToList();

        
        nintendoGames = nintendoGames.OrderBy(game => game.Name).ToList();

        
        Console.WriteLine($"Nintendo Games (Sorted by Title):");
        foreach (var game in nintendoGames)
        {
            Console.WriteLine(game);
            Console.WriteLine();
        }

        // STEP 4
        int totalGames = videoGames.Count;

       
        int nintendoGameCount = nintendoGames.Count;

      
        double publisherPercentage = (double)nintendoGameCount * 100 / totalGames;

       
        Console.WriteLine($"Out of {totalGames} games, {nintendoGameCount} are developed by {selectedPublisher}, which is {publisherPercentage:F2}%.");

        // STEP 5
        //genre 
        string selectedGenre = "Action";

        
        var filteredGames = videoGames.Where(game => game.Genre == selectedGenre).ToList();

   
        int totalGamesByGenre = filteredGames.Count;

   
        double genrePercentage = (double)totalGamesByGenre * 100 / totalGames;

       
        Console.WriteLine($"Out of {totalGames} games, {totalGamesByGenre} belong to the {selectedGenre} genre, which is {genrePercentage:F2}%.");


        static List<VideoGame> FilterGamesByPublisher(List<VideoGame> games, string publisher)
        {
            return games.Where(game => game.Publisher == publisher).OrderBy(game => game.Name).ToList();
        }

        static List<VideoGame> FilterGamesByGenre(List<VideoGame> games, string genre)
        {
            return games.Where(game => game.Genre == genre).OrderBy(game => game.Name).ToList();
        }

        static void DisplayGames(List<VideoGame> games)
        {
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
        }

        static void CalculateAndDisplayPercentage(List<VideoGame> selectedGames, List<VideoGame> allGames, string selection)
        {
            int totalGames = allGames.Count;
            int selectedCount = selectedGames.Count;
            double percentage = (double)selectedCount * 100 / totalGames;
            Console.WriteLine($"Out of {totalGames} games, {selectedCount} are {selection} games, which is {percentage:F2}%.");
        }

        static void PublisherData(List<VideoGame> videoGames)
        {
            Console.Write("Enter a publisher: ");
            string selectedPublisher = Console.ReadLine();

            // Filter games by the selected publisher
            var publisherGames = FilterGamesByPublisher(videoGames, selectedPublisher);

            // Display games from the selected publisher
            Console.WriteLine($"Games developed by {selectedPublisher} (Sorted by Title):");
            DisplayGames(publisherGames);

            // Calculate and display the percentage of games from the selected publisher
            CalculateAndDisplayPercentage(publisherGames, videoGames, selectedPublisher);
        }

        static void GenreData(List<VideoGame> videoGames)
        {
            Console.Write("Enter a genre: ");
            string selectedGenre = Console.ReadLine();

            // Filter games by the selected genre
            var genreGames = FilterGamesByGenre(videoGames, selectedGenre);

            // Display games of the selected genre
            Console.WriteLine($"{selectedGenre} games (Sorted by Title):");
            DisplayGames(genreGames);

            // Calculate and display the percentage of games of the selected genre
            CalculateAndDisplayPercentage(genreGames, videoGames, selectedGenre);

        }
        // for mac to run 
        Console.ReadLine();
    }  
}






    
    

    


