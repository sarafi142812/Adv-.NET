using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BAL.DTOs;
using DAL.EF;
using DAL;

namespace BAL.Services
{
    public class GuestService
    {
        public static List<GuestDTO> GetAllGuests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guest, GuestDTO>();
            });
            var mapper = new Mapper(config);

            var repo = DataAccessFactory.GuestDataAccess();
            var data = repo.GetAll();
            return mapper.Map<List<GuestDTO>>(data);
        }

        public static GuestDTO GetGuest(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guest, GuestDTO>();
            });
            var mapper = new Mapper(config);

            var repo = DataAccessFactory.GuestDataAccess();
            var data = repo.GetById(id);
            return mapper.Map<GuestDTO>(data);
        }

        public static GuestDTO AddGuest(GuestDTO guestDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestDTO, Guest>();
                cfg.CreateMap<Guest, GuestDTO>();
            });
            var mapper = new Mapper(config);

            var repo = DataAccessFactory.GuestDataAccess();
            var guest = mapper.Map<Guest>(guestDto);
            var data = repo.Add(guest);
            return mapper.Map<GuestDTO>(data);
        }

        public static GuestDTO UpdateGuest(GuestDTO guestDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestDTO, Guest>();
                cfg.CreateMap<Guest, GuestDTO>();
            });
            var mapper = new Mapper(config);

            var repo = DataAccessFactory.GuestDataAccess();
            var guest = mapper.Map<Guest>(guestDto);
            var data = repo.Update(guest);
            return mapper.Map<GuestDTO>(data);
        }

        public static bool DeleteGuest(int id)
        {
            var repo = DataAccessFactory.GuestDataAccess();
            return repo.Delete(id);
        }
    }
}
