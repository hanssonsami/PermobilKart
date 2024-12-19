class Program
{
    public static void Main(string[] args)
    {
        // Title Card
        Console.WriteLine(@"
 ______  ______  ______  __    __  ______  ______  __  __           __  __   ______  ______  ______  
/\  == \/\  ___\/\  == \/\ ""-./  \/\  __ \/\  == \/\ \/\ \         /\ \/ /  /\  __ \/\  == \/\__  _\ 
\ \  _-/\ \  __\\ \  __<\ \ \-./\ \ \ \/\ \ \  __<\ \ \ \ \____    \ \  _""-.\ \  __ \ \  __<\/_/\ \/ 
 \ \_\   \ \_____\ \_\ \_\ \_\ \ \_\ \_____\ \_____\ \_\ \_____\    \ \_\ \_\\ \_\ \_\ \_\ \_\ \ \_\ 
  \/_/    \/_____/\/_/ /_/\/_/  \/_/\/_____/\/_____/\/_/\/_____/     \/_/\/_/ \/_/\/_/\/_/ /_/  \/_/ 
                                     ");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        Thread.Sleep(1000);
        Console.WriteLine("Välkommen till Permobil Kart!");
        Console.WriteLine("");

        // Create an instance of Program to call non-static methods
        Program program = new Program();

        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle("Eld Permobil", 15, 20, 50, 70),
            new Vehicle("Cykel Permobil", 25, 15, 40, 50),
            new Vehicle("Raket Permobil", 70, 5, 40, 10),
            new Vehicle("Tung Permobil", 50, 35, 70, 20),
            new Vehicle("Monster Permobil", 30, 20, 50, 10),
            new Vehicle("Gucci Permobil", 20, 20, 20 , 50),
        };

        List<Rider> riders = new List<Rider>
        {
            new Rider("Snabba Sven", 1.2, 60, 1.1),
            new Rider("Tunga Torsten", 0.9, 90, 0.8),
            new Rider("Lätta Lisa", 1.0, 50, 1.3),
            new Rider("Greger Knorr", 1.1, 75, 0.9)
        };

        List<Track> tracks = new List<Track>
        {
            new Track("Walmart", 700),
            new Track("KFC", 150),
            new Track("McDonald's", 380),
            new Track($"Willy's", 500)
        };

        Console.WriteLine("Spelare 1, skriv in ditt namn:");
        string player1Name = Console.ReadLine();
        Player player1 = program.CreatePlayer(player1Name, vehicles, riders); // Call non-static method
        Thread.Sleep(300);
        Console.Clear();
        Console.WriteLine("Spelare 2, skriv in ditt namn:");
        string player2Name = Console.ReadLine();
        Player player2 = program.CreatePlayer(player2Name, vehicles, riders); // Call non-static method
        Thread.Sleep(300);
        Console.Clear();
        Console.WriteLine("Välj en bana att köra:");
        for (int i = 0; i < tracks.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {tracks[i].TrackName} (Längd: {tracks[i].TrackLength}m)");
        }
        int trackChoice = int.Parse(Console.ReadLine()) - 1;
        Track selectedTrack = tracks[trackChoice];

        // Call the non-static PlayGame method
        program.PlayGame(player1, player2, selectedTrack);
    }

    // Välj permobil och karaktär

    Player CreatePlayer(string playerName, List<Vehicle> vehicles, List<Rider> riders)
    {
        int vehicleChoice = -1;
        int riderChoice = -1;
        Thread.Sleep(300);
        Console.Clear();
        Console.WriteLine($"{playerName}, välj en permobil:");
        // Val för permobil med felhantering
        while (true)
        {
            try
            {
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {vehicles[i].VehicleName} , Snabbhet: {vehicles[i].VehicleSpeed} , Styrning: {vehicles[i].VehicleHandling} , Tyngd: {vehicles[i].VehicleWeight} , Acceleration: {vehicles[i].VehicleAcceleration}");
                }

                Console.Write("Skriv siffran för ditt val: ");
                vehicleChoice = int.Parse(Console.ReadLine());

                if (vehicleChoice < 1 || vehicleChoice > vehicles.Count)
                {
                    Console.WriteLine("Ogiltigt val! Ange ett nummer som finns i listan.");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktig inmatning! Ange endast siffror.");
            }
        }
        Thread.Sleep(300);
        Console.Clear();
        Console.WriteLine($"{playerName}, välj en karaktär:");

        // Val för karaktär med felhantering
        while (true)
        {
            try
            {
                for (int i = 0; i < riders.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {riders[i].RiderName}");
                }

                Console.Write("Skriv siffran för ditt val: ");
                riderChoice = int.Parse(Console.ReadLine());

                if (riderChoice < 1 || riderChoice > riders.Count)
                {
                    Console.WriteLine("Ogiltigt val! Ange ett nummer som finns i listan.");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktig inmatning! Ange endast siffror.");
            }
        }

        return new Player(vehicles[vehicleChoice - 1], riders[riderChoice - 1], playerName);
    }

    //Skriv ut raceinfo innan racet
    void PlayGame(Player player1, Player player2, Track track)
    {
        Console.WriteLine($"{track.TrackName}. Längd: {track.TrackLength}m");
        Thread.Sleep(1000);
        Console.Clear();
        Thread.Sleep(600);
        Console.WriteLine("3!");
        Thread.Sleep(600);
        Console.WriteLine("2!");
        Thread.Sleep(600);
        Console.WriteLine("1!");
        Thread.Sleep(600);
        Console.WriteLine("KÖR!");
        Thread.Sleep(200);
        Console.Clear();
        int totalTime = track.TrackLength / 10;
        Random random = new Random();

        int player1Progress = 0;
        int player2Progress = 0;

        for (int t = 1; t <= totalTime; t++)

        {

            player1Progress += (int)(player1.PlayerVeichle.VehicleSpeed * player1.PlayerRider.RiderSpeedMultiplier / 10);
            player2Progress += (int)(player2.PlayerVeichle.VehicleSpeed * player2.PlayerRider.RiderSpeedMultiplier / 10);

            //Placering uppdateringar
            if (t % 6 == 0)
            {
                int eventType = random.Next(1, 6);
                HandleEvent(eventType, ref player1Progress, ref player2Progress, player1, player2);
            }
            Console.WriteLine($"Tid: {t}s | {player1.PlayerName}: {player1Progress}m | {player2.PlayerName}: {player2Progress}m");
            Thread.Sleep(1000);
            Console.Clear();
        }

        if (player1Progress > player2Progress)
        {
            Console.WriteLine($"HURRA! {player1.PlayerName} vinner!");
        }
        else if (player2Progress > player1Progress)
        {
            Console.WriteLine($"HURRA! {player2.PlayerName} vinner!");
        }
        else
        {
            Console.WriteLine("VA?! Det blev oavgjort!");
        }
    }

    //Random events
    void HandleEvent(int eventType, ref int player1Progress, ref int player2Progress, Player player1, Player player2)
    {
        switch (eventType)
        {
            case 1:
                Console.WriteLine("Nämen!: Big Chungus blockerar vägen!");
                if (player1.PlayerVeichle.VehicleHandling > player2.PlayerVeichle.VehicleHandling)
                {
                    Console.WriteLine($"{player1.PlayerName} hinner undan!");
                    player2Progress -= 10;
                }
                else
                {
                    Console.WriteLine($"{player2.PlayerName} hinner undan!");
                    player1Progress -= 10;
                }
                break;

            case 2:
                Console.WriteLine("Nämen!: En raket boost dyker upp!");
                if (player1.PlayerVeichle.VehicleAcceleration > player2.PlayerVeichle.VehicleAcceleration)
                {
                    Console.WriteLine($"{player1.PlayerName} får boosten!");
                    player1Progress += 20;
                }
                else
                {
                    Console.WriteLine($"{player2.PlayerName} får boosten!");
                    player2Progress += 20;
                }
                break;

            case 3:
                Console.WriteLine("Nämen!: Ojämn väg bromsar ner alla.");
                player1Progress -= 5;
                player2Progress -= 5;
                break;

            case 4:
                Console.WriteLine("Nämen!: En genväg upptäcks!");
                if (player1.PlayerVeichle.VehicleWeight < player2.PlayerVeichle.VehicleWeight)
                {
                    Console.WriteLine($"{player1.PlayerName} tar genvägen!");
                    player1Progress += 15;
                }
                else
                {
                    Console.WriteLine($"{player2.PlayerName} tar genvägen!");
                    player2Progress += 15;
                }
                break;

            case 5:
                Console.WriteLine("Händelse: En svår kurva dyker upp!");
                if (player1.PlayerVeichle.VehicleHandling > player2.PlayerVeichle.VehicleHandling)
                {
                    Console.WriteLine($"{player1.PlayerName} klarar kurvan bättre!");
                    player2Progress -= 10;
                }
                else
                {
                    Console.WriteLine($"{player2.PlayerName} klarar kurvan bättre!");
                    player1Progress -= 10;
                }
                break;
        }
    }
}
