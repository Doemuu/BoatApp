using boatappapi.Model;
using System;
using System.Collections.Generic;

namespace boatappapi.Service.Boat
{
    public interface IBoatService
    {
        //Create
        public ResponseModel AddBoat(BoatModel model);

        //Read
        public IList<BoatModel> GetBoats();

        public BoatModel GetBoatById(Guid id);

        //Update
        public ResponseModel UpdateBoat(BoatModel model);

        //Delete
        public ResponseModel DeleteBoat(Guid id);
    }
}
