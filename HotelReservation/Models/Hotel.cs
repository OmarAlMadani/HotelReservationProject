using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.Models
{
    public class Hotel
    {
        public List<Chambre> Chambres { get; set; }

        public Hotel()
        {
            Chambres = new List<Chambre>();
        }

        public List<int> TrouverChambresDisponibles(List<Chambre> chambres, Reservation reservation)
        {
            var chambresDisponibles = new List<int>();

            // Filtrer les chambres en fonction de la capacité et de la disponibilité
            var chambresPotentielles = chambres.Where(c => c.Capacite >= reservation.NombrePersonnes && c.DateDebut <= reservation.DateDebut && c.DateFin >= reservation.DateFin).ToList();

            // Grouper les chambres par numéro de chambre
            var chambresGroupees = chambresPotentielles.GroupBy(c => c.NumeroChambre).ToList();

            foreach (var groupe in chambresGroupees)
            {
                int totalNuits = groupe.Sum(c => (c.DateFin - c.DateDebut).Days + 1);
                int dureeSejour = (reservation.DateFin - reservation.DateDebut).Days + 1;

                // Vérifier si la chambre est disponible pour toute la durée de la réservation
                if (totalNuits >= dureeSejour)
                {
                    chambresDisponibles.Add(groupe.Key);
                }
            }

            return chambresDisponibles.Take(reservation.NombreChambres).ToList();
        }

     
    }
}

