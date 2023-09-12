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
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Xml.Linq;


namespace sspLab1
{
    class VideoGame : IComparable<VideoGame>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NASales { get; set; }
        public double EUSales { get; set; }
        public double JPSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }

        

        public int CompareTo(VideoGame other)
        {
            
            return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }

       
        public override string ToString()
        {
            return $"Title: {Name}, Platform: {Platform}, Year: {Year}, Genre: {Genre}, Publisher: {Publisher}, NASales: {NASales}, EUSales: {EUSales}, JPSales: {JPSales}, OtherSales: {OtherSales}, GlobalSales: {GlobalSales}";
        }

    }
}

