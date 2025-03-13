using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {



        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
          // Wczytuję wszystkie liczby wejściowe do listy
        List<int> liczby = new List<int>();
        string? linia;
        while ((linia = Console.ReadLine()) != null && linia != "")
        {
            if (int.TryParse(linia.Trim(), out int liczba))
                 liczby.Add(liczba);
        }

         if (liczby.Count == 0) return;



          // Znajduję największą liczbę z wejścia
         int maxLiczba = 0;
        foreach (var l in liczby)
        {
            if (l > maxLiczba) maxLiczba = l;
        }

      
        
       
        
        // Tworzę tablicę najmniejszych dzielników pierwszych do maxLiczba
        int[] najmniejszyPierwszyDzielnik = BudujSPF(maxLiczba);

        // Przetwarzam każdą liczbę i wypisuję jej faktoryzację
        foreach (var l in liczby)
        {
            Console.Write(l + " = ");
            List<int> czynniki = new List<int>();
            int tymczasowa = l;
            while (tymczasowa != 1)
            {
                czynniki.Add(najmniejszyPierwszyDzielnik[tymczasowa]);
                tymczasowa /= najmniejszyPierwszyDzielnik[tymczasowa];
            }
            Console.WriteLine(string.Join(" x ", czynniki));
        }
    }

  
    
    // Buduje tablicę najmniejszych dzielników pierwszych do n
    static int[] BudujSPF(int n)
    {
        int[] spf = new int[n + 1];
        for (int i = 1; i <= n; i++) spf[i] = i;

        for (int i = 2; i * i <= n; i++)
        {
            if (spf[i] == i) // i jest liczbą pierwszą
            {
                for (int j = i * i; j <= n; j += i)
                {
                    if (spf[j] == j) spf[j] = i;
                }
            }
        }
        return spf;
    }
}
