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
    public class RoomService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomDTO>();
                cfg.CreateMap<RoomDTO, Room>();
            });
            return new Mapper(config);
        }

        public static List<RoomDTO> GetAllRooms()
        {
            var data = DataAccessFactory.RoomDataAccess().GetAll();
            var mapper = GetMapper();
            return mapper.Map<List<RoomDTO>>(data);
        }

        public static RoomDTO GetRoom(int id)
        {
            var data = DataAccessFactory.RoomDataAccess().GetById(id);
            var mapper = GetMapper();
            return mapper.Map<RoomDTO>(data);
        }

        public static RoomDTO AddRoom(RoomDTO room)
        {
            var mapper = GetMapper();
            var roomEntity = mapper.Map<Room>(room);
            var result = DataAccessFactory.RoomDataAccess().Add(roomEntity);
            return mapper.Map<RoomDTO>(result);
        }

        public static RoomDTO UpdateRoom(RoomDTO room)
        {
            var mapper = GetMapper();
            var roomEntity = mapper.Map<Room>(room);
            var result = DataAccessFactory.RoomDataAccess().Update(roomEntity);
            return mapper.Map<RoomDTO>(result);
        }

        public static bool DeleteRoom(int id)
        {
            return DataAccessFactory.RoomDataAccess().Delete(id);
        }

        public static List<RoomDTO> GetRoomsByType(string type)
        {
            var data = DataAccessFactory.RoomDataAccess().GetAll()
                        .Where(r => r.room_type == type).ToList();

            var mapper = GetMapper();
            return mapper.Map<List<RoomDTO>>(data);
        }

        public static List<RoomDTO> GetAvailableRooms()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomDTO>();
            });
            var mapper = new Mapper(config);

            var repo = DataAccessFactory.RoomRepoDataAccess();
            var data = repo.GetAvailableRooms();
            return mapper.Map<List<RoomDTO>>(data);
        }






    }
}
