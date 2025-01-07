using DVI_Access_Lib;

// Importer metoder fra API library
DVI_Climate climate = new DVI_Climate("http://docker.data.techcollege.dk:5051");
DVI_Stock stock = new DVI_Stock("http://docker.data.techcollege.dk:5051");


// Kør program kontinuerligt 
while (true)
{
    // Refresh console
    Console.Clear();

    // Temperatur og fugtighed
    Console.WriteLine("********** Temperatur og fugtighed **********");
    Console.WriteLine($"Temperatur: {climate.CurrTemp()}°C");
    Console.WriteLine($"Fugtighed: {climate.CurrHum()}%");
    Console.WriteLine();

    // Tid og dato
    Console.WriteLine("********** Dato / Tid **********");
    Console.WriteLine($"Lokal tid: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
    Console.WriteLine($"København: {DateTime.UtcNow.AddHours(1):dd/MM/yyyy HH:mm:ss}");
    Console.WriteLine($"London: {DateTime.UtcNow:dd/MM/yyyy HH:mm:ss}");
    Console.WriteLine($"Singapore: {DateTime.UtcNow.AddHours(8):dd/MM/yyyy HH:mm:ss}");
    Console.WriteLine();

    // Vine over maksimum
    Console.WriteLine("********** Varer Over Maksimum **********");
    var stockOver = stock.StockOverThreshold();
    if (stockOver.Count == 0)
    {
        Console.WriteLine("Ingen varer over maksimum.");
    }
    else
    {
        foreach (var wine in stockOver)
        {
            Console.WriteLine($"• {wine.WineName} - {wine.NumInStock} stk.");
        }
    }
    Console.WriteLine();

    // Vine under minimum
    Console.WriteLine("********** Varer Under Minimum **********");
    var stockUnder = stock.StockUnderThreshold();
    if (stockUnder.Count == 0)
    {
        Console.WriteLine("Ingen varer under minimum.");
    }
    else
    {
        foreach (var wine in stockUnder)
        {
            Console.WriteLine($"• {wine.WineName} - {wine.NumInStock} stk.");
        }
    }

    // Delay inden refresh 
    Thread.Sleep(60000);
}


