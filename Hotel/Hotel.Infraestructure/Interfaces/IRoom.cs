
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Models;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRoom : IBaseRepository<Room>
    {
        //List<RoomCategorieModel> GetRoomsByCategorieId(int categoryId);
        //List<RoomCategorieModel> GetRoomsCategories();

        //RoomCategorieModel GetRoomCategorie(int Id);
    }
}
