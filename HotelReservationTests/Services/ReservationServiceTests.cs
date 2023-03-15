using System;
using System.Collections.Generic;
using Xunit;
using HotelReservation.Services;
using HotelReservation.Models;

namespace HotelReservation.Tests
{
    public class ReservationServiceTests
    {
        private readonly ReservationService _reservationService;
        private readonly Hotel _hotel;
        private readonly List<Chambre> _chambres;

        public ReservationServiceTests()
        {
            _chambres = new List<Chambre>()
            {
                new Chambre { NumeroChambre = 101, Capacite = 4, DateDebut = new DateTime(2023, 3, 1), DateFin = new DateTime(2023, 3, 5) },
                new Chambre { NumeroChambre = 102, Capacite = 4, DateDebut = new DateTime(2023, 3, 1), DateFin = new DateTime(2023, 3, 10) },
                new Chambre { NumeroChambre = 103, Capacite = 4, DateDebut = new DateTime(2023, 3, 3), DateFin = new DateTime(2023, 3, 8) },
                new Chambre { NumeroChambre = 104, Capacite = 4, DateDebut = new DateTime(2023, 3, 1), DateFin = new DateTime(2023, 3, 15) }
            };

            _hotel = new Hotel { Chambres = _chambres };
            _reservationService = new ReservationService(_hotel);
        }

        [Fact]
        public void TrouverChambresDisponibles_RetourneChambresDisponibles()
        {
            // Arrange
            var reservation = new Reservation
            {
                DateDebut = new DateTime(2023, 3, 3),
                DateFin = new DateTime(2023, 3, 5),
                NombreChambres = 2,
                NombrePersonnes = 4
            };

            // Act
            var result = _reservationService.TrouverChambresDisponibles(_chambres, reservation);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(101, result);
            Assert.Contains(102, result);
        }

        [Fact]
        public void TrouverChambresDisponibles_RetourneVide_QuandAucuneChambreDisponible()
        {
            // Arrange
            var reservation = new Reservation
            {
                DateDebut = new DateTime(2023, 3, 20),
                DateFin = new DateTime(2023, 3, 25),
                NombreChambres = 1,
                NombrePersonnes = 2
            };

            // Act
            var result = _reservationService.TrouverChambresDisponibles(_chambres, reservation);

            // Assert
            Assert.Empty(result);
        }
    }
}
