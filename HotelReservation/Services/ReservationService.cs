using System;
using System.Collections.Generic;
using HotelReservation.Models;

namespace HotelReservation.Services
{
    public class ReservationService
    {
        private readonly Hotel _hotel;

        public ReservationService(Hotel hotel)
        {
            _hotel = hotel;
        }

        public List<int> TrouverChambresDisponibles(List<Chambre> chambres, Reservation reservation)
        {
            return _hotel.TrouverChambresDisponibles(chambres, reservation);
        }


    }
}
