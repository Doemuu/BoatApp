using boatappapi.Connector;
using boatappapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace boatappapi.Service.Boat
{
    public class BoatService : IBoatService
    {
        private DbDoemuDataContext _context;
        public BoatService(DbDoemuDataContext context)
        {
            _context = context;
        }

        public ResponseModel AddBoat(BoatModel model)
        {
            try
            {
                _context.Boats.Add(model);
                _context.SaveChanges();
                return new ResponseModel { Success = true };
            }
            catch (Exception e)
            {
                return new ResponseModel { Success = false, Message = e.Message };
            }
        }

        public ResponseModel DeleteBoat(Guid id)
        {
            try
            {
                var boat = _context.Boats.First(b => b.Id == id);
                _context.Boats.Remove(boat);
                _context.SaveChanges();
                return new ResponseModel { Success = true };
            }
            catch (Exception e)
            {
                return new ResponseModel { Success = false, Message = e.Message };
            }
        }

        public BoatModel GetBoatById(Guid id)
        {
            var boat = _context.Boats.FirstOrDefault(b => b.Id == id);
            return boat;
        }

        public IList<BoatModel> GetBoats()
        {
            var boats = _context.Boats.ToList();
            return boats;
        }

        public ResponseModel UpdateBoat(BoatModel model)
        {
            try
            {
                _context.Boats.Update(model);
                _context.SaveChanges();
                return new ResponseModel { Success = true };
            }
            catch (Exception e)
            {
                return new ResponseModel { Success = false, Message = e.Message };
            }
        }
    }
}
