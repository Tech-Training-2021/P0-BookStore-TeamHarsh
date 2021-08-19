﻿using System;

namespace Table
{
    public class Table
    {
        public static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }
       public static void PrintRow(int tableWidth,params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width,tableWidth) + "|";
            }

            Console.WriteLine(row);
        }
        public static string AlignCentre(string text, int width, int tableWidth)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}