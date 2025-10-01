using MotoGP.API.Models;
using System;
using System.Collections.Generic;

namespace MotoGP.API.DataStores
{
    public class MotoGPDataStore
    {
        private static readonly Lazy<MotoGPDataStore> instance = new(() => new MotoGPDataStore());

        public static MotoGPDataStore Instance => instance.Value;

        public List<TeamsDto> Teams { get; set; }

        private MotoGPDataStore() =>
            // Populate the Teams list with sample data
            Teams =
            [
                new TeamsDto
                {
                    Id = 1,
                    Name = "Team A",
                    Logo = "logoA.png",
                    Riders =
                    [
                        new() { Id = 1, LastName = "Rossi", FirstName = "Valentino", Number = 46 },
                        new() { Id = 2, LastName = "Lorenzo", FirstName = "Jorge", Number = 99 }
                    ]
                },
                new TeamsDto
                {
                    Id = 2,
                    Name = "Team B",
                    Logo = "logoB.png",
                    Riders =
                    [
                        new() { Id = 3, LastName = "Marquez", FirstName = "Marc", Number = 93 },
                        new() { Id = 4, LastName = "Pedrosa", FirstName = "Dani", Number = 26 }
                    ]
                    
                }
            ];
    }
}
